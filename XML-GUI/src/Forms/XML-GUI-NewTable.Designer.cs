using System.ComponentModel;

namespace XML_GUI
{
    partial class XML_GUI_NewTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XML_GUI_NewTable));
            this.columnsList = new System.Windows.Forms.ListBox();
            this.columnName = new System.Windows.Forms.TextBox();
            this.addColumn = new System.Windows.Forms.Button();
            this.txtClmnName = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.deleteColumn = new System.Windows.Forms.Button();
            this.txtEntityname = new System.Windows.Forms.Label();
            this.entityName = new System.Windows.Forms.TextBox();
            this.dbPanel = new System.Windows.Forms.Panel();
            this.import = new System.Windows.Forms.Button();
            this.databaseTables = new System.Windows.Forms.ComboBox();
            this.dbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnsList
            // 
            this.columnsList.FormattingEnabled = true;
            this.columnsList.ItemHeight = 20;
            this.columnsList.Location = new System.Drawing.Point(67, 123);
            this.columnsList.Name = "columnsList";
            this.columnsList.Size = new System.Drawing.Size(254, 164);
            this.columnsList.TabIndex = 5;
            this.columnsList.SelectedIndexChanged += new System.EventHandler(this.columnsList_SelectedIndexChanged);
            // 
            // columnName
            // 
            this.columnName.Location = new System.Drawing.Point(148, 72);
            this.columnName.Name = "columnName";
            this.columnName.Size = new System.Drawing.Size(222, 26);
            this.columnName.TabIndex = 2;
            this.columnName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.columnName_KeyDown);
            // 
            // addColumn
            // 
            this.addColumn.Location = new System.Drawing.Point(362, 123);
            this.addColumn.Name = "addColumn";
            this.addColumn.Size = new System.Drawing.Size(102, 38);
            this.addColumn.TabIndex = 3;
            this.addColumn.Text = "Add";
            this.addColumn.UseVisualStyleBackColor = true;
            this.addColumn.Click += new System.EventHandler(this.addColumn_Click);
            // 
            // txtClmnName
            // 
            this.txtClmnName.Location = new System.Drawing.Point(22, 75);
            this.txtClmnName.Name = "txtClmnName";
            this.txtClmnName.Size = new System.Drawing.Size(112, 24);
            this.txtClmnName.TabIndex = 3;
            this.txtClmnName.Text = "Column name";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(362, 249);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(102, 38);
            this.btnDone.TabIndex = 4;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // deleteColumn
            // 
            this.deleteColumn.Location = new System.Drawing.Point(362, 167);
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.Size = new System.Drawing.Size(102, 39);
            this.deleteColumn.TabIndex = 6;
            this.deleteColumn.Text = "Delete";
            this.deleteColumn.UseVisualStyleBackColor = true;
            this.deleteColumn.Click += new System.EventHandler(this.deleteColumn_Click);
            // 
            // txtEntityname
            // 
            this.txtEntityname.Location = new System.Drawing.Point(22, 30);
            this.txtEntityname.Name = "txtEntityname";
            this.txtEntityname.Size = new System.Drawing.Size(112, 23);
            this.txtEntityname.TabIndex = 6;
            this.txtEntityname.Text = "Entity Name";
            // 
            // entityName
            // 
            this.entityName.Location = new System.Drawing.Point(148, 27);
            this.entityName.MaxLength = 30;
            this.entityName.Name = "entityName";
            this.entityName.Size = new System.Drawing.Size(222, 26);
            this.entityName.TabIndex = 1;
            // 
            // dbPanel
            // 
            this.dbPanel.Controls.Add(this.import);
            this.dbPanel.Controls.Add(this.databaseTables);
            this.dbPanel.Location = new System.Drawing.Point(12, 293);
            this.dbPanel.Name = "dbPanel";
            this.dbPanel.Size = new System.Drawing.Size(485, 100);
            this.dbPanel.TabIndex = 7;
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(350, 30);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(102, 38);
            this.import.TabIndex = 8;
            this.import.Text = "Import";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // databaseTables
            // 
            this.databaseTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseTables.FormattingEnabled = true;
            this.databaseTables.Location = new System.Drawing.Point(20, 36);
            this.databaseTables.Name = "databaseTables";
            this.databaseTables.Size = new System.Drawing.Size(289, 28);
            this.databaseTables.TabIndex = 0;
            this.databaseTables.SelectedIndexChanged += new System.EventHandler(this.databaseTables_SelectedIndexChanged);
            // 
            // XML_GUI_NewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 400);
            this.Controls.Add(this.dbPanel);
            this.Controls.Add(this.entityName);
            this.Controls.Add(this.txtEntityname);
            this.Controls.Add(this.deleteColumn);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtClmnName);
            this.Controls.Add(this.addColumn);
            this.Controls.Add(this.columnName);
            this.Controls.Add(this.columnsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 357);
            this.Name = "XML_GUI_NewTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Document";
            this.dbPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button addColumn;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox columnName;
        private System.Windows.Forms.ListBox columnsList;
        private System.Windows.Forms.ComboBox databaseTables;
        private System.Windows.Forms.Panel dbPanel;
        private System.Windows.Forms.Button deleteColumn;
        private System.Windows.Forms.TextBox entityName;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Label txtClmnName;
        private System.Windows.Forms.Label txtEntityname;

        #endregion
    }
}