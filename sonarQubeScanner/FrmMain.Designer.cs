namespace sonarQubeScanner
{
    partial class FrmMain
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
            this.tab_Main = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lab_ProjectFolder = new System.Windows.Forms.Label();
            this.txt_ScannerLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_SourceEncoding = new System.Windows.Forms.TextBox();
            this.txt_Language = new System.Windows.Forms.TextBox();
            this.txt_ProjectVersion = new System.Windows.Forms.TextBox();
            this.txt_Source = new System.Windows.Forms.TextBox();
            this.txt_ProjectName = new System.Windows.Forms.TextBox();
            this.lab_SourceEncoding = new System.Windows.Forms.Label();
            this.txt_ProjectKey = new System.Windows.Forms.TextBox();
            this.lab_Language = new System.Windows.Forms.Label();
            this.lab_ProjectVersion = new System.Windows.Forms.Label();
            this.lab_source = new System.Windows.Forms.Label();
            this.lab_ProjectName = new System.Windows.Forms.Label();
            this.lab_ProjectKey = new System.Windows.Forms.Label();
            this.cmd_OpenProjectFolder = new System.Windows.Forms.Button();
            this.txt_ProjectFolder = new System.Windows.Forms.TextBox();
            this.btn_runner = new System.Windows.Forms.Button();
            this.folderBrowserDialog_ProjectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tab_Main.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.tabPage2);
            this.tab_Main.Location = new System.Drawing.Point(12, 12);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.SelectedIndex = 0;
            this.tab_Main.Size = new System.Drawing.Size(765, 563);
            this.tab_Main.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lab_ProjectFolder);
            this.tabPage2.Controls.Add(this.txt_ScannerLog);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.cmd_OpenProjectFolder);
            this.tabPage2.Controls.Add(this.txt_ProjectFolder);
            this.tabPage2.Controls.Add(this.btn_runner);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(757, 537);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "sonarScanner";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lab_ProjectFolder
            // 
            this.lab_ProjectFolder.AutoSize = true;
            this.lab_ProjectFolder.Location = new System.Drawing.Point(10, 11);
            this.lab_ProjectFolder.Name = "lab_ProjectFolder";
            this.lab_ProjectFolder.Size = new System.Drawing.Size(89, 12);
            this.lab_ProjectFolder.TabIndex = 7;
            this.lab_ProjectFolder.Text = "Project Folder";
            // 
            // txt_ScannerLog
            // 
            this.txt_ScannerLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ScannerLog.Location = new System.Drawing.Point(6, 144);
            this.txt_ScannerLog.Name = "txt_ScannerLog";
            this.txt_ScannerLog.Size = new System.Drawing.Size(740, 358);
            this.txt_ScannerLog.TabIndex = 6;
            this.txt_ScannerLog.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_SourceEncoding);
            this.panel1.Controls.Add(this.txt_Language);
            this.panel1.Controls.Add(this.txt_ProjectVersion);
            this.panel1.Controls.Add(this.txt_Source);
            this.panel1.Controls.Add(this.txt_ProjectName);
            this.panel1.Controls.Add(this.lab_SourceEncoding);
            this.panel1.Controls.Add(this.txt_ProjectKey);
            this.panel1.Controls.Add(this.lab_Language);
            this.panel1.Controls.Add(this.lab_ProjectVersion);
            this.panel1.Controls.Add(this.lab_source);
            this.panel1.Controls.Add(this.lab_ProjectName);
            this.panel1.Controls.Add(this.lab_ProjectKey);
            this.panel1.Location = new System.Drawing.Point(6, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 92);
            this.panel1.TabIndex = 3;
            // 
            // txt_SourceEncoding
            // 
            this.txt_SourceEncoding.Location = new System.Drawing.Point(477, 64);
            this.txt_SourceEncoding.Name = "txt_SourceEncoding";
            this.txt_SourceEncoding.Size = new System.Drawing.Size(263, 21);
            this.txt_SourceEncoding.TabIndex = 9;
            this.txt_SourceEncoding.Text = "UTF-8";
            // 
            // txt_Language
            // 
            this.txt_Language.Location = new System.Drawing.Point(477, 35);
            this.txt_Language.Name = "txt_Language";
            this.txt_Language.Size = new System.Drawing.Size(263, 21);
            this.txt_Language.TabIndex = 9;
            this.txt_Language.Text = "cs";
            // 
            // txt_ProjectVersion
            // 
            this.txt_ProjectVersion.Location = new System.Drawing.Point(99, 64);
            this.txt_ProjectVersion.Name = "txt_ProjectVersion";
            this.txt_ProjectVersion.Size = new System.Drawing.Size(263, 21);
            this.txt_ProjectVersion.TabIndex = 9;
            this.txt_ProjectVersion.Text = "1.0";
            // 
            // txt_Source
            // 
            this.txt_Source.Location = new System.Drawing.Point(477, 7);
            this.txt_Source.Name = "txt_Source";
            this.txt_Source.Size = new System.Drawing.Size(263, 21);
            this.txt_Source.TabIndex = 9;
            this.txt_Source.Text = ".";
            // 
            // txt_ProjectName
            // 
            this.txt_ProjectName.Location = new System.Drawing.Point(99, 35);
            this.txt_ProjectName.Name = "txt_ProjectName";
            this.txt_ProjectName.Size = new System.Drawing.Size(263, 21);
            this.txt_ProjectName.TabIndex = 9;
            this.txt_ProjectName.Text = "sonarScannerForEsquel";
            // 
            // lab_SourceEncoding
            // 
            this.lab_SourceEncoding.AutoSize = true;
            this.lab_SourceEncoding.Location = new System.Drawing.Point(382, 67);
            this.lab_SourceEncoding.Name = "lab_SourceEncoding";
            this.lab_SourceEncoding.Size = new System.Drawing.Size(95, 12);
            this.lab_SourceEncoding.TabIndex = 8;
            this.lab_SourceEncoding.Text = "Source Encoding";
            // 
            // txt_ProjectKey
            // 
            this.txt_ProjectKey.Location = new System.Drawing.Point(99, 7);
            this.txt_ProjectKey.Name = "txt_ProjectKey";
            this.txt_ProjectKey.Size = new System.Drawing.Size(263, 21);
            this.txt_ProjectKey.TabIndex = 9;
            this.txt_ProjectKey.Text = "sonarScannerForEsquel";
            // 
            // lab_Language
            // 
            this.lab_Language.AutoSize = true;
            this.lab_Language.Location = new System.Drawing.Point(382, 38);
            this.lab_Language.Name = "lab_Language";
            this.lab_Language.Size = new System.Drawing.Size(53, 12);
            this.lab_Language.TabIndex = 8;
            this.lab_Language.Text = "Language";
            // 
            // lab_ProjectVersion
            // 
            this.lab_ProjectVersion.AutoSize = true;
            this.lab_ProjectVersion.Location = new System.Drawing.Point(4, 67);
            this.lab_ProjectVersion.Name = "lab_ProjectVersion";
            this.lab_ProjectVersion.Size = new System.Drawing.Size(95, 12);
            this.lab_ProjectVersion.TabIndex = 8;
            this.lab_ProjectVersion.Text = "Project Version";
            // 
            // lab_source
            // 
            this.lab_source.AutoSize = true;
            this.lab_source.Location = new System.Drawing.Point(382, 10);
            this.lab_source.Name = "lab_source";
            this.lab_source.Size = new System.Drawing.Size(41, 12);
            this.lab_source.TabIndex = 8;
            this.lab_source.Text = "Source";
            // 
            // lab_ProjectName
            // 
            this.lab_ProjectName.AutoSize = true;
            this.lab_ProjectName.Location = new System.Drawing.Point(4, 38);
            this.lab_ProjectName.Name = "lab_ProjectName";
            this.lab_ProjectName.Size = new System.Drawing.Size(77, 12);
            this.lab_ProjectName.TabIndex = 8;
            this.lab_ProjectName.Text = "Project Name";
            // 
            // lab_ProjectKey
            // 
            this.lab_ProjectKey.AutoSize = true;
            this.lab_ProjectKey.Location = new System.Drawing.Point(4, 10);
            this.lab_ProjectKey.Name = "lab_ProjectKey";
            this.lab_ProjectKey.Size = new System.Drawing.Size(71, 12);
            this.lab_ProjectKey.TabIndex = 8;
            this.lab_ProjectKey.Text = "Project Key";
            // 
            // cmd_OpenProjectFolder
            // 
            this.cmd_OpenProjectFolder.Location = new System.Drawing.Point(637, 8);
            this.cmd_OpenProjectFolder.Name = "cmd_OpenProjectFolder";
            this.cmd_OpenProjectFolder.Size = new System.Drawing.Size(109, 23);
            this.cmd_OpenProjectFolder.TabIndex = 2;
            this.cmd_OpenProjectFolder.Text = "Project Folder";
            this.cmd_OpenProjectFolder.UseVisualStyleBackColor = true;
            this.cmd_OpenProjectFolder.Click += new System.EventHandler(this.cmd_OpenProjectFolder_Click);
            // 
            // txt_ProjectFolder
            // 
            this.txt_ProjectFolder.Enabled = false;
            this.txt_ProjectFolder.Location = new System.Drawing.Point(105, 8);
            this.txt_ProjectFolder.Name = "txt_ProjectFolder";
            this.txt_ProjectFolder.Size = new System.Drawing.Size(526, 21);
            this.txt_ProjectFolder.TabIndex = 1;
            this.txt_ProjectFolder.Text = "F:\\test\\sonarQubeScanner\\sonarQubeScanner";
            // 
            // btn_runner
            // 
            this.btn_runner.Location = new System.Drawing.Point(645, 508);
            this.btn_runner.Name = "btn_runner";
            this.btn_runner.Size = new System.Drawing.Size(106, 23);
            this.btn_runner.TabIndex = 0;
            this.btn_runner.Text = "Run";
            this.btn_runner.UseVisualStyleBackColor = true;
            this.btn_runner.Click += new System.EventHandler(this.btn_runner_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 587);
            this.Controls.Add(this.tab_Main);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "sonarQube Scanner For .Net Tools";
            this.tab_Main.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Main;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_runner;
        private System.Windows.Forms.Button cmd_OpenProjectFolder;
        private System.Windows.Forms.TextBox txt_ProjectFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txt_ScannerLog;
        private System.Windows.Forms.Label lab_ProjectFolder;
        private System.Windows.Forms.TextBox txt_ProjectVersion;
        private System.Windows.Forms.TextBox txt_ProjectName;
        private System.Windows.Forms.TextBox txt_ProjectKey;
        private System.Windows.Forms.Label lab_ProjectVersion;
        private System.Windows.Forms.Label lab_ProjectName;
        private System.Windows.Forms.Label lab_ProjectKey;
        private System.Windows.Forms.TextBox txt_SourceEncoding;
        private System.Windows.Forms.TextBox txt_Language;
        private System.Windows.Forms.TextBox txt_Source;
        private System.Windows.Forms.Label lab_SourceEncoding;
        private System.Windows.Forms.Label lab_Language;
        private System.Windows.Forms.Label lab_source;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_ProjectFolder;

    }
}

