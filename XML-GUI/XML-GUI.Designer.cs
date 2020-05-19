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
            this.saveCurrent = new System.Windows.Forms.Button();
            this.readOnly = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toXMLDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize) (this.xmlDataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xmlDataGrid
            // 
            this.xmlDataGrid.AllowDrop = true;
            this.xmlDataGrid.AllowUserToDeleteRows = false;
            this.xmlDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.xmlDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xmlDataGrid.Location = new System.Drawing.Point(12, 111);
            this.xmlDataGrid.Name = "xmlDataGrid";
            this.xmlDataGrid.ReadOnly = true;
            this.xmlDataGrid.RowTemplate.Height = 28;
            this.xmlDataGrid.Size = new System.Drawing.Size(1020, 443);
            this.xmlDataGrid.TabIndex = 0;
            this.xmlDataGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.xmlDataGrid_DragDrop);
            this.xmlDataGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.xmlDataGrid_DragEnter);
            // 
            // openXml
            // 
            this.openXml.Location = new System.Drawing.Point(12, 46);
            this.openXml.Name = "openXml";
            this.openXml.Size = new System.Drawing.Size(162, 59);
            this.openXml.TabIndex = 1;
            this.openXml.Text = "Open XML";
            this.openXml.UseVisualStyleBackColor = true;
            this.openXml.Click += new System.EventHandler(this.OpenXmlDoc_Click);
            // 
            // saveCurrent
            // 
            this.saveCurrent.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveCurrent.Location = new System.Drawing.Point(879, 46);
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
            this.readOnly.Enabled = false;
            this.readOnly.Location = new System.Drawing.Point(197, 64);
            this.readOnly.Name = "readOnly";
            this.readOnly.Size = new System.Drawing.Size(114, 24);
            this.readOnly.TabIndex = 4;
            this.readOnly.Text = "Read Only";
            this.readOnly.UseVisualStyleBackColor = true;
            this.readOnly.CheckedChanged += new System.EventHandler(this.readOnly_CheckedChanged);
            this.readOnly.CheckStateChanged += new System.EventHandler(this.readOnly_CheckStateChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileToolStripMenuItem, this.editToolStripMenuItem, this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1044, 33);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.newToolStripMenuItem, this.toolStripSeparator1, this.openToolStripMenuItem, this.importToolStripMenuItem, this.toolStripSeparator3, this.saveToolStripMenuItem, this.exportToolStripMenuItem, this.toolStripSeparator2, this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fromDatabaseToolStripMenuItem, this.excelSheetToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // fromDatabaseToolStripMenuItem
            // 
            this.fromDatabaseToolStripMenuItem.Name = "fromDatabaseToolStripMenuItem";
            this.fromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(214, 30);
            this.fromDatabaseToolStripMenuItem.Text = "from Database";
            this.fromDatabaseToolStripMenuItem.Click += new System.EventHandler(this.fromDatabaseToolStripMenuItem_Click);
            // 
            // excelSheetToolStripMenuItem
            // 
            this.excelSheetToolStripMenuItem.Name = "excelSheetToolStripMenuItem";
            this.excelSheetToolStripMenuItem.Size = new System.Drawing.Size(214, 30);
            this.excelSheetToolStripMenuItem.Text = "Excel Sheet";
            this.excelSheetToolStripMenuItem.Click += new System.EventHandler(this.excelSheetToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toXMLDocumentToolStripMenuItem, this.toCSVToolStripMenuItem, this.toDatabaseToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // toXMLDocumentToolStripMenuItem
            // 
            this.toXMLDocumentToolStripMenuItem.Name = "toXMLDocumentToolStripMenuItem";
            this.toXMLDocumentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) (((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) | System.Windows.Forms.Keys.E)));
            this.toXMLDocumentToolStripMenuItem.Size = new System.Drawing.Size(340, 30);
            this.toXMLDocumentToolStripMenuItem.Text = "to XML Document";
            this.toXMLDocumentToolStripMenuItem.Click += new System.EventHandler(this.toXMLDocumentToolStripMenuItem_Click);
            // 
            // toCSVToolStripMenuItem
            // 
            this.toCSVToolStripMenuItem.Name = "toCSVToolStripMenuItem";
            this.toCSVToolStripMenuItem.Size = new System.Drawing.Size(340, 30);
            this.toCSVToolStripMenuItem.Text = "to CSV Excel sheet";
            this.toCSVToolStripMenuItem.Click += new System.EventHandler(this.toCSVToolStripMenuItem_Click);
            // 
            // toDatabaseToolStripMenuItem
            // 
            this.toDatabaseToolStripMenuItem.Name = "toDatabaseToolStripMenuItem";
            this.toDatabaseToolStripMenuItem.Size = new System.Drawing.Size(340, 30);
            this.toDatabaseToolStripMenuItem.Text = "to Database";
            this.toDatabaseToolStripMenuItem.Click += new System.EventHandler(this.toDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Checked = true;
            this.editToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.readOnlyToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.CheckedChanged += new System.EventHandler(this.editToolStripMenuItem_CheckedChanged);
            // 
            // readOnlyToolStripMenuItem
            // 
            this.readOnlyToolStripMenuItem.Checked = true;
            this.readOnlyToolStripMenuItem.CheckOnClick = true;
            this.readOnlyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.readOnlyToolStripMenuItem.Enabled = false;
            this.readOnlyToolStripMenuItem.Name = "readOnlyToolStripMenuItem";
            this.readOnlyToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.readOnlyToolStripMenuItem.Text = "Read Only";
            this.readOnlyToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.readOnlyToolStripMenuItem_CheckStateChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.infoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(128, 30);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // XmlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 566);
            this.Controls.Add(this.readOnly);
            this.Controls.Add(this.saveCurrent);
            this.Controls.Add(this.openXml);
            this.Controls.Add(this.xmlDataGrid);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "XmlGUI";
            this.Text = "XML-GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XmlGUI_FormClosing);
            this.Load += new System.EventHandler(this.XmlGUI_Load);
            ((System.ComponentModel.ISupportInitialize) (this.xmlDataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button openXml;
        private System.Windows.Forms.CheckBox readOnly;
        private System.Windows.Forms.ToolStripMenuItem readOnlyToolStripMenuItem;
        private System.Windows.Forms.Button saveCurrent;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toXMLDocumentToolStripMenuItem;
        private System.Windows.Forms.DataGridView xmlDataGrid;

        #endregion
    }
}