using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using XML_GUI.Properties;
using XML2DB.XML;

namespace XML_GUI
{
    public partial class XmlGUI : Form
    {
        public XmlGUI()
        {
            InitializeComponent();
        }

        private void XmlGUI_Load(object sender, EventArgs e)
        {
            enableCtrl(false); // Disable control since no xml doc is loaded  
            //openXmlFile(); // No need to show open dialog at start 
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                saveCurrent_Click(this,null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void enableCtrl(bool status)
        {
            readOnly.Enabled = status;
            saveCurrent.Enabled = !readOnly.Checked;
            exportXml.Enabled = status;
        }
        
        private void readOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (currentOpenXmlPath != String.Empty)
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
        private void saveXml_Click(object sender, EventArgs e)
        {
            exportXmlFile();
        }
        
        private void saveCurrent_Click(object sender, EventArgs e)
        {
            if (!readOnly.Checked)
            {
                XmlUtils.exportXmlData((DataTable) xmlDataGrid.DataSource, currentOpenXmlPath);
                MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenXmlPath, Resources.success);
            }
            else MessageBox.Show(Resources.XMLGUI_saveXml_fail_msg, Resources.XMLGUI_saveXml_fail);
        }
        
        private void exportXmlFile()
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog()){
                //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                fileDialog.Filter = Resources.XMLGUI_xmlfile_dialogextention;
                fileDialog.FilterIndex = 1;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the contents of the xmlDataGrid into the chosen file
                    XmlUtils.exportXmlData((DataTable) xmlDataGrid.DataSource, fileDialog.FileName);
                    currentOpenXmlPath = fileDialog.FileName;
                    MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenXmlPath, Resources.success);
                }
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
                currentOpenXmlPath = openFileDialog.FileName; // Set the static variable to be used later for saving
                xmlDoc.Close();
            }
        }
    }

        private static String currentOpenXmlPath = String.Empty;

    }
}