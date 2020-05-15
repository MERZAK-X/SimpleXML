using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using XML_GUI.Properties;

namespace XML_GUI
{
    public partial class XML_GUI_NewTable : Form
    {
        private string entityName = "data";
        public XML_GUI_NewTable()
        {
            InitializeComponent();
            this.Visible = true; // Make form visible
        }

        private List<String> getColumnNames()
        {
            return (from object item in columnsList.Items select item.ToString()).ToList();
        }

        private bool validText(string text) // Check for #33
        {
            return (text != "" && Regex.IsMatch(text, @"^([a-zA-Z_][a-zA-Z0-9_]*)$"));
        }

        private void addColumn_Click(object sender, EventArgs e)
        {
            if (!columnsList.Items.Contains(columnName.Text))
                if(validText(columnName.Text)) columnsList.Items.Add(columnName.Text);
                else MessageBox.Show(Resources.XML_NewTable_invalidColumnName_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else MessageBox.Show(Resources.XML_NewTable_addExistingColumn_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deleteColumn_Click(object sender, EventArgs e)
        {
            if (columnsList.SelectedIndex != -1) {
                columnsList.Items.RemoveAt(columnsList.SelectedIndex); 
            } else {
                columnsList.Items.Remove(columnName.Text);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (columnsList.Items.Count > 0) {
                // Entity name check #33
                if (!validText(entityNameBox.Text))
                {
                    var skipEntityName = MessageBox.Show(string.Format(Resources.XML_NewTable_invalidEntityName_msg, entityNameBox.Text), Resources.XMLGUI__warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (skipEntityName == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                // Open a new XmlGUI Form as a new Thread
                var newXmlDoc = new Thread(() => Application.Run(new XmlGUI(this.getColumnNames(), entityNameBox.Text)));
                newXmlDoc.SetApartmentState(ApartmentState.STA); // Fixes Threads issue #21
                newXmlDoc.IsBackground = false;
                newXmlDoc.Start();
                Dispose();
                Close();
                
            } else MessageBox.Show(Resources.XML_NewTable_noColumns_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void columnName_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    addColumn.PerformClick();
                    break;
                case Keys.Delete:
                    deleteColumn.PerformClick();
                    break;
            }
        }
    }
}