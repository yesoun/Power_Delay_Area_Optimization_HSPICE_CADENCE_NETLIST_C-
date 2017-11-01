namespace PDAOptFramework
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
            this.bChooseNotelist = new System.Windows.Forms.Button();
            this.openFileDialogNetlis = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.NetlistFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bChooseCMOSmodel = new System.Windows.Forms.Button();
            this.NMOSMODEPATH = new System.Windows.Forms.TextBox();
            this.openFileNMOSmodel = new System.Windows.Forms.OpenFileDialog();
            this.openFilePMOSMODELFILE = new System.Windows.Forms.OpenFileDialog();
            this.textBoxTemperature = new System.Windows.Forms.TextBox();
            this.TEMPERATURE = new System.Windows.Forms.Label();
            this.buttonNEXT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxMachine = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSSHdirectory = new System.Windows.Forms.Button();
            this.openFileSSHdirectory = new System.Windows.Forms.OpenFileDialog();
            this.textBoxSSHDirectory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bChooseNotelist
            // 
            this.bChooseNotelist.Location = new System.Drawing.Point(98, 74);
            this.bChooseNotelist.Name = "bChooseNotelist";
            this.bChooseNotelist.Size = new System.Drawing.Size(75, 25);
            this.bChooseNotelist.TabIndex = 0;
            this.bChooseNotelist.Text = "Netliste File";
            this.bChooseNotelist.UseVisualStyleBackColor = true;
            this.bChooseNotelist.Click += new System.EventHandler(this.bChooseNotelist_Click);
            // 
            // openFileDialogNetlis
            // 
            this.openFileDialogNetlis.FileName = "openFileDialogNetlis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NETLIST FILE";
            // 
            // NetlistFilePath
            // 
            this.NetlistFilePath.Location = new System.Drawing.Point(179, 74);
            this.NetlistFilePath.Name = "NetlistFilePath";
            this.NetlistFilePath.Size = new System.Drawing.Size(129, 20);
            this.NetlistFilePath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CMOS MODEL";
            // 
            // bChooseCMOSmodel
            // 
            this.bChooseCMOSmodel.Location = new System.Drawing.Point(98, 146);
            this.bChooseCMOSmodel.Name = "bChooseCMOSmodel";
            this.bChooseCMOSmodel.Size = new System.Drawing.Size(75, 21);
            this.bChooseCMOSmodel.TabIndex = 4;
            this.bChooseCMOSmodel.Text = "Choose";
            this.bChooseCMOSmodel.UseVisualStyleBackColor = true;
            this.bChooseCMOSmodel.Click += new System.EventHandler(this.bChooseCMOSmodel_Click);
            // 
            // NMOSMODEPATH
            // 
            this.NMOSMODEPATH.Location = new System.Drawing.Point(179, 146);
            this.NMOSMODEPATH.Name = "NMOSMODEPATH";
            this.NMOSMODEPATH.Size = new System.Drawing.Size(130, 20);
            this.NMOSMODEPATH.TabIndex = 5;
            // 
            // openFileNMOSmodel
            // 
            this.openFileNMOSmodel.FileName = "openFileNMOSmodel";
            // 
            // openFilePMOSMODELFILE
            // 
            this.openFilePMOSMODELFILE.FileName = "openFilePMOSMODELFILE";
            // 
            // textBoxTemperature
            // 
            this.textBoxTemperature.Location = new System.Drawing.Point(120, 200);
            this.textBoxTemperature.Name = "textBoxTemperature";
            this.textBoxTemperature.Size = new System.Drawing.Size(103, 20);
            this.textBoxTemperature.TabIndex = 9;
            this.textBoxTemperature.TextChanged += new System.EventHandler(this.textBoxTemperature_TextChanged);
            // 
            // TEMPERATURE
            // 
            this.TEMPERATURE.AutoSize = true;
            this.TEMPERATURE.Location = new System.Drawing.Point(12, 203);
            this.TEMPERATURE.Name = "TEMPERATURE";
            this.TEMPERATURE.Size = new System.Drawing.Size(89, 13);
            this.TEMPERATURE.TabIndex = 10;
            this.TEMPERATURE.Text = "TEMPERATURE";
            // 
            // buttonNEXT
            // 
            this.buttonNEXT.Location = new System.Drawing.Point(364, 417);
            this.buttonNEXT.Name = "buttonNEXT";
            this.buttonNEXT.Size = new System.Drawing.Size(75, 23);
            this.buttonNEXT.TabIndex = 11;
            this.buttonNEXT.Text = "NEXT";
            this.buttonNEXT.UseVisualStyleBackColor = true;
            this.buttonNEXT.Click += new System.EventHandler(this.buttonNEXT_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "User Name";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(474, 69);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(121, 20);
            this.textBoxUserName.TabIndex = 13;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(384, 134);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 14;
            this.Password.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(474, 126);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 15;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Machine Name";
            // 
            // listBoxMachine
            // 
            this.listBoxMachine.FormattingEnabled = true;
            this.listBoxMachine.Items.AddRange(new object[] {
            "p218inst10 ",
            "p218inst11 ",
            "p218inst12 ",
            "p218inst13 ",
            "p218inst14",
            "p218inst15 ",
            "p218inst16 ",
            "p218inst17 ",
            "p218inst18    ",
            "p218inst19",
            "p218inst20 ",
            "p218inst21 ",
            "p218inst22 ",
            "p218inst23 ",
            "p218inst24",
            "p218inst25 ",
            "p218inst26 ",
            "p218inst27 ",
            "p218inst28 ",
            "p218inst29",
            "p218inst30 ",
            "p218inst31 ",
            "p218inst32 ",
            "p218inst33"});
            this.listBoxMachine.Location = new System.Drawing.Point(483, 195);
            this.listBoxMachine.Name = "listBoxMachine";
            this.listBoxMachine.Size = new System.Drawing.Size(131, 69);
            this.listBoxMachine.TabIndex = 17;
            this.listBoxMachine.SelectedIndexChanged += new System.EventHandler(this.listBoxMachine_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "SSH Directory :";
            // 
            // buttonSSHdirectory
            // 
            this.buttonSSHdirectory.Location = new System.Drawing.Point(483, 306);
            this.buttonSSHdirectory.Name = "buttonSSHdirectory";
            this.buttonSSHdirectory.Size = new System.Drawing.Size(130, 21);
            this.buttonSSHdirectory.TabIndex = 19;
            this.buttonSSHdirectory.Text = "choose ssh dir";
            this.buttonSSHdirectory.UseVisualStyleBackColor = true;
            this.buttonSSHdirectory.Click += new System.EventHandler(this.buttonSSHdirectory_Click);
            // 
            // openFileSSHdirectory
            // 
            this.openFileSSHdirectory.FileName = "openFileSShdirectory";
            // 
            // textBoxSSHDirectory
            // 
            this.textBoxSSHDirectory.Location = new System.Drawing.Point(624, 305);
            this.textBoxSSHDirectory.Name = "textBoxSSHDirectory";
            this.textBoxSSHDirectory.Size = new System.Drawing.Size(76, 20);
            this.textBoxSSHDirectory.TabIndex = 20;
            this.textBoxSSHDirectory.TextChanged += new System.EventHandler(this.textBoxSSHDirectory_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 467);
            this.Controls.Add(this.textBoxSSHDirectory);
            this.Controls.Add(this.buttonSSHdirectory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxMachine);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonNEXT);
            this.Controls.Add(this.TEMPERATURE);
            this.Controls.Add(this.textBoxTemperature);
            this.Controls.Add(this.NMOSMODEPATH);
            this.Controls.Add(this.bChooseCMOSmodel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NetlistFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bChooseNotelist);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bChooseNotelist;
        private System.Windows.Forms.OpenFileDialog openFileDialogNetlis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NetlistFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bChooseCMOSmodel;
        private System.Windows.Forms.TextBox NMOSMODEPATH;
        private System.Windows.Forms.OpenFileDialog openFileNMOSmodel;
        private System.Windows.Forms.OpenFileDialog openFilePMOSMODELFILE;
        private System.Windows.Forms.TextBox textBoxTemperature;
        private System.Windows.Forms.Label TEMPERATURE;
        private System.Windows.Forms.Button buttonNEXT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxMachine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSSHdirectory;
        private System.Windows.Forms.OpenFileDialog openFileSSHdirectory;
        private System.Windows.Forms.TextBox textBoxSSHDirectory;
    }
}

