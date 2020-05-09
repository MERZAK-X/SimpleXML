using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using XMLUtils;
using XML_GUI.Properties;

namespace XML_GUI
{
    public partial class XmlGUI : Form
    {
        #region Variables

        private String currentOpenXmlPath = String.Empty;
        private bool newXmlDoc = false;

        #endregion

        #region Constructors

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
            DataTable newData = new DataTable("XmlDocument");
            foreach (var column in columns){newData.Columns.Add(column);}
            xmlDataGrid.DataSource = newData;
            enableCtrl(true); // Enable control for new xml doc 
            this.Visible = true; // Make the form visible
            readOnlyToolStripMenuItem.PerformClick();
        }

        #endregion

        #region Functions and Methods

        private void enableCtrl(bool status)
        {
            readOnly.Enabled = status;
            readOnlyToolStripMenuItem.Enabled = status;
            saveCurrent.Enabled = !readOnly.Checked;
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
                        currentOpenXmlPath = fileDialog.FileName; // Save to the exported file if future edits
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

        #endregion

        #region Events Methods

        #region Form & Hotkeys

        private void XmlGUI_Load(object sender, EventArgs e)
        {
            //openXmlFile(); // No need to show open dialog at start 
        }
        
        private void XmlGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit = MessageBox.Show(Resources.XmlGUI_exitmsg, Resources.XmlGUI_exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.No) e.Cancel = true;
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) // Ctrl + Key Hotkeys setup 
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    saveCurrent.PerformClick();
                    return true;
                case Keys.Control | Keys.O:
                    openXml.PerformClick();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #endregion

        #region Buttons & Controls

        private void readOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (newXmlDoc || currentOpenXmlPath != String.Empty)
            {
                saveCurrent.Enabled = !readOnly.Checked;
                xmlDataGrid.ReadOnly = readOnly.Checked;
                xmlDataGrid.AllowUserToDeleteRows = !readOnly.Checked;
            }
        }

        private void readOnly_CheckStateChanged(object sender, EventArgs e)
        {
            readOnlyToolStripMenuItem.CheckState = readOnly.CheckState;
        }
        
        private void OpenXmlDoc_Click(object sender, EventArgs e)
        {
            openXmlFile();
        }
        
        private void saveCurrent_Click(object sender, EventArgs e)
        {
            if (!readOnly.Checked && !newXmlDoc)
            {
                XmlUtils.exportXmlData((DataTable) xmlDataGrid.DataSource, currentOpenXmlPath);
                MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenXmlPath, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (readOnly.Checked && !newXmlDoc)
            {
                MessageBox.Show(Resources.XMLGUI_saveXml_fail_msg, Resources.XMLGUI_saveXml_fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (newXmlDoc) {
                exportXmlFile();
            }
        }

        #endregion
        
        #region Menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open a new documentDialog as a new Thread
            Thread newDocThread = new Thread(() => Application.Run(new XML_GUI_NewTable()));
            newDocThread.IsBackground = false;
            newDocThread.Start();
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openXml.PerformClick();
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
                MessageBox.Show(Resources.XMLGUI_saveEmptyXml_fail_msg, Resources.XMLGUI_saveXml_fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            readOnly_CheckedChanged(sender, e);
        }

        private void readOnlyToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            readOnly.CheckState = readOnlyToolStripMenuItem.CheckState;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MERZAK-X/SimpleXML"); // Opens repo's homepage
        }

        #endregion

        #endregion
    }
}