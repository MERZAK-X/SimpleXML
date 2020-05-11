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
            this.SuspendLayout();
            // 
            // columnsList
            // 
            this.columnsList.FormattingEnabled = true;
            this.columnsList.ItemHeight = 20;
            this.columnsList.Location = new System.Drawing.Point(25, 122);
            this.columnsList.Name = "columnsList";
            this.columnsList.Size = new System.Drawing.Size(281, 264);
            this.columnsList.TabIndex = 0;
            // 
            // columnName
            // 
            this.columnName.Location = new System.Drawing.Point(151, 28);
            this.columnName.Name = "columnName";
            this.columnName.Size = new System.Drawing.Size(169, 26);
            this.columnName.TabIndex = 1;
            this.columnName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.columnName_KeyDown);
            // 
            // addColumn
            // 
            this.addColumn.Location = new System.Drawing.Point(342, 22);
            this.addColumn.Name = "addColumn";
            this.addColumn.Size = new System.Drawing.Size(94, 38);
            this.addColumn.TabIndex = 2;
            this.addColumn.Text = "Add";
            this.addColumn.UseVisualStyleBackColor = true;
            this.addColumn.Click += new System.EventHandler(this.addColumn_Click);
            // 
            // txtClmnName
            // 
            this.txtClmnName.Location = new System.Drawing.Point(25, 31);
            this.txtClmnName.Name = "txtClmnName";
            this.txtClmnName.Size = new System.Drawing.Size(112, 24);
            this.txtClmnName.TabIndex = 3;
            this.txtClmnName.Text = "Column name";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(446, 348);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(102, 38);
            this.btnDone.TabIndex = 4;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // deleteColumn
            // 
            this.deleteColumn.Location = new System.Drawing.Point(454, 22);
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.Size = new System.Drawing.Size(94, 39);
            this.deleteColumn.TabIndex = 5;
            this.deleteColumn.Text = "Delete";
            this.deleteColumn.UseVisualStyleBackColor = true;
            this.deleteColumn.Click += new System.EventHandler(this.deleteColumn_Click);
            // 
            // XML_GUI_NewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 420);
            this.Controls.Add(this.deleteColumn);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtClmnName);
            this.Controls.Add(this.addColumn);
            this.Controls.Add(this.columnName);
            this.Controls.Add(this.columnsList);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "XML_GUI_NewTable";
            this.Text = "New Document";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button addColumn;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox columnName;
        private System.Windows.Forms.ListBox columnsList;
        private System.Windows.Forms.Button deleteColumn;
        private System.Windows.Forms.Label txtClmnName;

        #endregion
    }
}