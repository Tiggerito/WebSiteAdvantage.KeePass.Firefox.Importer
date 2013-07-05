/*	WebSiteAdvantage KeePass to Firefox 
 *	Copyright (C) 2008 - 2012 Anthony James McCreath
 *
 *	This library is free software; you can redistribute it and/or
 *	modify it under the terms of the GNU Lesser General Public
 *	License as published by the Free Software Foundation; either
 *	version 2.1 of the License, or (at your option) any later version.
 *
 *	This library is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *	Lesser General Public License for more details.
 *
 *	You should have received a copy of the GNU Lesser General Public
 *	License along with this library; if not, write to the Free Software
 *	Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.Text;

using KeePass.Plugins;
using KeePassLib.Security;
using KeePassLib;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.Diagnostics;
using KeePass.DataExchange;
using KeePass.Resources;
using System.Net;
using System.IO;
using KeePassLib.Interfaces;
using System.Web;
using WebSiteAdvantage.KeePass.Firefox;
using WebSiteAdvantage.KeePass.Firefox.Importer.Properties;
using WebSiteAdvantage.KeePass.Firefox.Importer;

namespace WebSiteAdvantageKeePassFirefoxImporter
{
	/// <summary>
	/// A singleton class that performs the import
	/// </summary>
	public sealed class FirefoxFormatImporterXml : FileFormatProvider
    {
		private static FirefoxFormatImporterXml _Instance = null;
        /// <summary>
        /// So can access a single common copy of the importer (Singleton)
        /// </summary>
		public static FirefoxFormatImporterXml Instance
        {
            get
            {
                if (_Instance == null)
                {
					_Instance = new FirefoxFormatImporterXml();
                }
                return _Instance;
            }
        }

		/// <summary>
		/// The type of import
		/// </summary>
        public override string ApplicationGroup
        {
            get { return KPRes.Browser; }
        }

		/// <summary>
		/// 
		/// </summary>
        public override string DefaultExtension
        {
            get { return "xml"; }
        }

        public override string FormatName
        {
            get { return "Firefox XML"; }
        }





        public override bool ImportAppendsToRootGroupOnly { get { return false; } }


		/// <summary>
		/// directly gets data from firefox
		/// </summary>
		public override bool RequiresFile
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Should get a firefox icon
		/// </summary>
		public override System.Drawing.Image SmallIcon
		{
			get
			{
				return Resources.firefox16;
			}
		}

		/// <summary>
		/// The main routine, called when import is selected
		/// </summary>
		/// <param name="pwStorage"></param>
		/// <param name="sInput"></param>
		/// <param name="slLogger"></param>
        public override void Import(PwDatabase pwStorage, System.IO.Stream sInput, KeePassLib.Interfaces.IStatusLogger slLogger)
        {
            try
            {
                FormXml form = new FormXml();

                form.Initialise(pwStorage);

                //	form.GroupName = pwStorage.RootGroup.Name;

                //if (pwStorage.LastSelectedGroup != null)
                //{
                //    form.GroupName = pwStorage.RootGroup.FindGroup(pwStorage.LastSelectedGroup, true).Name;
                //}

                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool overwritePassword = form.Overwrite;
                    bool searchWeb = form.GetTitles;
                    bool checkMatches = form.Merge;

                    bool addAutoType = form.AddAutoType;

                    PwIcon iconId = (PwIcon)Enum.Parse(typeof(PwIcon), form.IconName);

                    PwGroup group = form.Group;

                    if (group == null)
                        group = pwStorage.RootGroup;

                    try
                    {
                        InternetAccessor internetAccessor = new InternetAccessor();

                        slLogger.StartLogging("Importing Firefox File", false);

                        slLogger.SetText("Reading File", LogStatusType.Info);

                        // Load in the supplied xml document
                        XmlDocument fireFoxDocument = new XmlDocument();
                        XmlReaderSettings settings = new XmlReaderSettings();
                        settings.CheckCharacters = false;
                        settings.ValidationType = ValidationType.None;

                        XmlReader reader = XmlTextReader.Create(sInput, settings);
                        try
                        {
                            fireFoxDocument.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Failed to load the password file. " + Environment.NewLine +
                                "This may be due to the presence of foreign characters in the data. " + Environment.NewLine +
                                "Please check the website for help" + Environment.NewLine + Environment.NewLine + ex.Message, ex);
                        }
                        finally
                        {
                            reader.Close();
                        }

                        // Get a collection of nodes that represent each password
                        XmlNodeList fireFoxEntryNodes = fireFoxDocument.SelectNodes("xml/entries/entry");

                        int count = fireFoxEntryNodes.Count;
                        int pos = 0;

                        // Loop each entry and add it to KeePass
                        foreach (XmlElement fireFoxEntryElement in fireFoxEntryNodes)
                        {
                            if (!slLogger.ContinueWork()) // Check if process has been cancelled by the user
                                break;

                            // keep the user informed of progress
                            pos++;
                            slLogger.SetProgress((uint)(100 * ((double)pos) / ((double)count)));

                            // gather the data to import
                            string title = "HOST";

                            XmlNode hostNode = fireFoxEntryElement.SelectSingleNode("@host");
                            XmlNode formSubmitURLNode = fireFoxEntryElement.SelectSingleNode("@formSubmitURL");
                            XmlNode userNode = fireFoxEntryElement.SelectSingleNode("@user");
                            XmlNode passwordNode = fireFoxEntryElement.SelectSingleNode("@password");

                            if (hostNode != null)
                                title = hostNode.InnerText;

                            slLogger.SetText(title, LogStatusType.Info);


                            string notes = String.Empty;

                            if (form.IncludeImportNotes)
                            {
                                notes += "Imported from FireFox by the Web Site Advantage FireFox to KeePass Importer" + Environment.NewLine;
                            }

                            string url = String.Empty; 
                            
                            if (hostNode!=null)
                                url = hostNode.InnerText;

                            string formSubmitURL = String.Empty;

                            if (formSubmitURLNode!=null)
                                formSubmitURL = formSubmitURLNode.InnerText;

                            if (!String.IsNullOrEmpty(formSubmitURL))
                                url = formSubmitURL;

                            string host = url;
                            try
                            {
                                Uri uri = new Uri(url);
                                host = uri.Host;
                            }
                            catch { }

                            string username = String.Empty;

                            if (userNode!=null)
                                username = userNode.InnerText;

                            bool newEntry = true;

                            PwEntry pe = null;

                            if (checkMatches)
                                pe = KeePassHelper.FindMatchingEntry(pwStorage.RootGroup, url, username);

                            if (pe == null)
                            {
                                // create a new entry
                                pe = new PwEntry(true, true);
                                group.AddEntry(pe, true);
                                slLogger.SetText("Created new entry", LogStatusType.AdditionalInfo);
                            }
                            else
                            {
                                newEntry = false;
                                slLogger.SetText("Found matching entry", LogStatusType.AdditionalInfo);
                            }

                            if (newEntry || overwritePassword)
                            {
                                // set the password
                                if (passwordNode!=null)
                                    pe.Strings.Set(PwDefs.PasswordField, new ProtectedString(pwStorage.MemoryProtection.ProtectPassword, passwordNode.InnerText));
                            }

                            if (newEntry)
                            {
                                // set all fields
                                pe.Strings.Set(PwDefs.TitleField, new ProtectedString(pwStorage.MemoryProtection.ProtectTitle, title));
                                pe.Strings.Set(PwDefs.UserNameField, new ProtectedString(pwStorage.MemoryProtection.ProtectUserName, username));
                                pe.Strings.Set(PwDefs.UrlField, new ProtectedString(pwStorage.MemoryProtection.ProtectUrl, url));
                                if (!String.IsNullOrEmpty(notes))
                                    pe.Strings.Set(PwDefs.NotesField, new ProtectedString(pwStorage.MemoryProtection.ProtectNotes, notes));
                                pe.Expires = false;
                                pe.IconId = iconId;

                                // Gatter any extra information... 

                                if (fireFoxEntryElement.HasAttribute("userFieldName") && fireFoxEntryElement.GetAttribute("userFieldName").Length > 0)
                                    pe.Strings.Set("UserNameField", new ProtectedString(false, fireFoxEntryElement.GetAttribute("userFieldName")));

                                if (fireFoxEntryElement.HasAttribute("usernameField") && fireFoxEntryElement.GetAttribute("usernameField").Length > 0)
                                    pe.Strings.Set("UserNameField", new ProtectedString(false, fireFoxEntryElement.GetAttribute("usernameField")));

                                if (fireFoxEntryElement.HasAttribute("passFieldName") && fireFoxEntryElement.GetAttribute("passFieldName").Length > 0)
                                    pe.Strings.Set("PasswordField", new ProtectedString(false, fireFoxEntryElement.GetAttribute("passFieldName")));

                                if (fireFoxEntryElement.HasAttribute("passwordField") && fireFoxEntryElement.GetAttribute("passwordField").Length > 0)
                                    pe.Strings.Set("PasswordField", new ProtectedString(false, fireFoxEntryElement.GetAttribute("passwordField")));

                                if (fireFoxEntryElement.HasAttribute("httpRealm") && fireFoxEntryElement.GetAttribute("httpRealm").Length > 0)
                                    pe.Strings.Set("HttpRealm", new ProtectedString(false, fireFoxEntryElement.GetAttribute("httpRealm")));

                                if (fireFoxEntryElement.HasAttribute("formSubmitURL") && fireFoxEntryElement.GetAttribute("formSubmitURL").Length > 0)
                                    pe.Strings.Set("LoginFormDomain", new ProtectedString(false, fireFoxEntryElement.GetAttribute("formSubmitURL")));

                            }

                            string webTitle = null;
                            // if new or the title is the same as the url then we should try and get the title
                            if (searchWeb)
                            {

                                // test if new or entry has url as title
                                if ((newEntry || pe.Strings.Get(PwDefs.TitleField).ReadString() == pe.Strings.Get(PwDefs.UrlField).ReadString()))
                                {
                                    // get the pages title
                                    slLogger.SetText("Accessing website for title", LogStatusType.AdditionalInfo);

                                    webTitle = internetAccessor.ScrapeTitle(url);

                                    if (!String.IsNullOrEmpty(webTitle))
                                    {
                                        // PATCH: supplied by Sarel Botha
                                        // remove protocol from site so that it works with new KeepassHTTP
                                        if (webTitle.StartsWith("http://")) webTitle = webTitle.Substring(7);
                                        if (webTitle.StartsWith("https://")) webTitle = webTitle.Substring(8);

                                        // remove port number if the title contains it so that it will work with new KeepassHTTP
                                        if (webTitle.Contains(":")) webTitle = webTitle.Substring(0, webTitle.IndexOf(':'));
                                        // PATCH END

                                        slLogger.SetText("Title set from internet to " + webTitle, LogStatusType.AdditionalInfo);

                                        pe.Strings.Set(PwDefs.TitleField, new ProtectedString(pwStorage.MemoryProtection.ProtectTitle, webTitle));
                                    }
                                }
                            }

                            if (addAutoType)
                                KeePassHelper.InsertAutoType(pe, "*" + host + "*", KeePassUtilities.AutoTypeSequence());

                            if (webTitle != null && addAutoType)
                                KeePassHelper.InsertAutoType(pe, KeePassUtilities.AutoTypeWindow(webTitle), KeePassUtilities.AutoTypeSequence());
                        }
                    }
                    finally
                    {
                        slLogger.EndLogging();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Failed to Validate Password"))
                    MessageBox.Show(ex.Message, "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    ErrorMessage.ShowErrorMessage("Importer Xml", "Import Failed", ex);
                }
            }
        }

        public override bool SupportsExport
        {
            get { return false; }
        }

        public override bool SupportsImport
        {
            get { return true; }
        }
    }
}
