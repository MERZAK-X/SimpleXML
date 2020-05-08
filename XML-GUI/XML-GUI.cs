using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using XMLUtils;
using XML_GUI.Properties;

namespace XML_GUI
{
    public partial class XmlGUI : Form
    {
        private String currentOpenXmlPath = String.Empty;
        private bool newXmlDoc = false;
        
        public XmlGUI()
        {
            InitializeComponent();
            enableCtrl(false); // Disable control since no xml doc is loaded  
            this.Visible = true; // Make the form visible
        }
        
        public XmlGUI(List<String> columns)
        {
            InitializeComponent();
            this.newXmlDoc = true; // Specify that we're making a new Xml Document
            // Load DataGrid columns from List
            DataTable newData = new DataTable("New XML Document");
            foreach (var column in columns){newData.Columns.Add(column);}
            xmlDataGrid.DataSource = newData;
            enableCtrl(true); // Enable control for new xml doc 
            this.Visible = true; // Make the form visible
            readOnlyToolStripMenuItem.PerformClick();
        }

        private void XmlGUI_Load(object sender, EventArgs e)
        {
            //openXmlFile(); // No need to show open dialog at start 
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    saveCurrent_Click(this,null);
                    return true;
                case Keys.Control | Keys.O:
                    OpenXmlDoc_Click(this,null);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void enableCtrl(bool status)
        {
            readOnly.Enabled = status;
            readOnlyToolStripMenuItem.Enabled = status;
            saveCurrent.Enabled = !readOnly.Checked;
        }
        
        private void readOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (newXmlDoc || currentOpenXmlPath != String.Empty)
            {
                saveCurrent.Enabled = !readOnly.Checked;
                xmlDataGrid.ReadOnly = readOnly.Checked;
                xmlDataGrid.AllowUserToDeleteRows = !readOnly.Checked;
            }
        }

        private void OpenXmlDoc_Click(object sender, EventArgs e)
        {
            openXmlFile();
        }
        
        private void saveCurrent_Click(object sender, EventArgs e)
        {
            if (!readOnly.Checked || !newXmlDoc)
            {
                XmlUtils.exportXmlData((DataTable) xmlDataGrid.DataSource, currentOpenXmlPath);
                MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenXmlPath, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (readOnly.Checked || !newXmlDoc)
            {
                MessageBox.Show(Resources.XMLGUI_saveXml_fail_msg, Resources.XMLGUI_saveXml_fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (newXmlDoc) {
                exportXmlFile();
            }
        }
        
        private void exportXmlFile()
        {
            if (xmlDataGrid.ColumnCount > 0)
            {
                using (SaveFileDialog fileDialog = new SaveFileDialog())
                {
                    //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                    fileDialog.Filter = Resources.XMLGUI_xmlfile_dialogextention;
                    fileDialog.FilterIndex = 1;
                    fileDialog.RestoreDirectory = true;

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the contents of the xmlDataGrid into the chosen file
                        XmlUtils.exportXmlData((DataTable) xmlDataGrid.DataSource, fileDialog.FileName);
                        currentOpenXmlPath = fileDialog.FileName;
                        newXmlDoc = false; // Set flag to false since the document was being exported to the disk
                        MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenXmlPath, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveEmptyXml_fail_msg,Resources.XMLGUI_saveXml_fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void loadXmlFile(Stream xmlDoc)
        {
            xmlDataGrid.DataSource = XmlUtils.getXmlData(xmlDoc).Tables[0];
        }
        private void openXmlFile(){
            using (OpenFileDialog openFileDialog = new OpenFileDialog()){
            //openFileDialog.InitialDirectory = @"%HOMEPATH%";
            openFileDialog.Filter = Resources.XMLGUI_xmlfile_dialogextention;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the contents of the file into xmlDataGrid
                Stream xmlDoc = openFileDialog.OpenFile();
                loadXmlFile(xmlDoc);
                enableCtrl(true);
                currentOpenXmlPath = openFileDialog.FileName; // Set the currentOpenPath variable to be used later for saving
                this.Text = Resources.XmlGUI_title_ + '[' +openFileDialog.SafeFileName + ']'; // Change the Forms title to currentOpenDoc #10
                xmlDoc.Close();
            }
        }
    }
        

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openXml.PerformClick();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MERZAK-X/SimpleXML");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show(Resources.XmlGUI_exitmsg, Resources.XmlGUI_exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCurrent.PerformClick();
        }

        private void toXMLDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportXmlFile();
        }

        private void editToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            readOnly_CheckedChanged(sender, e);
        }

        private void readOnly_CheckStateChanged(object sender, EventArgs e)
        {
            readOnlyToolStripMenuItem.CheckState = readOnly.CheckState;
        }

        private void readOnlyToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            readOnly.CheckState = readOnlyToolStripMenuItem.CheckState;
        }

        private void toCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (xmlDataGrid.ColumnCount > 0)
            {
                using (SaveFileDialog fileDialog = new SaveFileDialog()){
                    //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                    fileDialog.Filter = Resources.XMLGUI_csvfile_dialogextention;
                    fileDialog.FilterIndex = 1;
                    fileDialog.RestoreDirectory = true;

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the contents of the xmlDataGrid into the chosen file
                        if(XmlUtils.export2CSV(xmlDataGrid, fileDialog.FileName))
                            MessageBox.Show(Resources.XMLGUI_saveCurrent_success + fileDialog.FileName, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else 
                            MessageBox.Show(Resources.XMLGUI_saveCSV_fail_msg, Resources.XMLGUI_saveXml_fail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveXml_fail_msg, Resources.XMLGUI_saveEmptyXml_fail_msg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void XmlGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit = MessageBox.Show(Resources.XmlGUI_exitmsg, Resources.XmlGUI_exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.No) e.Cancel = true;
        }

        private void newDocument()
        {
            XML_GUI_NewTable newTableDialog = new XML_GUI_NewTable();
            //newTableDialog.Visible = true;
            /*List<String> columns = NewTableDialog.getColumnNames();
            DataTable newData = new DataTable();
            foreach (var column in columns)
            {
                newData.Columns.Add(column);
            }
            xmlDataGrid.DataSource = newData;
            NewTableDialog.Close();*/
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDocument();
            /*Thread newDocThread = new Thread(newDocument);
            newDocThread.IsBackground = false;
            newDocThread.Start();*/
        }
    }
}