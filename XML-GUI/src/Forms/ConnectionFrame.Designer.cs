namespace XML2DB
{
    partial class ConnectionFrame
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
            this.components = new System.ComponentModel.Container();
            this.connect = new System.Windows.Forms.Button();
            this.dbAuthType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_usr = new System.Windows.Forms.Label();
            this.lbl_pwd = new System.Windows.Forms.Label();
            this.dbUser = new System.Windows.Forms.TextBox();
            this.dbPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bannerPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.options = new System.Windows.Forms.Button();
            this.credentialsPanel = new System.Windows.Forms.Panel();
            this.advancedOptionsPanel = new System.Windows.Forms.Panel();
            this.serverHostname = new System.Windows.Forms.TextBox();
            this.serverPort = new System.Windows.Forms.NumericUpDown();
            this.serverInstance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bannerPanel.SuspendLayout();
            this.credentialsPanel.SuspendLayout();
            this.advancedOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.serverPort)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.BackColor = System.Drawing.Color.CornflowerBlue;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.connect.Location = new System.Drawing.Point(446, 38);
            this.connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(138, 46);
            this.connect.TabIndex = 0;
            this.connect.Text = "Connect";
            this.toolTip.SetToolTip(this.connect, "Connect to database");
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // dbAuthType
            // 
            this.dbAuthType.DisplayMember = "Windows Authentication";
            this.dbAuthType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbAuthType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dbAuthType.FormattingEnabled = true;
            this.dbAuthType.Items.AddRange(new object[] {"Windows Authentication", "SQL-Server Authentication"});
            this.dbAuthType.Location = new System.Drawing.Point(217, 25);
            this.dbAuthType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbAuthType.Name = "dbAuthType";
            this.dbAuthType.Size = new System.Drawing.Size(351, 33);
            this.dbAuthType.TabIndex = 1;
            this.dbAuthType.SelectedIndexChanged += new System.EventHandler(this.dbAuthType_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(11, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 1);
            this.panel1.TabIndex = 2;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(302, 38);
            this.cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(138, 46);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.btn_cl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Authentication:";
            // 
            // lbl_usr
            // 
            this.lbl_usr.AutoSize = true;
            this.lbl_usr.Enabled = false;
            this.lbl_usr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lbl_usr.Location = new System.Drawing.Point(31, 147);
            this.lbl_usr.Name = "lbl_usr";
            this.lbl_usr.Size = new System.Drawing.Size(97, 22);
            this.lbl_usr.TabIndex = 5;
            this.lbl_usr.Text = "Username:";
            // 
            // lbl_pwd
            // 
            this.lbl_pwd.AutoSize = true;
            this.lbl_pwd.Enabled = false;
            this.lbl_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lbl_pwd.Location = new System.Drawing.Point(31, 197);
            this.lbl_pwd.Name = "lbl_pwd";
            this.lbl_pwd.Size = new System.Drawing.Size(94, 22);
            this.lbl_pwd.TabIndex = 6;
            this.lbl_pwd.Text = "Password:";
            // 
            // dbUser
            // 
            this.dbUser.Enabled = false;
            this.dbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dbUser.Location = new System.Drawing.Point(217, 142);
            this.dbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbUser.Name = "dbUser";
            this.dbUser.Size = new System.Drawing.Size(351, 31);
            this.dbUser.TabIndex = 7;
            // 
            // dbPass
            // 
            this.dbPass.Enabled = false;
            this.dbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dbPass.Location = new System.Drawing.Point(217, 192);
            this.dbPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbPass.Name = "dbPass";
            this.dbPass.PasswordChar = '*';
            this.dbPass.Size = new System.Drawing.Size(351, 31);
            this.dbPass.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(22, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "DataBase Name:";
            // 
            // dbName
            // 
            this.dbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dbName.Location = new System.Drawing.Point(217, 79);
            this.dbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(351, 31);
            this.dbName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(32, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 22);
            this.label5.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(164, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 62);
            this.label2.TabIndex = 13;
            this.label2.Text = "SQL Server";
            // 
            // bannerPanel
            // 
            this.bannerPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bannerPanel.Controls.Add(this.label2);
            this.bannerPanel.Location = new System.Drawing.Point(1, 1);
            this.bannerPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.Size = new System.Drawing.Size(623, 112);
            this.bannerPanel.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Location = new System.Drawing.Point(1, 109);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(622, 4);
            this.panel3.TabIndex = 15;
            // 
            // options
            // 
            this.options.Location = new System.Drawing.Point(126, 38);
            this.options.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(138, 46);
            this.options.TabIndex = 16;
            this.options.Text = "Options >>";
            this.toolTip.SetToolTip(this.options, "More options for remote connections");
            this.options.UseVisualStyleBackColor = true;
            this.options.Click += new System.EventHandler(this.options_Click);
            // 
            // credentialsPanel
            // 
            this.credentialsPanel.Controls.Add(this.label1);
            this.credentialsPanel.Controls.Add(this.label4);
            this.credentialsPanel.Controls.Add(this.dbName);
            this.credentialsPanel.Controls.Add(this.lbl_pwd);
            this.credentialsPanel.Controls.Add(this.dbAuthType);
            this.credentialsPanel.Controls.Add(this.lbl_usr);
            this.credentialsPanel.Controls.Add(this.dbUser);
            this.credentialsPanel.Controls.Add(this.dbPass);
            this.credentialsPanel.Location = new System.Drawing.Point(1, 113);
            this.credentialsPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.credentialsPanel.Name = "credentialsPanel";
            this.credentialsPanel.Size = new System.Drawing.Size(623, 248);
            this.credentialsPanel.TabIndex = 17;
            // 
            // advancedOptionsPanel
            // 
            this.advancedOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.advancedOptionsPanel.Controls.Add(this.serverHostname);
            this.advancedOptionsPanel.Controls.Add(this.serverPort);
            this.advancedOptionsPanel.Controls.Add(this.serverInstance);
            this.advancedOptionsPanel.Controls.Add(this.label6);
            this.advancedOptionsPanel.Controls.Add(this.label3);
            this.advancedOptionsPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.advancedOptionsPanel.Location = new System.Drawing.Point(1, 369);
            this.advancedOptionsPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.advancedOptionsPanel.Name = "advancedOptionsPanel";
            this.advancedOptionsPanel.Size = new System.Drawing.Size(623, 128);
            this.advancedOptionsPanel.TabIndex = 18;
            this.advancedOptionsPanel.Visible = false;
            // 
            // serverHostname
            // 
            this.serverHostname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.serverHostname.Location = new System.Drawing.Point(182, 75);
            this.serverHostname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serverHostname.MaxLength = 3;
            this.serverHostname.Name = "serverHostname";
            this.serverHostname.Size = new System.Drawing.Size(239, 31);
            this.serverHostname.TabIndex = 18;
            this.serverHostname.Text = "localhost";
            this.serverHostname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // serverPort
            // 
            this.serverPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.serverPort.Location = new System.Drawing.Point(445, 76);
            this.serverPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serverPort.Maximum = new decimal(new int[] {65535, 0, 0, 0});
            this.serverPort.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(100, 30);
            this.serverPort.TabIndex = 17;
            this.serverPort.Value = new decimal(new int[] {1433, 0, 0, 0});
            // 
            // serverInstance
            // 
            this.serverInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.serverInstance.Location = new System.Drawing.Point(182, 22);
            this.serverInstance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serverInstance.Name = "serverInstance";
            this.serverInstance.Size = new System.Drawing.Size(239, 31);
            this.serverInstance.TabIndex = 13;
            this.serverInstance.Text = "\\";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(21, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "Server Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(25, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Instance name:";
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonsPanel.Controls.Add(this.connect);
            this.buttonsPanel.Controls.Add(this.cancel);
            this.buttonsPanel.Controls.Add(this.panel1);
            this.buttonsPanel.Controls.Add(this.options);
            this.buttonsPanel.Location = new System.Drawing.Point(1, 505);
            this.buttonsPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(623, 105);
            this.buttonsPanel.TabIndex = 19;
            // 
            // ConnectionFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 611);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.advancedOptionsPanel);
            this.Controls.Add(this.credentialsPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.bannerPanel);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to MS SQL DataBase";
            this.Load += new System.EventHandler(this.Form_Load);
            this.bannerPanel.ResumeLayout(false);
            this.bannerPanel.PerformLayout();
            this.credentialsPanel.ResumeLayout(false);
            this.credentialsPanel.PerformLayout();
            this.advancedOptionsPanel.ResumeLayout(false);
            this.advancedOptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.serverPort)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel advancedOptionsPanel;
        private System.Windows.Forms.Panel bannerPanel;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Panel credentialsPanel;
        private System.Windows.Forms.ComboBox dbAuthType;
        private System.Windows.Forms.TextBox dbName;
        private System.Windows.Forms.TextBox dbPass;
        private System.Windows.Forms.TextBox dbUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_pwd;
        private System.Windows.Forms.Label lbl_usr;
        private System.Windows.Forms.Button options;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox serverHostname;
        private System.Windows.Forms.TextBox serverInstance;
        private System.Windows.Forms.NumericUpDown serverPort;
        private System.Windows.Forms.ToolTip toolTip;

        #endregion
    }
}

