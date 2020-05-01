namespace XML_GUI
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
            this.xmlDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) (this.xmlDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // xmlDataGrid
            // 
            this.xmlDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xmlDataGrid.Location = new System.Drawing.Point(12, 94);
            this.xmlDataGrid.Name = "xmlDataGrid";
            this.xmlDataGrid.RowTemplate.Height = 28;
            this.xmlDataGrid.Size = new System.Drawing.Size(591, 344);
            this.xmlDataGrid.TabIndex = 0;
            // 
            // XML-GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 450);
            this.Controls.Add(this.xmlDataGrid);
            this.Name = "XML-GUI";
            this.Text = "XML-GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.xmlDataGrid)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView xmlDataGrid;

        #endregion
    }
}