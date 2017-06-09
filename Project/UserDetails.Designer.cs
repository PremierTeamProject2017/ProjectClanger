namespace Project
{
    partial class UserDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDetails));
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ftsUserDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.cboAccessLevel = new System.Windows.Forms.ComboBox();
            this.chbRestricted = new System.Windows.Forms.CheckBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRestricted = new System.Windows.Forms.Label();
            this.btnNewPassGen = new System.Windows.Forms.Button();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiGenPass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(126, 306);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(85, 53);
            this.btnSendEmail.TabIndex = 2;
            this.btnSendEmail.Text = "Send Verification Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(217, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 53);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(308, 306);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 53);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ftsUserDetail});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ftsUserDetail
            // 
            this.ftsUserDetail.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.backToolStripMenuItem,
            this.tsiGenPass});
            this.ftsUserDetail.Name = "ftsUserDetail";
            this.ftsUserDetail.Size = new System.Drawing.Size(37, 20);
            this.ftsUserDetail.Text = "&File";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(293, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(103, 169);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(290, 20);
            this.tbFirstName.TabIndex = 13;
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(103, 195);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(290, 20);
            this.tbSurname.TabIndex = 14;
            // 
            // cboAccessLevel
            // 
            this.cboAccessLevel.FormattingEnabled = true;
            this.cboAccessLevel.Location = new System.Drawing.Point(103, 247);
            this.cboAccessLevel.Name = "cboAccessLevel";
            this.cboAccessLevel.Size = new System.Drawing.Size(290, 21);
            this.cboAccessLevel.TabIndex = 17;
            // 
            // chbRestricted
            // 
            this.chbRestricted.AutoSize = true;
            this.chbRestricted.Location = new System.Drawing.Point(103, 274);
            this.chbRestricted.Name = "chbRestricted";
            this.chbRestricted.Size = new System.Drawing.Size(15, 14);
            this.chbRestricted.TabIndex = 18;
            this.chbRestricted.UseVisualStyleBackColor = true;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(103, 221);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(290, 20);
            this.tbEmail.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Surname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Access Level";
            // 
            // lblRestricted
            // 
            this.lblRestricted.AutoSize = true;
            this.lblRestricted.Location = new System.Drawing.Point(12, 278);
            this.lblRestricted.Name = "lblRestricted";
            this.lblRestricted.Size = new System.Drawing.Size(55, 13);
            this.lblRestricted.TabIndex = 24;
            this.lblRestricted.Text = "Restricted";
            // 
            // btnNewPassGen
            // 
            this.btnNewPassGen.Location = new System.Drawing.Point(35, 306);
            this.btnNewPassGen.Name = "btnNewPassGen";
            this.btnNewPassGen.Size = new System.Drawing.Size(85, 53);
            this.btnNewPassGen.TabIndex = 25;
            this.btnNewPassGen.Text = "Generate New Password";
            this.btnNewPassGen.UseVisualStyleBackColor = true;
            this.btnNewPassGen.Click += new System.EventHandler(this.btnNewPassGen_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.backToolStripMenuItem.Text = "&Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // tsiGenPass
            // 
            this.tsiGenPass.Name = "tsiGenPass";
            this.tsiGenPass.Size = new System.Drawing.Size(174, 22);
            this.tsiGenPass.Text = "&Generate Password";
            this.tsiGenPass.Click += new System.EventHandler(this.generatePasswordToolStripMenuItem_Click);
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(444, 401);
            this.Controls.Add(this.btnNewPassGen);
            this.Controls.Add(this.lblRestricted);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.chbRestricted);
            this.Controls.Add(this.cboAccessLevel);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserDetails";
            this.Text = "UserDetails";
            this.Load += new System.EventHandler(this.UserDetails_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ftsUserDetail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.ComboBox cboAccessLevel;
        private System.Windows.Forms.CheckBox chbRestricted;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRestricted;
        private System.Windows.Forms.Button btnNewPassGen;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiGenPass;
    }
}