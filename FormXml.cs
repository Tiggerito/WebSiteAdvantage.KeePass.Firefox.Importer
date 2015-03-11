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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using WebSiteAdvantage.KeePass.Firefox;
using WebSiteAdvantage.KeePass.Firefox.Importer;
using KeePassLib;

namespace WebSiteAdvantageKeePassFirefoxImporter
{
	public partial class FormXml : Form
    {
        public FormXml()
        {
            InitializeComponent();

			this.comboBoxIconName.SelectedIndex = 16;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		public string IconName
		{
			get { return this.comboBoxIconName.SelectedItem.ToString(); }
		}

		public PwGroup Group
		{
			get
			{
				return ((KeePassHelper.GroupItem)this.comboBoxGroup.SelectedItem).Group;
			}
		}

        public bool GetTitles
        {
            get
            {
                return this.checkBoxTitle.Checked;
            }
        }
        public bool IncludeImportNotes
        {
            get
            {
                return this.checkBoxIncludeImportNotes.Checked;
            }
        }
        public bool AddAutoType
        {
            get
            {
                return this.checkBoxAutoType.Checked;
            }
        }
        public bool Merge
        {
            get
            {
                return this.checkBoxCheckExisting.Checked;
            }
        }
        public bool Overwrite
        {
            get
            {
                return this.checkBoxOverwite.Checked;
            }
        }



		private void Form1_Load(object sender, EventArgs e)
		{
            this.Text = "Web Site Advantage Firefox to KeePass Importer (" + KeePassUtilities.Version + ")";
		}

		public void Initialise(PwDatabase pwStorage)
		{
			KeePassHelper.InitialiseGroupComboBox(this.comboBoxGroup, pwStorage);
		}



		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=link&utm_campaign=importer-" + KeePassUtilities.Version);
		}

		private void checkBoxTitle_CheckedChanged(object sender, EventArgs e)
		{
	//		this.checkBoxAutoType.Enabled = this.checkBoxTitle.Checked;
		}

		private void checkBoxCheckExisting_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBoxOverwite.Enabled = this.checkBoxCheckExisting.Checked;
		}

		private void buttonHelp_Click(object sender, EventArgs e)
		{
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=help&utm_campaign=importer-" + KeePassUtilities.Version);

		}


		private void linkLabelExporter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://addons.mozilla.org/en-US/firefox/addon/2848");
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=help&utm_campaign=importerdonate-" + KeePassUtilities.Version);

        }
       
    }
}