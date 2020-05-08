using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace XML_GUI
{
    public partial class XML_GUI_NewTable : Form
    {
        public XML_GUI_NewTable()
        {
            InitializeComponent();
            this.Visible = true; // Make form visible
        }

        public List<String> getColumnNames()
        {
            return (from object item in columnsList.Items select item.ToString()).ToList();
        }

        private void addColumn_Click(object sender, EventArgs e)
        {
            columnsList.Items.Add(columnName.Text);
        }

        private void deleteColumn_Click(object sender, EventArgs e)
        {
            if(columnsList.SelectedIndex != -1)
            {
                columnsList.Items.RemoveAt(columnsList.SelectedIndex); 
            } else {
                columnsList.Items.Remove(columnName.Text);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            new XmlGUI(this.getColumnNames());
            Dispose(); Close();
        }

        private void columnName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                addColumn.PerformClick();
            }
        }
    }
}