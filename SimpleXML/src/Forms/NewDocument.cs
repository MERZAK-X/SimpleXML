using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SimpleXML.Properties;
using XMLUtils;

namespace SimpleXML
{
    public partial class NewDocument : Form
    {
        public NewDocument()
        {
            InitializeComponent();
            enableControl(true);
            dbPanel.Hide();
        }
        
        public NewDocument(string []tablenames)
        {
            InitializeComponent();
            enableControl(false);
            foreach (var table in tablenames)
                databaseTables.Items.Add(table);
        }
        
        private void enableControl(bool flag)
        {
            txtClmnName.Enabled = flag;
            columnName.Enabled = flag;
            addColumn.Enabled = flag;
            deleteColumn.Enabled = flag;
            btnDone.Enabled = flag;
            Height += (flag) ? -83 : +83; // Remove or add database panel space
            dbPanel.Visible = !flag;
            dbPanel.Enabled = !flag;
            databaseTables.Enabled = !flag;
            import.Enabled = !flag;
        }

        private List<String> getColumnNames()
        {
            return (from object item in columnsList.Items select item.ToString()).ToList();
        }

        private void addColumn_Click(object sender, EventArgs e)
        {
            if (!columnsList.Items.Contains(columnName.Text))
                if(XmlUtils.validInput(columnName.Text)) columnsList.Items.Add(columnName.Text);
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
                if (!XmlUtils.validInput(entityName.Text))
                {
                    var skipEntityName = MessageBox.Show(string.Format(Resources.XML_NewTable_invalidEntityName_msg, entityName.Text), Resources.XMLGUI__warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (skipEntityName == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                // Open a new SimpleXml Form as a new Thread
                var entity = entityName.Text; // Fixes #42 : do not pass entityName.Text to the constructor
                var newXmlDoc = new Thread(() => Application.Run(new SimpleXml(this.getColumnNames(), entity)));
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

        private void databaseTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableName = databaseTables.SelectedItem.ToString();
            var columnNames = ODBConnection.GetTableColumns(tableName);
            entityName.Text = tableName;
            columnsList.Items.Clear();
            foreach (var column in columnNames)
                columnsList.Items.Add(column);
        }

        private void import_Click(object sender, EventArgs e)
        {
            String tableName = databaseTables.SelectedItem.ToString(), entity = entityName.Text; // Fixes #42 : do not pass entityName.Text to the constructor
            if (columnsList.Items.Count > 0) {
                // Entity name check #33
                if (!XmlUtils.validInput(entityName.Text))
                {
                    var skipEntityName = MessageBox.Show(string.Format(Resources.XML_NewTable_invalidImportEntityName_msg, entityName.Text, tableName), Resources.XMLGUI__warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    switch (skipEntityName)
                    {
                        case DialogResult.Cancel:
                            return;
                        case DialogResult.OK:
                            entity = tableName;
                            break;
                    }
                }
                // Open a new SimpleXml Form as a new Thread
                var newDocument = new Thread(() => Application.Run(new SimpleXml(ODBConnection.ImportTable(databaseTables.SelectedItem.ToString()), entity)));
                newDocument.SetApartmentState(ApartmentState.STA); // Fixes Threads issue #21
                newDocument.IsBackground = false;
                newDocument.Start();
                Dispose();
                Close();
                
            } else MessageBox.Show(Resources.XML_ImportTable_noColumns_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void columnsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            columnName.Text = columnsList.SelectedItem.ToString();
        }
    }
}