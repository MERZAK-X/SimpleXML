using System.ComponentModel;

namespace SimpleXML
{
    partial class IEDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IEDatabase));
            this.importColumnsList = new System.Windows.Forms.ListBox();
            this.txtEntityname = new System.Windows.Forms.Label();
            this.entityName = new System.Windows.Forms.TextBox();
            this.dbPanel = new System.Windows.Forms.Panel();
            this.txtDbTable = new System.Windows.Forms.Label();
            this.import_export = new System.Windows.Forms.Button();
            this.databaseTables = new System.Windows.Forms.ComboBox();
            this.exportColumnsList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.actionDirection = new System.Windows.Forms.Label();
            this.dbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // importColumnsList
            // 
            this.importColumnsList.FormattingEnabled = true;
            this.importColumnsList.ItemHeight = 20;
            this.importColumnsList.Location = new System.Drawing.Point(34, 123);
            this.importColumnsList.Name = "importColumnsList";
            this.importColumnsList.Size = new System.Drawing.Size(194, 164);
            this.importColumnsList.Sorted = true;
            this.importColumnsList.TabIndex = 5;
            this.importColumnsList.SelectedIndexChanged += new System.EventHandler(this.columnsList_SelectedIndexChanged);
            // 
            // txtEntityname
            // 
            this.txtEntityname.Location = new System.Drawing.Point(42, 39);
            this.txtEntityname.Name = "txtEntityname";
            this.txtEntityname.Size = new System.Drawing.Size(112, 23);
            this.txtEntityname.TabIndex = 6;
            this.txtEntityname.Text = "Entity name";
            // 
            // entityName
            // 
            this.entityName.Location = new System.Drawing.Point(168, 36);
            this.entityName.MaxLength = 30;
            this.entityName.Name = "entityName";
            this.entityName.Size = new System.Drawing.Size(259, 26);
            this.entityName.TabIndex = 1;
            // 
            // dbPanel
            // 
            this.dbPanel.Controls.Add(this.txtDbTable);
            this.dbPanel.Controls.Add(this.import_export);
            this.dbPanel.Controls.Add(this.databaseTables);
            this.dbPanel.Location = new System.Drawing.Point(12, 293);
            this.dbPanel.Name = "dbPanel";
            this.dbPanel.Size = new System.Drawing.Size(553, 100);
            this.dbPanel.TabIndex = 7;
            // 
            // txtDbTable
            // 
            this.txtDbTable.Location = new System.Drawing.Point(22, 39);
            this.txtDbTable.Name = "txtDbTable";
            this.txtDbTable.Size = new System.Drawing.Size(123, 23);
            this.txtDbTable.TabIndex = 9;
            this.txtDbTable.Text = "Database Table";
            // 
            // import_export
            // 
            this.import_export.Location = new System.Drawing.Point(416, 30);
            this.import_export.Name = "import_export";
            this.import_export.Size = new System.Drawing.Size(102, 38);
            this.import_export.TabIndex = 3;
            this.import_export.Text = "Import";
            this.import_export.UseVisualStyleBackColor = true;
            this.import_export.Click += new System.EventHandler(this.import_export_Click);
            // 
            // databaseTables
            // 
            this.databaseTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseTables.FormattingEnabled = true;
            this.databaseTables.Location = new System.Drawing.Point(178, 36);
            this.databaseTables.Name = "databaseTables";
            this.databaseTables.Size = new System.Drawing.Size(205, 28);
            this.databaseTables.TabIndex = 2;
            this.databaseTables.SelectedIndexChanged += new System.EventHandler(this.databaseTables_SelectedIndexChanged);
            // 
            // exportColumnsList
            // 
            this.exportColumnsList.FormattingEnabled = true;
            this.exportColumnsList.ItemHeight = 20;
            this.exportColumnsList.Location = new System.Drawing.Point(336, 123);
            this.exportColumnsList.Name = "exportColumnsList";
            this.exportColumnsList.Size = new System.Drawing.Size(194, 164);
            this.exportColumnsList.Sorted = true;
            this.exportColumnsList.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Database table columns";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(336, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "SimpleXML table columns";
            // 
            // actionDirection
            // 
            this.actionDirection.Location = new System.Drawing.Point(260, 185);
            this.actionDirection.Name = "actionDirection";
            this.actionDirection.Size = new System.Drawing.Size(43, 23);
            this.actionDirection.TabIndex = 11;
            this.actionDirection.Text = ">>>";
            // 
            // IEDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 400);
            this.Controls.Add(this.actionDirection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportColumnsList);
            this.Controls.Add(this.dbPanel);
            this.Controls.Add(this.entityName);
            this.Controls.Add(this.txtEntityname);
            this.Controls.Add(this.importColumnsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 357);
            this.Name = "IEDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Import/Export Dialog";
            this.dbPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label actionDirection;
        private System.Windows.Forms.ComboBox databaseTables;
        private System.Windows.Forms.Panel dbPanel;
        private System.Windows.Forms.TextBox entityName;
        private System.Windows.Forms.ListBox exportColumnsList;
        private System.Windows.Forms.Button import_export;
        private System.Windows.Forms.ListBox importColumnsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtDbTable;
        private System.Windows.Forms.Label txtEntityname;

        #endregion
    }
}