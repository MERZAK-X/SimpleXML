using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using XML_GUI.Properties;
using XMLUtils;

namespace XML_GUI
{
    public partial class IEDatabase : Form
    {
        public IEDatabase()
        {
            InitializeComponent();
            importControl(true);
            dbPanel.Hide();
        }
        
        public IEDatabase(string []tablenames)
        {
            InitializeComponent();
            importControl(true);
            foreach (var table in tablenames)
                databaseTables.Items.Add(table);
        }
        
        private void importControl(bool flag)
        {
            this.Text = (flag) ? "Import from Database" : "Export to Database";
            entityName.Enabled = flag;
            txtEntityname.Enabled = flag;
            actionDirection.Text = (flag) ? ">>>" : "<<<";
            import_export.Text = (flag) ? "Import" : "Export";
        }

        private void importFromDatabase()
        {
            String tableName = databaseTables.SelectedItem.ToString(), entity = entityName.Text; // Fixes #42 : do not pass entityName.Text to the constructor
            if (importColumnsList.Items.Count > 0) {
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
                // Open a new XmlGUI Form as a new Thread
                var newDocument = new Thread(() => Application.Run(new XmlGUI(ODBConnection.GetTable(databaseTables.SelectedItem.ToString()), entity)));
                newDocument.SetApartmentState(ApartmentState.STA); // Fixes Threads issue #21
                newDocument.IsBackground = false;
                newDocument.Start();
                Dispose();
                Close();
                
            } else MessageBox.Show(Resources.XML_ImportTable_noColumns_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /*private List<String> getColumnNames()
        {
            return (from object item in importColumnsList.Items select item.ToString()).ToList();
        }

        private void addColumn_Click(object sender, EventArgs e)
        {
            if (!importColumnsList.Items.Contains(columnName.Text))
                if(XmlUtils.validInput(columnName.Text)) importColumnsList.Items.Add(columnName.Text);
                else MessageBox.Show(Resources.XML_NewTable_invalidColumnName_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else MessageBox.Show(Resources.XML_NewTable_addExistingColumn_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deleteColumn_Click(object sender, EventArgs e)
        {
            if (importColumnsList.SelectedIndex != -1) {
                importColumnsList.Items.RemoveAt(importColumnsList.SelectedIndex); 
            } else {
                //importColumnsList.Items.Remove(columnName.Text);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (importColumnsList.Items.Count > 0) {
                // Entity name check #33
                if (!XmlUtils.validInput(entityName.Text))
                {
                    var skipEntityName = MessageBox.Show(string.Format(Resources.XML_NewTable_invalidEntityName_msg, entityName.Text), Resources.XMLGUI__warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (skipEntityName == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                // Open a new XmlGUI Form as a new Thread
                var entity = entityName.Text; // Fixes #42 : do not pass entityName.Text to the constructor
                var newXmlDoc = new Thread(() => Application.Run(new XmlGUI(this.getColumnNames(), entity)));
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
                    //addColumn.PerformClick();
                    break;
                case Keys.Delete:
                    //deleteColumn.PerformClick();
                    break;
            }
        }*/

        private void databaseTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableName = databaseTables.SelectedItem.ToString();
            var columnNames = ODBConnection.GetTableColumns(tableName);
            entityName.Text = tableName;
            importColumnsList.Items.Clear();
            foreach (var column in columnNames)
                importColumnsList.Items.Add(column);
        }

        private void import_export_Click(object sender, EventArgs e)
        {
            importFromDatabase();
        }

        private void columnsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //columnName.Text = importColumnsList.SelectedItem.ToString();
        }
    }
}