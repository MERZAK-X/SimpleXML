using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using SimpleXML.Properties;
using XMLUtils;

namespace SimpleXML
{
    public partial class IEDatabase : Form
    {
        private DataTable exportTable;
        private bool import = true;
        public IEDatabase()
        {
            InitializeComponent();
            importControl(true);
            dbPanel.Hide();
        }
        
        public IEDatabase(string []tablenames)
        {
            InitializeComponent();
            import = true;
            importControl(true);
            foreach (var table in tablenames)
                databaseTables.Items.Add(table);
        }
        
        public IEDatabase(string []tablenames, DataTable exportTable)
        {
            InitializeComponent();
            import = false;
            importControl(false);
            this.exportTable = exportTable;
            foreach (var table in tablenames)
                databaseTables.Items.Add(table);
            foreach (var column in exportTable.Columns)
                exportColumnsList.Items.Add(column.ToString());
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
                var newDocument = new Thread(() => Application.Run(new XmlGUI(ODBConnection.ImportTable(databaseTables.SelectedItem.ToString()), entity)));
                newDocument.SetApartmentState(ApartmentState.STA); // Fixes Threads issue #21
                newDocument.IsBackground = false;
                newDocument.Start();
                Dispose();
                Close();
                
            } else MessageBox.Show(Resources.XML_ImportTable_noColumns_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void exportToDatabase()
        {
            var match = true;
            foreach (var column in exportColumnsList.Items) // Compare the 2 listBoxes
                if (!importColumnsList.Items.Contains(column)) match = false;
            if (match) {
                exportTable.TableName = databaseTables.SelectedItem.ToString();
                try
                {
                    if (ODBConnection.ExportTable(exportTable))
                        MessageBox.Show(string.Format(Resources.IEDatabase_successExport_msg, exportTable.TableName), Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    else throw new Exception();
                }catch(Exception e){
                    if (MessageBox.Show(e.Message, Resources.XMLGUI__fail, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                        exportToDatabase();
                    else return;
                }
                Dispose();
                Close();
            } else MessageBox.Show(Resources.IEDatabase_columns_mismatch_msg, Resources.IEDatabase_columns_mismatch, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void databaseTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableName = databaseTables.SelectedItem.ToString();
            var columnNames = ODBConnection.GetTableColumns(tableName);
            entityName.Text = tableName;
            import_export.Enabled = true;
            importColumnsList.Items.Clear();
            if(import) exportColumnsList.Items.Clear();
            foreach (var column in columnNames)
            {
                importColumnsList.Items.Add(column);
                if(import) exportColumnsList.Items.Add(column);
            }
        }

        private void import_export_Click(object sender, EventArgs e)
        {
            if(import)
                importFromDatabase();
            else
                exportToDatabase();
        }

        private void columnsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //columnName.Text = importColumnsList.SelectedItem.ToString();
        }
        
    }
}