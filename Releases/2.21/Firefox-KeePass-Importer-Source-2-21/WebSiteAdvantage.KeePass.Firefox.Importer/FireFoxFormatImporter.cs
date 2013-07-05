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
    public sealed class FirefoxFormatImporter : FileFormatProvider
    {
        private static FirefoxFormatImporter _Instance = null;
        /// <summary>
        /// So can access a single common copy of the importer (Singleton)
        /// </summary>
        public static FirefoxFormatImporter Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FirefoxFormatImporter();
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
		/// xml
		/// </summary>
        public override string DefaultExtension
        {
            get { return "xml"; }
        }

        public override string FormatName
        {
            get { return "Firefox"; }
        }



        public override bool ImportAppendsToRootGroupOnly { get { return false; } }


		/// <summary>
		/// directly gets data from firefox
		/// </summary>
		public override bool RequiresFile
		{
			get
			{
				return false;
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
                Form1 form = new Form1();

                form.Initialise(pwStorage);

                if (form.ShowDialog() == DialogResult.OK)
                {

                    // return;
                    bool overwritePassword = form.Overwrite;
                    bool searchWeb = form.GetTitles;
                    bool checkMatches = form.Merge;
                    string masterPassword = form.Password;

                    bool addAutoType = form.AddAutoType;
                    PwIcon? iconId = null;

                    if (!string.IsNullOrWhiteSpace(form.IconName))
                    {
                        try
                        {
                            iconId = (PwIcon)Enum.Parse(typeof(PwIcon), form.IconName);
                        }
                        catch (Exception) { } // not sure how None icon is represented
                    }

                    string profilePath = form.ProfilePath;

                    if (String.IsNullOrEmpty(profilePath))
                    {
                        MessageBox.Show("No Profile Selected. Use Load More Profiles", "Profile Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Import(pwStorage, sInput, slLogger); // bit of a hack!
                        return;
                    }

                    PwGroup group = form.Group;

                    if (group == null)
                        group = pwStorage.RootGroup;

                    //     return;

                    try
                    {
                        InternetAccessor internetAccessor = new InternetAccessor();

                        slLogger.StartLogging("Importing Firefox Passwords", false);

                        slLogger.SetText("Logging In", LogStatusType.Info);

                        FirefoxProfile profile = new FirefoxProfile(profilePath);

                        profile.Login(masterPassword);

                        slLogger.SetText("Reading Signon file", LogStatusType.Info);


                        FirefoxSignonsFile signonsFile = profile.GetSignonsFile(masterPassword);


                        slLogger.SetText("Processing Passwords", LogStatusType.Info);

                        int count = signonsFile.SignonSites.Count;
                        int pos = 0;

                        //  return;

                        // Loop each entry and add it to KeePass
                        foreach (FirefoxSignonSite signonSite in signonsFile.SignonSites)
                        {
                            // keep the user informed of progress
                            pos++;

                            foreach (FirefoxSignon signon in signonSite.Signons)
                            {
                                if (!slLogger.ContinueWork()) // Check if process has been cancelled by the user
                                    break;


                                slLogger.SetProgress((uint)(100 * ((double)pos) / ((double)count)));


                                string notes = String.Empty;

                                if (form.IncludeImportNotes)
                                {
                                    notes += "Imported from FireFox by the Web Site Advantage FireFox to KeePass Importer" + Environment.NewLine;
                                }

                                // gather the data to import

                                string title = signonSite.Site;

                                // PATCH: supplied by Sarel Botha
                                // remove protocol from site so that it works with new KeepassHTTP
                                if (title.StartsWith("http://")) title = title.Substring(7);
                                if (title.StartsWith("https://")) title = title.Substring(8);

                                // remove port number if the title contains it so that it will work with new KeepassHTTP
                                if (title.Contains(":")) title = title.Substring(0, title.IndexOf(':'));
                                // PATCH END

                                string url = signonSite.Site;

                                if (!String.IsNullOrEmpty(signon.LoginFormDomain))
                                {
                                    title = signon.LoginFormDomain;
                                    url = signon.LoginFormDomain;
                                }

                                string host = url;
                                try
                                {
                                    Uri uri = new Uri(url);
                                    host = uri.Host;
                                }
                                catch { }

                                slLogger.SetText(title, LogStatusType.Info);


                                string username = signon.UserName;

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
                                    pe.Strings.Set(PwDefs.PasswordField, new ProtectedString(pwStorage.MemoryProtection.ProtectPassword, signon.Password));
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

                                    if (iconId!=null)
                                        pe.IconId = iconId.Value;

                                    // Gatter any extra information... 

                                    if (!String.IsNullOrEmpty(signon.UserNameField))
                                        pe.Strings.Set("UserNameField", new ProtectedString(false, signon.UserNameField));

                                    if (!String.IsNullOrEmpty(signon.PasswordField))
                                        pe.Strings.Set("PasswordField", new ProtectedString(false, signon.PasswordField));

                                    if (!String.IsNullOrEmpty(signon.LoginFormDomain))
                                        pe.Strings.Set("LoginFormDomain", new ProtectedString(false, signon.LoginFormDomain));

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
                                            slLogger.SetText("Title set from internet to " + webTitle, LogStatusType.AdditionalInfo);


                                            pe.Strings.Set(PwDefs.TitleField, new ProtectedString(pwStorage.MemoryProtection.ProtectTitle, webTitle));
                                        }
                                    }
                                    //else
                                    //{
                                    //    // Entry has a good title, keep it incase there are other ones for this site
                                    //    title = pe.Strings.Get(PwDefs.TitleField).ReadString();
                                    //}
                                }
                                // return;


                                if (addAutoType)
                                    KeePassHelper.InsertAutoType(pe, "*" + host + "*", KeePassUtilities.AutoTypeSequence());

                                // return;

                                if (webTitle != null && addAutoType)
                                    KeePassHelper.InsertAutoType(pe, KeePassUtilities.AutoTypeWindow(webTitle), KeePassUtilities.AutoTypeSequence());

                            }
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
                    ErrorMessage.ShowErrorMessage("Importer", "Import Failed", ex);
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
