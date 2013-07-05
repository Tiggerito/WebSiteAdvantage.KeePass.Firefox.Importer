/*	WebSiteAdvantage KeePass to Firefox 
 *	Copyright (C) 2008 - 2012  Anthony James McCreath
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using WebSiteAdvantage.KeePass.Firefox;
using System.Threading;

namespace WebSiteAdvantage.KeePass.FireFoxConverter
{
	public delegate void LogEventDeligate(string message);
	public delegate void LogProgressDeligate(int percent);
	public delegate void ThreadFinishedDeligate(Exception ex);

    public partial class Form1 : Form
	{
		#region Constructor
		public Form1()
        {
            InitializeComponent();

			this.comboBoxIconName.SelectedIndex = 16;
		}
		#endregion

		#region Thread Management
		private Thread _Thread = null;
		protected void StopThread()
		{
			if (_Thread != null)
			{
				_Thread.Abort();
				_Thread = null;
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			StopThread(); 
			base.OnClosing(e);
		}
		#endregion

		#region Thread Events

		/// <summary>
		/// thread safe way to update the porgress bar
		/// </summary>
		/// <param name="percent"></param>
		protected void LogProgress(int percent)
		{
			if (this.InvokeRequired)
				this.Invoke(new LogProgressDeligate(LogProgress), new object[] { percent });
			else
			{
				this.progressBar1.Value = percent;
			}
		}

		/// <summary>
		/// Call this at the end of any thread execution
		/// if theres an exception it will warn the user otherwise it will indicate success
		/// </summary>
		/// <param name="ex"></param>
		protected void ThreadFinished(Exception ex)
		{
			if (this.InvokeRequired)
				this.Invoke(new ThreadFinishedDeligate(ThreadFinished), new object[] { ex });
			else
			{
				buttonGenerate.Text = "Start";
				_Thread = null;
				this.tabControl1.Enabled = true;

				if (ex == null)
				{
					// success
					MessageBox.Show("KeePass file successfully created", "Converted", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					if (ex is ThreadAbortException)
						MessageBox.Show("Stopped", "Converting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					else
					{
                        if (ex.Message.Contains("Failed to Validate Password"))
                            MessageBox.Show(ex.Message, "Converting Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            ErrorMessage.ShowErrorMessage("Convertor", "Converting Failed", ex);
                        }

						KeePassUtilities.LogException(ex);
					}
				}
			}
		}
		#endregion

		#region Data For Thread
		private string _KeePassFile;
		/// <summary>
		/// The file to store the result in
		/// </summary>
		public string KeePassFile
		{
			get { return _KeePassFile; }
			set 
			{ 
				if (value.Contains("."))
					_KeePassFile = value; 
				else
					_KeePassFile = value+".xml"; 
			}
		}

		private string _FirefoxFile;
		/// <summary>
		/// The file to load from if using xml exported data
		/// </summary>
		public string FirefoxFile
		{
			get { return _FirefoxFile; }
			set { _FirefoxFile = value; }
		}


		private bool _GetTitles;
		/// <summary>
		/// If the internet should be used to get titles
		/// </summary>
		public bool GetTitles
		{
			get { return _GetTitles; }
			set { _GetTitles = value; }
		}

		private bool _GenerateAutoType;
		/// <summary>
		/// Should auttype data be added
		/// </summary>
		public bool GenerateAutoType
		{
			get { return _GenerateAutoType; }
			set { _GenerateAutoType = value; }
		}

		private string _GroupName;
		/// <summary>
		/// The name of the group to store the entries
		/// </summary>
		public string GroupName
		{
			get { return _GroupName; }
			set { _GroupName = value; }
		}

		private int _IconId;
		/// <summary>
		/// The id of the icon to use with all entries
		/// </summary>
		public int IconId
		{
			get { return _IconId; }
			set { _IconId = value; }
		}

		private string _FirefoxMasterPassword;
		/// <summary>
		/// password to use when accessing firefox
		/// </summary>
		public string FirefoxMasterPassword
		{
			get { return _FirefoxMasterPassword; }
			set { _FirefoxMasterPassword = value; }
		}


		private string _ProfilePath;
		/// <summary>
		/// the path to the selected profile
		/// </summary>
		public string ProfilePath
		{
			get { return _ProfilePath; }
			set { _ProfilePath = value; }
		}

	
		#endregion

		#region Generators
		/// <summary>
		/// Create the keepass file using an exported firefox file 
		/// </summary>
		private void GenerateUsingExport()
		{
			try
			{
				InternetAccessor internetAccessor = new InternetAccessor();

				// load in the firefox xml document
				XmlDocument fireFoxDocument = new XmlDocument();
				FileStream fileStream = File.Open(FirefoxFile, FileMode.Open, FileAccess.Read);
				try
				{
					XmlReaderSettings settings = new XmlReaderSettings();
					settings.CheckCharacters = false;
					settings.ValidationType = ValidationType.None;

					XmlReader reader = XmlTextReader.Create(fileStream, settings);

					try
					{
						fireFoxDocument.Load(reader);
					}
					finally
					{
						reader.Close();
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Failed to load the password file. " + Environment.NewLine +
						"This may be due to the presence of foreign characters in the data. " + Environment.NewLine +
						"Please check the website for help" + Environment.NewLine + Environment.NewLine + ex.Message, ex);
				}
				finally
				{
					fileStream.Close();
				}


				// get a list of each password node
				XmlNodeList fireFoxEntryNodes = fireFoxDocument.SelectNodes("xml/entries/entry");

				// the output xml document
				XmlDocument keePassDocument = new XmlDocument();

				XmlElement keePassRootElement = keePassDocument.CreateElement("pwlist");
				keePassDocument.AppendChild(keePassRootElement);


				int current = 0;
				int max = fireFoxEntryNodes.Count;
				// loop each input password and generate the output password
				foreach (XmlElement fireFoxEntryElement in fireFoxEntryNodes)
				{
					current++;

					string title = fireFoxEntryElement.SelectSingleNode("@host").InnerText;

					string url = title;

					string formSubmitURL = fireFoxEntryElement.SelectSingleNode("@formSubmitURL").InnerText;

					if (!String.IsNullOrEmpty(formSubmitURL))
						url = formSubmitURL;

                    string host = url;
                    try
                    {
                        Uri uri = new Uri(url);
                        host = uri.Host;
                    }
                    catch { }

                    string internetTitle = null;

                    if (GetTitles)
                    {

                        // get the pages title
                        try
                        {
                            internetTitle = internetAccessor.ScrapeTitle(url);

                            if (!String.IsNullOrEmpty(internetTitle))
                            {
                                title = internetTitle;
                            }

                        }
                        catch (Exception ex)
                        {
                            // some issue!
                            KeePassUtilities.LogException(ex);
                        }
                    }

                    string notes = String.Empty;

                    if (checkBoxIncludeImportNotes.Checked)
                    {
                        notes +=
                            "Imported from FireFox by the Web Site Advantage Firefox To KeePass Importer" + Environment.NewLine + Environment.NewLine +
                            "UserNameField=" + fireFoxEntryElement.SelectSingleNode("@userFieldName").InnerText + System.Environment.NewLine +
                            "PasswordField=" + fireFoxEntryElement.SelectSingleNode("@passFieldName").InnerText + System.Environment.NewLine +
                            "LoginFormDomain=" + fireFoxEntryElement.SelectSingleNode("@formSubmitURL").InnerText + System.Environment.NewLine;
                    }

                    if (GenerateAutoType)
                    {
                        if (!String.IsNullOrEmpty(internetTitle))
                        {

                            notes += Environment.NewLine +
                                "Auto-Type: " + KeePassUtilities.AutoTypeSequence() + Environment.NewLine +
                                "Auto-Type-Window: *" + host + "*" + Environment.NewLine +
                                "Auto-Type-Window: " + KeePassUtilities.AutoTypeWindow(internetTitle) + Environment.NewLine;
                        }
                        else
                        {
                            notes += Environment.NewLine +
                                "Auto-Type: " + KeePassUtilities.AutoTypeSequence() + Environment.NewLine +
                                "Auto-Type-Window: *" + host + "*" + Environment.NewLine;
                        }
                    }

                    string now = XmlConvert.ToString(DateTime.Now, "yyyy-MM-ddTHH:mm:ss");

                    // create the xml

                    XmlElement keePassEntryElement = keePassDocument.CreateElement("pwentry");
                    keePassRootElement.AppendChild(keePassEntryElement);

                    XmlElement keePassGroupElement = keePassDocument.CreateElement("group");
                    keePassEntryElement.AppendChild(keePassGroupElement);
                    keePassGroupElement.InnerText = GroupName;

                    // set the group the password gets stored in
                    if (!String.IsNullOrEmpty(GroupName))
                        keePassGroupElement.SetAttribute("tree", GroupName);

                    XmlElement keePassTitleElement = keePassDocument.CreateElement("title");
                    keePassEntryElement.AppendChild(keePassTitleElement);
                    keePassTitleElement.InnerText = title;

                    XmlElement keePassUserNameElement = keePassDocument.CreateElement("username");
                    keePassEntryElement.AppendChild(keePassUserNameElement);
                    keePassUserNameElement.InnerText = fireFoxEntryElement.SelectSingleNode("@user").InnerText;

                    XmlElement keePassURLElement = keePassDocument.CreateElement("url");
                    keePassEntryElement.AppendChild(keePassURLElement);
                    keePassURLElement.InnerText = fireFoxEntryElement.SelectSingleNode("@host").InnerText;


                    XmlElement keePassPasswordElement = keePassDocument.CreateElement("password");
                    keePassEntryElement.AppendChild(keePassPasswordElement);
                    keePassPasswordElement.InnerText = fireFoxEntryElement.SelectSingleNode("@password").InnerText;

                    // put other stuff in the notes
                    if (!String.IsNullOrEmpty(notes))
                    {
                        XmlElement keePassNotesElement = keePassDocument.CreateElement("notes");
                        keePassEntryElement.AppendChild(keePassNotesElement);

                        XmlCDataSection cd = keePassDocument.CreateCDataSection(notes);
                        keePassNotesElement.AppendChild(cd);
                    }

					XmlElement keePassUuidElement = keePassDocument.CreateElement("uuid");
					keePassEntryElement.AppendChild(keePassUuidElement);
					keePassUuidElement.InnerText = Guid.NewGuid().ToString().Replace("-", "").ToLower(); // condensed guid

					XmlElement keePassImageElement = keePassDocument.CreateElement("image");
					keePassEntryElement.AppendChild(keePassImageElement);
					keePassImageElement.InnerText = IconId.ToString();

					XmlElement keePassCreatedElement = keePassDocument.CreateElement("creationtime");
					keePassEntryElement.AppendChild(keePassCreatedElement);
					keePassCreatedElement.InnerText = now;

					XmlElement keePassModifiedElement = keePassDocument.CreateElement("lastmodtime");
					keePassEntryElement.AppendChild(keePassModifiedElement);
					keePassModifiedElement.InnerText = now;

					XmlElement keePassAccessedElement = keePassDocument.CreateElement("lastaccesstime");
					keePassEntryElement.AppendChild(keePassAccessedElement);
					keePassAccessedElement.InnerText = now;

					// so it does not expire
					XmlElement keePassExpiresElement = keePassDocument.CreateElement("expiretime");
					keePassEntryElement.AppendChild(keePassExpiresElement);
					keePassExpiresElement.SetAttribute("expires", "false");
					keePassExpiresElement.InnerText = "2999-12-28T23:59:59";

					LogProgress((int)((double)(current) * 100 / (double)max));
				}

				XmlTextWriter writer = new XmlTextWriter(KeePassFile, Encoding.UTF8);
				try
				{
					writer.Formatting = Formatting.Indented;
					keePassDocument.Save(writer);
				}
				finally
				{
					writer.Close();
				}

				this.ThreadFinished(null);
			}
			catch (Exception ex)
			{
				this.ThreadFinished(ex);
			}

		}

		/// <summary>
		/// generates a keepass xml file by directly accessing firefoxes passwords
		/// designed to be used in a thread
		/// uses the thread 
		/// </summary>
		private void GenerateUsingFirefox()
		{

			try
			{
				InternetAccessor internetAccessor = new InternetAccessor();

				FirefoxProfile profile = new FirefoxProfile(this.ProfilePath); 

				profile.Login(this.FirefoxMasterPassword);

				FirefoxSignonsFile signonsFile = profile.GetSignonsFile(this.FirefoxMasterPassword);

				// the group to store the passwords

				// the output xml document
				XmlDocument keePassDocument = new XmlDocument();

				XmlElement keePassRootElement = keePassDocument.CreateElement("pwlist");
				keePassDocument.AppendChild(keePassRootElement);

				int current = 0;
				int max = signonsFile.SignonSites.Count;
				// loop each input password and generate the output password
				foreach (FirefoxSignonSite signonSite in signonsFile.SignonSites)
				{
					current++;

					string siteTitle = null;

					if (GetTitles)
						siteTitle = internetAccessor.ScrapeTitle(signonSite.Site);

					foreach (FirefoxSignon signon in signonSite.Signons)
					{

						string title = siteTitle == null ? signonSite.Site : siteTitle;

						if (!String.IsNullOrEmpty(signon.LoginFormDomain))
							title = signon.LoginFormDomain;

                        string host = null;
                        try
                        {
                            Uri uri = new Uri(signonSite.Site);
                            host = uri.Host;
                        }
                        catch { }

						if (GetTitles)
						{
							// get the pages title

							string internetTitle = null;

							if (String.IsNullOrEmpty(signon.LoginFormDomain) || signon.LoginFormDomain == signonSite.Site)
								internetTitle = siteTitle;
							else
								internetTitle = internetAccessor.ScrapeTitle(signon.LoginFormDomain);

							if (!String.IsNullOrEmpty(internetTitle))
							{
								title = internetTitle;
							}

						}

                        string notes = String.Empty;

                        if (checkBoxIncludeImportNotes.Checked)
                        {
                            notes += "Imported from FireFox by the Web Site Advantage Firefox To KeePass" + Environment.NewLine;
                        }

                        if (GenerateAutoType)
                        {
                            if (this.GetTitles)
                            {

                                notes += Environment.NewLine  +
                                    "Auto-Type: " + KeePassUtilities.AutoTypeSequence() + Environment.NewLine +
                                    (String.IsNullOrEmpty(host) ? String.Empty : "Auto-Type-Window: *" + host + "*" + Environment.NewLine) +
                                    "Auto-Type-Window: " + KeePassUtilities.AutoTypeWindow(title) + Environment.NewLine;

                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(host))
                                {
                                    notes += Environment.NewLine  +
                                        "Auto-Type: " + KeePassUtilities.AutoTypeSequence() + Environment.NewLine +
                                        "Auto-Type-Window: *" + host + "*" + Environment.NewLine;
                                }
                            }
                        }


                        string now = XmlConvert.ToString(DateTime.Now, "yyyy-MM-ddTHH:mm:ss");

                        // create xml

                        XmlElement keePassEntryElement = keePassDocument.CreateElement("pwentry");
                        keePassRootElement.AppendChild(keePassEntryElement);

                        XmlElement keePassGroupElement = keePassDocument.CreateElement("group");
                        keePassEntryElement.AppendChild(keePassGroupElement);
                        keePassGroupElement.InnerText = GroupName;

                        // set the group the password gets stored in
                        if (!String.IsNullOrEmpty(GroupName))
                            keePassGroupElement.SetAttribute("tree", GroupName);

						XmlElement keePassTitleElement = keePassDocument.CreateElement("title");
						keePassEntryElement.AppendChild(keePassTitleElement);
						keePassTitleElement.InnerText = title;

						XmlElement keePassUserNameElement = keePassDocument.CreateElement("username");
						keePassEntryElement.AppendChild(keePassUserNameElement);
						keePassUserNameElement.InnerText = signon.UserName;

						XmlElement keePassURLElement = keePassDocument.CreateElement("url");
						keePassEntryElement.AppendChild(keePassURLElement);
						keePassURLElement.InnerText = signonSite.Site;

						XmlElement keePassPasswordElement = keePassDocument.CreateElement("password");
						keePassEntryElement.AppendChild(keePassPasswordElement);
						keePassPasswordElement.InnerText = signon.Password;

                        if (!String.IsNullOrEmpty(notes))
                        {
                            // put other stuff in the notes
                            XmlElement keePassNotesElement = keePassDocument.CreateElement("notes");
                            keePassEntryElement.AppendChild(keePassNotesElement);

                            //	keePassNotesElement.InnerText =

                            XmlCDataSection cd = keePassDocument.CreateCDataSection(notes);
                            keePassNotesElement.AppendChild(cd);
                        }

						XmlElement keePassUuidElement = keePassDocument.CreateElement("uuid");
						keePassEntryElement.AppendChild(keePassUuidElement);
						keePassUuidElement.InnerText = Guid.NewGuid().ToString().Replace("-", "").ToLower(); // condensed guid

						XmlElement keePassImageElement = keePassDocument.CreateElement("image");
						keePassEntryElement.AppendChild(keePassImageElement);
						keePassImageElement.InnerText = IconId.ToString();


						XmlElement keePassCreatedElement = keePassDocument.CreateElement("creationtime");
						keePassEntryElement.AppendChild(keePassCreatedElement);
						keePassCreatedElement.InnerText = now;

						XmlElement keePassModifiedElement = keePassDocument.CreateElement("lastmodtime");
						keePassEntryElement.AppendChild(keePassModifiedElement);
						keePassModifiedElement.InnerText = now;

						XmlElement keePassAccessedElement = keePassDocument.CreateElement("lastaccesstime");
						keePassEntryElement.AppendChild(keePassAccessedElement);
						keePassAccessedElement.InnerText = now;

						// so it does not expire
						XmlElement keePassExpiresElement = keePassDocument.CreateElement("expiretime");
						keePassEntryElement.AppendChild(keePassExpiresElement);
						keePassExpiresElement.SetAttribute("expires", "false");
						keePassExpiresElement.InnerText = "2999-12-28T23:59:59";

						LogProgress((int)((double)(current) * 100 / (double)max));
					}
				}


				// save the xml. this way the encoding header is included...
				XmlTextWriter writer = new XmlTextWriter(KeePassFile, Encoding.UTF8);
				try
				{
					writer.Formatting = Formatting.Indented;
					keePassDocument.Save(writer);
				}
				finally
				{
					writer.Close();
				}

				this.ThreadFinished(null);


			}
			catch (Exception ex)
			{
				this.ThreadFinished(ex);
			}

		}
		#endregion

		#region GUI Events to Thread start Generators
		/// <summary>
		/// gathers the required data then starts the appropriate thread
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonStart_Click(object sender, EventArgs e)
		{
			LogProgress(0); // reset the progress bar

			if (textBoxGroup.Text.Trim().Length == 0)
				MessageBox.Show("A group is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
			{

				if (_Thread != null)
				{
					StopThread();
					buttonGenerate.Text = "Start";
			//		this.progressBar1.Visible = false;
					this.tabControl1.Enabled = true;
				}
				else
				{
					GetTitles = checkBoxTitle.Checked;
					GenerateAutoType = this.checkBoxAutoType.Checked;
					GroupName = this.textBoxGroup.Text.Trim();
					IconId = this.comboBoxIconName.SelectedIndex;
					FirefoxMasterPassword = this.textBoxPassword.Text;



					if (radioButtonUseFirefox.Checked)
					{
						if (this.comboBoxProfile.SelectedItem != null)
							ProfilePath = ((FirefoxProfileInfo)this.comboBoxProfile.SelectedItem).AbsolutePath;
						else
						{
							MessageBox.Show("No Profile Selected. Use Load More Profiles", "Profile Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						SaveFileDialog saveFileDialog = new SaveFileDialog();

						saveFileDialog.Title = "Save KeePass file as...";
						saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
						saveFileDialog.FilterIndex = 1;
						saveFileDialog.RestoreDirectory = true;
						saveFileDialog.DefaultExt = "xml";

						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							KeePassFile = saveFileDialog.FileName;
							_Thread = new Thread(new ThreadStart(GenerateUsingFirefox));
						}
					}
					else
					{
						OpenFileDialog openFileDialog1 = new OpenFileDialog();

						openFileDialog1.Title = "Select the exported Firefox password file";
						openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
						openFileDialog1.FilterIndex = 1;
						openFileDialog1.RestoreDirectory = true;

						if (openFileDialog1.ShowDialog() == DialogResult.OK)
						{
							FirefoxFile = openFileDialog1.FileName;

							SaveFileDialog saveFileDialog = new SaveFileDialog();

							saveFileDialog.Title = "Save KeePass file as...";
							saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
							saveFileDialog.FilterIndex = 1;
							saveFileDialog.RestoreDirectory = true;
							saveFileDialog.DefaultExt = "xml";

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								KeePassFile = saveFileDialog.FileName;

								_Thread = new Thread(new ThreadStart(GenerateUsingExport));
							}
						}
					}

					if (_Thread != null)
					{
						_Thread.Name = "Converter";
				//		this.progressBar1.Visible = true;
						_Thread.Start();

						buttonGenerate.Text = "Stop";
						this.tabControl1.Enabled = false;
					}
				}
			}
		}
		#endregion

		#region GUI Events

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            Process.Start("http://seo-website-designer.com/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=link&utm_campaign=converter-" + KeePassUtilities.Version);
		}

		private void checkBoxTitle_CheckedChanged(object sender, EventArgs e)
		{
	//		this.checkBoxAutoType.Enabled = this.checkBoxTitle.Checked;
		}

		/// <summary>
		/// closes the window after making sure the thread has stopped
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.StopThread();
			this.Close();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			groupBoxFirefox.Enabled = radioButtonUseFirefox.Checked;
		}

		private void linkLabelExporter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://addons.mozilla.org/en-US/firefox/addon/2848");
		}

		private void buttonHelp_Click(object sender, EventArgs e)
		{
            Process.Start("http://seo-website-designer.com/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=help&utm_campaign=converter-" + KeePassUtilities.Version);
		}
		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://keepass.info/plugins.html#xmlimport");
		}
		#endregion

		private void Form1_Load(object sender, EventArgs e)
		{
			List<FirefoxProfileInfo> profiles = FirefoxProfileInfo.FindFirefoxProfileInfos();
			this.comboBoxProfile.DataSource = profiles;
			this.comboBoxProfile.DisplayMember = "Name";

            this.Text = "Web Site Advantage Firefox to KeePass Converter (" + KeePassUtilities.Version + ")";

			foreach (FirefoxProfileInfo profile in profiles)
			{
				if (profile.Default)
				{
					this.comboBoxProfile.SelectedItem = profile;
					break;
				}
			}
			
		}

        private void buttonFindProfiles_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Yes - If you wish to load profiles via the profiles ini file."+ Environment.NewLine+
                "No  - To directly select a profiles folder.",
                "Load Profiles ini file?", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


            if (result == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Title = "Select a Firefox Profiles.ini file";
                openFileDialog1.Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                //   openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    List<FirefoxProfileInfo> list = (List<FirefoxProfileInfo>)this.comboBoxProfile.DataSource;
                    FirefoxProfileInfo.FindFirefoxProfileInfosFromIniFile(openFileDialog1.FileName, list);

                    // get it to refresh!
                    this.comboBoxProfile.DataSource = null;
                    this.comboBoxProfile.DataSource = list;
                }
            }

            if (result == DialogResult.No)
            {
                FolderBrowserDialog openFolderDialog1 = new FolderBrowserDialog();

                openFolderDialog1.Description = "Select a Firefox Profile folder";
                openFolderDialog1.ShowNewFolderButton = false;


                if (openFolderDialog1.ShowDialog() == DialogResult.OK)
                {

                    List<FirefoxProfileInfo> list = (List<FirefoxProfileInfo>)this.comboBoxProfile.DataSource;
                    FirefoxProfileInfo profile = new FirefoxProfileInfo();

                    profile.Name = openFolderDialog1.SelectedPath.Substring(openFolderDialog1.SelectedPath.LastIndexOf(@"\")+1);
                    profile.Path = openFolderDialog1.SelectedPath;
                    profile.Default = false;
                    profile.IsRelative = false;

                    list.Add(profile);

                    // get it to refresh!
                    this.comboBoxProfile.DataSource = null;
                    this.comboBoxProfile.DataSource = list;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://seo-website-designer.com/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=help&utm_campaign=converterdonate-" + KeePassUtilities.Version);

        }


	}
}