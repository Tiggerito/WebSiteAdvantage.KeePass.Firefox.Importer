using WebSiteAdvantage.KeePass.Firefox.Converter.Properties;
namespace WebSiteAdvantage.KeePass.FireFoxConverter
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
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.linkLabelExporter = new System.Windows.Forms.LinkLabel();
            this.radioButtonImport = new System.Windows.Forms.RadioButton();
            this.radioButtonUseFirefox = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxTitle = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxIncludeImportNotes = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoType = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.comboBoxIconName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxFirefox = new System.Windows.Forms.GroupBox();
            this.buttonFindProfiles = new System.Windows.Forms.Button();
            this.comboBoxProfile = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBoxFirefox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.Location = new System.Drawing.Point(106, 18);
            this.textBoxGroup.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.Size = new System.Drawing.Size(113, 20);
            this.textBoxGroup.TabIndex = 12;
            this.textBoxGroup.Text = "General";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Group";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 101);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 443);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBoxFirefox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.linkLabelExporter);
            this.groupBox6.Controls.Add(this.radioButtonImport);
            this.groupBox6.Controls.Add(this.radioButtonUseFirefox);
            this.groupBox6.Location = new System.Drawing.Point(3, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(492, 81);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Method";
            // 
            // linkLabelExporter
            // 
            this.linkLabelExporter.AutoSize = true;
            this.linkLabelExporter.Location = new System.Drawing.Point(263, 46);
            this.linkLabelExporter.Name = "linkLabelExporter";
            this.linkLabelExporter.Size = new System.Drawing.Size(178, 13);
            this.linkLabelExporter.TabIndex = 2;
            this.linkLabelExporter.TabStop = true;
            this.linkLabelExporter.Text = "Firefox Password Exporter Extension";
            this.linkLabelExporter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelExporter_LinkClicked);
            // 
            // radioButtonImport
            // 
            this.radioButtonImport.AutoSize = true;
            this.radioButtonImport.Location = new System.Drawing.Point(15, 44);
            this.radioButtonImport.Name = "radioButtonImport";
            this.radioButtonImport.Size = new System.Drawing.Size(257, 17);
            this.radioButtonImport.TabIndex = 1;
            this.radioButtonImport.Text = "Read the data from a password file generated by ";
            this.radioButtonImport.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseFirefox
            // 
            this.radioButtonUseFirefox.AutoSize = true;
            this.radioButtonUseFirefox.Checked = true;
            this.radioButtonUseFirefox.Location = new System.Drawing.Point(15, 20);
            this.radioButtonUseFirefox.Name = "radioButtonUseFirefox";
            this.radioButtonUseFirefox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButtonUseFirefox.Size = new System.Drawing.Size(204, 17);
            this.radioButtonUseFirefox.TabIndex = 0;
            this.radioButtonUseFirefox.TabStop = true;
            this.radioButtonUseFirefox.Text = "Directly use Firefox to gather the data.";
            this.radioButtonUseFirefox.UseVisualStyleBackColor = true;
            this.radioButtonUseFirefox.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.checkBoxTitle);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Location = new System.Drawing.Point(3, 316);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(492, 92);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Internet Access";
            // 
            // checkBoxTitle
            // 
            this.checkBoxTitle.AutoSize = true;
            this.checkBoxTitle.Location = new System.Drawing.Point(20, 19);
            this.checkBoxTitle.Name = "checkBoxTitle";
            this.checkBoxTitle.Size = new System.Drawing.Size(156, 17);
            this.checkBoxTitle.TabIndex = 24;
            this.checkBoxTitle.Text = "Get Titles from the websites";
            this.checkBoxTitle.UseVisualStyleBackColor = true;
            this.checkBoxTitle.CheckedChanged += new System.EventHandler(this.checkBoxTitle_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(327, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 62);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Warning";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(3, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 43);
            this.label7.TabIndex = 20;
            this.label7.Text = "You have to trust me if you allow this plugin to access the internet!";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBoxIncludeImportNotes);
            this.groupBox3.Controls.Add(this.checkBoxAutoType);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.comboBoxIconName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxGroup);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(3, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(492, 102);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KeePass";
            // 
            // checkBoxIncludeImportNotes
            // 
            this.checkBoxIncludeImportNotes.AutoSize = true;
            this.checkBoxIncludeImportNotes.Checked = true;
            this.checkBoxIncludeImportNotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeImportNotes.Location = new System.Drawing.Point(157, 79);
            this.checkBoxIncludeImportNotes.Name = "checkBoxIncludeImportNotes";
            this.checkBoxIncludeImportNotes.Size = new System.Drawing.Size(124, 17);
            this.checkBoxIncludeImportNotes.TabIndex = 34;
            this.checkBoxIncludeImportNotes.Text = "Include Import Notes";
            this.checkBoxIncludeImportNotes.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoType
            // 
            this.checkBoxAutoType.AutoSize = true;
            this.checkBoxAutoType.Checked = true;
            this.checkBoxAutoType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoType.Location = new System.Drawing.Point(20, 79);
            this.checkBoxAutoType.Name = "checkBoxAutoType";
            this.checkBoxAutoType.Size = new System.Drawing.Size(131, 17);
            this.checkBoxAutoType.TabIndex = 25;
            this.checkBoxAutoType.Text = "Add Auto Type entries";
            this.checkBoxAutoType.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "(created by KeePass if unknown)";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.keepasslogo_512;
            this.pictureBox2.Location = new System.Drawing.Point(394, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 32;
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
            this.comboBoxIconName.Location = new System.Drawing.Point(106, 43);
            this.comboBoxIconName.Name = "comboBoxIconName";
            this.comboBoxIconName.Size = new System.Drawing.Size(113, 21);
            this.comboBoxIconName.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Icon";
            // 
            // groupBoxFirefox
            // 
            this.groupBoxFirefox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFirefox.Controls.Add(this.buttonFindProfiles);
            this.groupBoxFirefox.Controls.Add(this.comboBoxProfile);
            this.groupBoxFirefox.Controls.Add(this.label5);
            this.groupBoxFirefox.Controls.Add(this.pictureBox1);
            this.groupBoxFirefox.Controls.Add(this.label1);
            this.groupBoxFirefox.Controls.Add(this.label6);
            this.groupBoxFirefox.Controls.Add(this.textBoxPassword);
            this.groupBoxFirefox.Location = new System.Drawing.Point(3, 93);
            this.groupBoxFirefox.Name = "groupBoxFirefox";
            this.groupBoxFirefox.Size = new System.Drawing.Size(492, 109);
            this.groupBoxFirefox.TabIndex = 28;
            this.groupBoxFirefox.TabStop = false;
            this.groupBoxFirefox.Text = "Firefox";
            // 
            // buttonFindProfiles
            // 
            this.buttonFindProfiles.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.openfolderHS;
            this.buttonFindProfiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFindProfiles.Location = new System.Drawing.Point(258, 19);
            this.buttonFindProfiles.Name = "buttonFindProfiles";
            this.buttonFindProfiles.Size = new System.Drawing.Size(130, 23);
            this.buttonFindProfiles.TabIndex = 34;
            this.buttonFindProfiles.Text = "Load More Profiles...";
            this.buttonFindProfiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonFindProfiles.UseVisualStyleBackColor = true;
            this.buttonFindProfiles.Click += new System.EventHandler(this.buttonFindProfiles_Click);
            // 
            // comboBoxProfile
            // 
            this.comboBoxProfile.FormattingEnabled = true;
            this.comboBoxProfile.Location = new System.Drawing.Point(100, 19);
            this.comboBoxProfile.Name = "comboBoxProfile";
            this.comboBoxProfile.Size = new System.Drawing.Size(152, 21);
            this.comboBoxProfile.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Profile";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.firefox_128_509;
            this.pictureBox1.Location = new System.Drawing.Point(394, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "(required if you have set a master password in firefox)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Master Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(100, 46);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(288, 20);
            this.textBoxPassword.TabIndex = 21;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(469, 581);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(55, 23);
            this.buttonCancel.TabIndex = 21;
            this.buttonCancel.Text = "Close";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(476, 73);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 27;
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
            this.label8.Location = new System.Drawing.Point(20, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(491, 51);
            this.label8.TabIndex = 0;
            this.label8.Text = "This tool will read password data stored in Firefox and create a file suitable fo" +
                "r importing into KeePass using the XML import plugin.";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(511, 82);
            this.listBox1.TabIndex = 29;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 550);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(508, 23);
            this.progressBar1.TabIndex = 31;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(21, 73);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(138, 13);
            this.linkLabel2.TabIndex = 32;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "KeePass XML Import Plugin";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.beer3;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(76, 581);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Buy me a Beer...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHelp.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.Help;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(12, 581);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(60, 23);
            this.buttonHelp.TabIndex = 30;
            this.buttonHelp.Text = "Help...";
            this.buttonHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.FormRunHS;
            this.buttonGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenerate.Location = new System.Drawing.Point(352, 581);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(112, 23);
            this.buttonGenerate.TabIndex = 16;
            this.buttonGenerate.Text = "Start";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 615);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(544, 621);
            this.Name = "Form1";
            this.Text = "Web Site Advantage Firefox to KeePass Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBoxFirefox.ResumeLayout(false);
            this.groupBoxFirefox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox textBoxGroup;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonGenerate;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBoxFirefox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ComboBox comboBoxIconName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox checkBoxAutoType;
		private System.Windows.Forms.CheckBox checkBoxTitle;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.RadioButton radioButtonImport;
		private System.Windows.Forms.RadioButton radioButtonUseFirefox;
		private System.Windows.Forms.LinkLabel linkLabelExporter;
		private System.Windows.Forms.Button buttonHelp;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.ComboBox comboBoxProfile;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonFindProfiles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxIncludeImportNotes;
    }
}

