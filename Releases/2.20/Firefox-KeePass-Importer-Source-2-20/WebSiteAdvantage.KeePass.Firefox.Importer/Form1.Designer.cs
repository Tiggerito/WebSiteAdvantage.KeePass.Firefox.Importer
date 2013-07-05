namespace WebSiteAdvantageKeePassFirefoxImporter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBoxOverwite = new System.Windows.Forms.CheckBox();
            this.checkBoxCheckExisting = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxTitle = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxFirefox = new System.Windows.Forms.GroupBox();
            this.buttonFindProfiles = new System.Windows.Forms.Button();
            this.comboBoxProfile = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.checkBoxIncludeImportNotes = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoType = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.comboBoxIconName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxFirefox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(459, 535);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(65, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 442);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBoxFirefox);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.checkBoxOverwite);
            this.groupBox6.Controls.Add(this.checkBoxCheckExisting);
            this.groupBox6.Location = new System.Drawing.Point(3, 336);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(490, 72);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Merging";
            // 
            // checkBoxOverwite
            // 
            this.checkBoxOverwite.AutoSize = true;
            this.checkBoxOverwite.Location = new System.Drawing.Point(15, 44);
            this.checkBoxOverwite.Name = "checkBoxOverwite";
            this.checkBoxOverwite.Size = new System.Drawing.Size(236, 17);
            this.checkBoxOverwite.TabIndex = 1;
            this.checkBoxOverwite.Text = "Overwrite passwords (requires above check)";
            this.checkBoxOverwite.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheckExisting
            // 
            this.checkBoxCheckExisting.AutoSize = true;
            this.checkBoxCheckExisting.Checked = true;
            this.checkBoxCheckExisting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCheckExisting.Location = new System.Drawing.Point(15, 20);
            this.checkBoxCheckExisting.Name = "checkBoxCheckExisting";
            this.checkBoxCheckExisting.Size = new System.Drawing.Size(144, 17);
            this.checkBoxCheckExisting.TabIndex = 0;
            this.checkBoxCheckExisting.Text = "Check for existing entries";
            this.checkBoxCheckExisting.UseVisualStyleBackColor = true;
            this.checkBoxCheckExisting.CheckedChanged += new System.EventHandler(this.checkBoxCheckExisting_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.checkBoxTitle);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Location = new System.Drawing.Point(3, 238);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(490, 92);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Internet Access";
            // 
            // checkBoxTitle
            // 
            this.checkBoxTitle.AutoSize = true;
            this.checkBoxTitle.Location = new System.Drawing.Point(15, 19);
            this.checkBoxTitle.Name = "checkBoxTitle";
            this.checkBoxTitle.Size = new System.Drawing.Size(138, 17);
            this.checkBoxTitle.TabIndex = 0;
            this.checkBoxTitle.Text = "Get Titles from websites";
            this.checkBoxTitle.UseVisualStyleBackColor = true;
            this.checkBoxTitle.CheckedChanged += new System.EventHandler(this.checkBoxTitle_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(326, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 62);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Warning";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 43);
            this.label1.TabIndex = 20;
            this.label1.Text = "You have to trust me if you allow this plugin to access the internet!";
            // 
            // groupBoxFirefox
            // 
            this.groupBoxFirefox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFirefox.Controls.Add(this.buttonFindProfiles);
            this.groupBoxFirefox.Controls.Add(this.comboBoxProfile);
            this.groupBoxFirefox.Controls.Add(this.label3);
            this.groupBoxFirefox.Controls.Add(this.pictureBox1);
            this.groupBoxFirefox.Controls.Add(this.label6);
            this.groupBoxFirefox.Controls.Add(this.label2);
            this.groupBoxFirefox.Controls.Add(this.textBoxPassword);
            this.groupBoxFirefox.Location = new System.Drawing.Point(3, 6);
            this.groupBoxFirefox.Name = "groupBoxFirefox";
            this.groupBoxFirefox.Size = new System.Drawing.Size(491, 109);
            this.groupBoxFirefox.TabIndex = 27;
            this.groupBoxFirefox.TabStop = false;
            this.groupBoxFirefox.Text = "Firefox";
            // 
            // buttonFindProfiles
            // 
            this.buttonFindProfiles.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.openfolderHS;
            this.buttonFindProfiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFindProfiles.Location = new System.Drawing.Point(257, 19);
            this.buttonFindProfiles.Name = "buttonFindProfiles";
            this.buttonFindProfiles.Size = new System.Drawing.Size(133, 23);
            this.buttonFindProfiles.TabIndex = 1;
            this.buttonFindProfiles.Text = "Load More Profiles...";
            this.buttonFindProfiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonFindProfiles.UseVisualStyleBackColor = true;
            this.buttonFindProfiles.Click += new System.EventHandler(this.buttonFindProfiles_Click);
            // 
            // comboBoxProfile
            // 
            this.comboBoxProfile.FormattingEnabled = true;
            this.comboBoxProfile.Location = new System.Drawing.Point(106, 19);
            this.comboBoxProfile.Name = "comboBoxProfile";
            this.comboBoxProfile.Size = new System.Drawing.Size(145, 21);
            this.comboBoxProfile.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Profile";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.firefox_128_509;
            this.pictureBox1.Location = new System.Drawing.Point(396, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "(required if you have set a master password in firefox)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Master Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(106, 46);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(284, 20);
            this.textBoxPassword.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.comboBoxGroup);
            this.groupBox3.Controls.Add(this.checkBoxIncludeImportNotes);
            this.groupBox3.Controls.Add(this.checkBoxAutoType);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.comboBoxIconName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.labelGroup);
            this.groupBox3.Location = new System.Drawing.Point(3, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 111);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KeePass";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(107, 14);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(282, 21);
            this.comboBoxGroup.TabIndex = 0;
            // 
            // checkBoxIncludeImportNotes
            // 
            this.checkBoxIncludeImportNotes.AutoSize = true;
            this.checkBoxIncludeImportNotes.Checked = true;
            this.checkBoxIncludeImportNotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeImportNotes.Location = new System.Drawing.Point(153, 88);
            this.checkBoxIncludeImportNotes.Name = "checkBoxIncludeImportNotes";
            this.checkBoxIncludeImportNotes.Size = new System.Drawing.Size(124, 17);
            this.checkBoxIncludeImportNotes.TabIndex = 3;
            this.checkBoxIncludeImportNotes.Text = "Include Import Notes";
            this.checkBoxIncludeImportNotes.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoType
            // 
            this.checkBoxAutoType.AutoSize = true;
            this.checkBoxAutoType.Checked = true;
            this.checkBoxAutoType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoType.Location = new System.Drawing.Point(16, 88);
            this.checkBoxAutoType.Name = "checkBoxAutoType";
            this.checkBoxAutoType.Size = new System.Drawing.Size(131, 17);
            this.checkBoxAutoType.TabIndex = 2;
            this.checkBoxAutoType.Text = "Add Auto-Type entries";
            this.checkBoxAutoType.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.keepasslogo_512;
            this.pictureBox2.Location = new System.Drawing.Point(395, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // comboBoxIconName
            // 
            this.comboBoxIconName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIconName.FormattingEnabled = true;
            this.comboBoxIconName.Items.AddRange(new object[] {
            "Key",
            "World",
            "Warning",
            "NetworkServer",
            "MarkedDirectory",
            "UserCommunication",
            "Parts",
            "Notepad",
            "WorldSocket",
            "Identity",
            "PaperReady",
            "Digicam",
            "IRCommunication",
            "MultiKeys",
            "Energy",
            "Scanner",
            "WorldStar",
            "CdRom",
            "Monitor",
            "EMail",
            "Configuration",
            "ClipboardReady",
            "PaperNew",
            "Screen",
            "EnergyCareful",
            "EMailBox",
            "Disk",
            "Drive",
            "PaperQ",
            "TerminalEncrypted",
            "Console",
            "Printer",
            "ProgramIcons",
            "Run",
            "Settings",
            "WorldComputer ",
            "Archive",
            "Homebanking",
            "DriveWindows",
            "Clock",
            "EMailSearch",
            "PaperFlag",
            "Memory",
            "TrashBin",
            "Note",
            "Expired",
            "Info",
            "Package",
            "Folder",
            "FolderOpen",
            "FolderPackage",
            "LockOpen",
            "PaperLocked",
            "Checked",
            "Pen",
            "Thumbnail",
            "Book",
            "List",
            "UserKey",
            "Tool",
            "Home",
            "Star",
            "None",
            "SortUpArrow",
            "SortDownArrow",
            "Count"});
            this.comboBoxIconName.Location = new System.Drawing.Point(107, 43);
            this.comboBoxIconName.Name = "comboBoxIconName";
            this.comboBoxIconName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIconName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Icon";
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(13, 22);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(36, 13);
            this.labelGroup.TabIndex = 0;
            this.labelGroup.Text = "Group";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(485, 22);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 26;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Home";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(496, 54);
            this.label8.TabIndex = 0;
            this.label8.Text = "This tool will import passwords stored in Firefox.\r\n";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(511, 69);
            this.listBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.beer3;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(83, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Buy me a Beer...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHelp.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.Help;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(12, 536);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(65, 23);
            this.buttonHelp.TabIndex = 31;
            this.buttonHelp.Text = "Help...";
            this.buttonHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonStart.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.FormRunHS;
            this.ButtonStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStart.Location = new System.Drawing.Point(351, 535);
            this.ButtonStart.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(103, 24);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 570);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(544, 581);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Site Advantage Firefox to KeePass Importer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxFirefox.ResumeLayout(false);
            this.groupBoxFirefox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBoxFirefox;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.CheckBox checkBoxCheckExisting;
		private System.Windows.Forms.CheckBox checkBoxAutoType;
		private System.Windows.Forms.CheckBox checkBoxTitle;
		private System.Windows.Forms.Label labelGroup;
		private System.Windows.Forms.CheckBox checkBoxOverwite;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxIconName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button buttonHelp;
		private System.Windows.Forms.ComboBox comboBoxProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonFindProfiles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxIncludeImportNotes;
		private System.Windows.Forms.ComboBox comboBoxGroup;
    }
}