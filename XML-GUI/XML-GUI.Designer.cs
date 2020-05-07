namespace XML_GUI
{
    partial class XmlGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlGUI));
            this.xmlDataGrid = new System.Windows.Forms.DataGridView();
            this.openXml = new System.Windows.Forms.Button();
            this.exportXml = new System.Windows.Forms.Button();
            this.saveCurrent = new System.Windows.Forms.Button();
            this.readOnly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize) (this.xmlDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // xmlDataGrid
            // 
            this.xmlDataGrid.AllowUserToDeleteRows = false;
            this.xmlDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.xmlDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xmlDataGrid.Location = new System.Drawing.Point(12, 94);
            this.xmlDataGrid.Name = "xmlDataGrid";
            this.xmlDataGrid.ReadOnly = true;
            this.xmlDataGrid.RowTemplate.Height = 28;
            this.xmlDataGrid.Size = new System.Drawing.Size(1020, 383);
            this.xmlDataGrid.TabIndex = 0;
            // 
            // openXml
            // 
            this.openXml.Location = new System.Drawing.Point(12, 12);
            this.openXml.Name = "openXml";
            this.openXml.Size = new System.Drawing.Size(162, 59);
            this.openXml.TabIndex = 1;
            this.openXml.Text = "Open XML";
            this.openXml.UseVisualStyleBackColor = true;
            this.openXml.Click += new System.EventHandler(this.OpenXmlDoc_Click);
            // 
            // exportXml
            // 
            this.exportXml.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportXml.Location = new System.Drawing.Point(879, 12);
            this.exportXml.MinimumSize = new System.Drawing.Size(153, 59);
            this.exportXml.Name = "exportXml";
            this.exportXml.Size = new System.Drawing.Size(153, 59);
            this.exportXml.TabIndex = 2;
            this.exportXml.Text = "Export to";
            this.exportXml.UseVisualStyleBackColor = true;
            this.exportXml.Click += new System.EventHandler(this.saveXml_Click);
            // 
            // saveCurrent
            // 
            this.saveCurrent.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveCurrent.Location = new System.Drawing.Point(720, 12);
            this.saveCurrent.Name = "saveCurrent";
            this.saveCurrent.Size = new System.Drawing.Size(153, 59);
            this.saveCurrent.TabIndex = 3;
            this.saveCurrent.Text = "Save";
            this.saveCurrent.UseVisualStyleBackColor = true;
            this.saveCurrent.Click += new System.EventHandler(this.saveCurrent_Click);
            // 
            // readOnly
            // 
            this.readOnly.Checked = true;
            this.readOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.readOnly.Location = new System.Drawing.Point(197, 30);
            this.readOnly.Name = "readOnly";
            this.readOnly.Size = new System.Drawing.Size(114, 24);
            this.readOnly.TabIndex = 4;
            this.readOnly.Text = "Read Only";
            this.readOnly.UseVisualStyleBackColor = true;
            this.readOnly.CheckedChanged += new System.EventHandler(this.readOnly_CheckedChanged);
            // 
            // XmlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 489);
            this.Controls.Add(this.readOnly);
            this.Controls.Add(this.saveCurrent);
            this.Controls.Add(this.exportXml);
            this.Controls.Add(this.openXml);
            this.Controls.Add(this.xmlDataGrid);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "XmlGUI";
            this.Text = "XML-GUI";
            this.Load += new System.EventHandler(this.XmlGUI_Load);
            ((System.ComponentModel.ISupportInitialize) (this.xmlDataGrid)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button exportXml;
        private System.Windows.Forms.Button openXml;
        private System.Windows.Forms.CheckBox readOnly;
        private System.Windows.Forms.Button saveCurrent;
        private System.Windows.Forms.DataGridView xmlDataGrid;

        #endregion
    }
}