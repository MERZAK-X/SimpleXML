using System.ComponentModel;

namespace XML_GUI
{
    partial class XML_DB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XML_DB));
            this.testConnection = new System.Windows.Forms.Button();
            this.labelDbSvr = new System.Windows.Forms.Label();
            this.dbServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // testConnection
            // 
            this.testConnection.Location = new System.Drawing.Point(563, 12);
            this.testConnection.Name = "testConnection";
            this.testConnection.Size = new System.Drawing.Size(138, 51);
            this.testConnection.TabIndex = 0;
            this.testConnection.Text = "TEST";
            this.testConnection.UseVisualStyleBackColor = true;
            // 
            // labelDbSvr
            // 
            this.labelDbSvr.Location = new System.Drawing.Point(50, 27);
            this.labelDbSvr.Name = "labelDbSvr";
            this.labelDbSvr.Size = new System.Drawing.Size(58, 23);
            this.labelDbSvr.TabIndex = 1;
            this.labelDbSvr.Text = "Server";
            // 
            // dbServer
            // 
            this.dbServer.Location = new System.Drawing.Point(141, 24);
            this.dbServer.Name = "dbServer";
            this.dbServer.Size = new System.Drawing.Size(332, 26);
            this.dbServer.TabIndex = 2;
            // 
            // XML_DB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 466);
            this.Controls.Add(this.dbServer);
            this.Controls.Add(this.labelDbSvr);
            this.Controls.Add(this.testConnection);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "XML_DB";
            this.Text = "XML DB";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox dbServer;
        private System.Windows.Forms.Label labelDbSvr;
        private System.Windows.Forms.Button testConnection;

        #endregion
    }
}