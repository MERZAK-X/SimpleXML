using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
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
        
        public XmlGUI(List<String> columns, String entityName)
        {
            InitializeComponent();
            this.newXmlDoc = true; // Specify that we're making a new Xml Document
            // Fixes #25 & #43 for newly created xml documents tag names (entity name is no longer taken from file name)
            entityName = (newXmlDoc) ? entityName : "data"; // Fixes #42
            var newData = new DataTable(entityName); // Fixes #25
            // Load DataGrid columns from List
            foreach (var column in columns)
                newData.Columns.Add(column);
            xmlDataGrid.DataSource = newData;
            this.Text = Resources.XmlGUI_title_ + string.Format(Resources.XmlGUI__Unsaved_new_title, entityName);
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
        
        private void loadXmlFile(Stream xmlDoc)
        {
            xmlDataGrid.DataSource = XmlUtils.getXmlData(xmlDoc).Tables[0];
        }
        
        private void openFile(){
            using (var openFileDialog = new OpenFileDialog()){
                
                openFileDialog.Filter = Resources.XMLGUI_supportedfiles_dialogextention;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(Regex.IsMatch(Path.GetExtension(openFileDialog.FileName)?.ToLower(), @"^.*\.(xml|xlsx|xls|csv)$")){
                        Stream openedDocument = null;
                        try
                        {
                            // Load the contents of the file into xmlDataGrid
                            openedDocument = openFileDialog.OpenFile();
                            xmlDataGrid.DataSource = (Path.GetExtension(openFileDialog.FileName)?.ToLower() == ".xml") 
                                ? XmlUtils.getXmlData(openedDocument).Tables[0] // if it's an xml document
                                : XmlUtils.getSpreadSheetData(openedDocument as FileStream).Tables[0]; // else if (xlsx|xls|csv)
                            enableCtrl(true);
                            // TODO: implement by Excel Sheets full support. 
                            currentOpenXmlPath = (Path.GetExtension(openFileDialog.FileName)?.ToLower() == ".xml") ? openFileDialog.FileName : String.Empty;
                            this.Text = Resources.XmlGUI_title_ + '[' + openFileDialog.SafeFileName +']'; // Change the Forms title to currentOpenDoc #10
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(Resources.XmlGUI_OpenDoc_fail_msg, Resources.XMLGUI__fail,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            // Fixes #29 file lock issue
                            openedDocument?.Close();
                        }
                    
                    } else {
                        MessageBox.Show(Resources.XmlGUI_OpenDoc_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        
        private void openXmlFile(){
            using (var openFileDialog = new OpenFileDialog()){
                //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                openFileDialog.Filter = Resources.XMLGUI_xmlfile_dialogextention;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(Path.GetExtension(openFileDialog.FileName).ToLower() == ".xml"){
                        Stream xmlDoc = null;
                        try
                        {
                            // Load the contents of the file into xmlDataGrid
                            xmlDoc = openFileDialog.OpenFile();
                            loadXmlFile(xmlDoc);
                            enableCtrl(true);
                            currentOpenXmlPath = openFileDialog.FileName; // Set the currentOpenPath variable to be used later for saving
                            this.Text = Resources.XmlGUI_title_ + '[' + openFileDialog.SafeFileName +']'; // Change the Forms title to currentOpenDoc #10
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(Resources.XmlGUI_OpenXmlDoc_fail_msg, Resources.XMLGUI__fail,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            // Fixes #29 file lock issue
                            xmlDoc?.Close();
                        }
                    
                    } else {
                        MessageBox.Show(Resources.XmlGUI_Open_wrongXmlExt_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        
        private void exportXmlFile()
        {
            if (xmlDataGrid.ColumnCount > 0)
            {
                using (var fileDialog = new SaveFileDialog())
                {
                    //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                    fileDialog.Filter = Resources.XMLGUI_xmlfile_dialogextention;
                    fileDialog.FilterIndex = 1;
                    fileDialog.RestoreDirectory = true;

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var ds = (DataTable) xmlDataGrid.DataSource;
                        // Save the contents of the xmlDataGrid into the chosen file
                        XmlUtils.exportXmlData(ds, fileDialog.FileName);
                        currentOpenXmlPath = fileDialog.FileName; // Save to the exported file if future edits
                        newXmlDoc = false; // Set flag to false since the document was being exported to the disk
                        this.Text = Resources.XmlGUI_title_ + '[' + Path.GetFileName(fileDialog.FileName) +']'; // Change the Forms title to currentOpenDoc #10
                        MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenXmlPath, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveEmptyXml_fail_msg,Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void exportXlsFile()
        {
            if (xmlDataGrid.ColumnCount > 0)
            {
                using (var fileDialog = new SaveFileDialog()){
                    //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                    fileDialog.Filter = Resources.XMLGUI_xlsfile_dialogextention;
                    fileDialog.FilterIndex = 1;
                    fileDialog.RestoreDirectory = true;

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the contents of the xmlDataGrid into the chosen file
                        if(XmlUtils.export2Xls(xmlDataGrid.DataSource as DataSet, fileDialog.FileName))
                            MessageBox.Show(Resources.XMLGUI_saveCurrent_success + fileDialog.FileName, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else 
                            MessageBox.Show(Resources.XMLGUI_saveCSV_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveEmptyXml_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void exportCSVFile()
        {
            if (xmlDataGrid.ColumnCount > 0)
            {
                using (var fileDialog = new SaveFileDialog()){
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
                            MessageBox.Show(Resources.XMLGUI_saveCSV_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveEmptyXml_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openXlsFile(){
            using (var openFileDialog = new OpenFileDialog()){
                //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                openFileDialog.Filter = Resources.XMLGUI_xlsfile_dialogextention;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(Regex.IsMatch(Path.GetExtension(openFileDialog.FileName)?.ToLower(), @"^.*\.(xlsx|xls|csv)$")){
                        Stream xlsSheet = null;
                        try
                        {
                            // Load the contents of the file into xmlDataGrid
                            xlsSheet = openFileDialog.OpenFile();
                            xmlDataGrid.DataSource = XmlUtils.getSpreadSheetData(xlsSheet as FileStream).Tables[0];
                            enableCtrl(true);
                            // TODO: either add export Excel Sheets by saving or remove option. 
                            //currentOpenXmlPath = openFileDialog.FileName; // Set the currentOpenPath variable to be used later for saving
                            this.Text = Resources.XmlGUI_title_ + '[' + openFileDialog.SafeFileName +']'; // Change the Forms title to currentOpenDoc #10
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(Resources.XmlGUI_OpenXlsSheet_fail_msg, Resources.XMLGUI__fail,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            // Fixes #29 file lock issue
                            xlsSheet?.Close();
                        }
                    
                    } else {
                        MessageBox.Show(Resources.XmlGUI_DragDrop_wrongExt_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
            var exit = MessageBox.Show(Resources.XmlGUI_exit_msg, Resources.XmlGUI_exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.No) e.Cancel = true;
            foreach (var form in OwnedForms) // Fixes #41
                form.Close();
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
            if (currentOpenXmlPath != String.Empty)
            {
                if (!readOnly.Checked && !newXmlDoc)
                {
                    XmlUtils.exportXmlData((DataTable) xmlDataGrid.DataSource, currentOpenXmlPath);
                    MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenXmlPath, Resources.success,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (readOnly.Checked && !newXmlDoc)
                {
                    MessageBox.Show(Resources.XMLGUI_saveXml_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else if (newXmlDoc || currentOpenXmlPath == String.Empty) {
                exportXmlFile();
            }
        }

        #endregion
        
        #region Menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open a new documentDialog as a new Dialog
            new XML_GUI_NewTable().ShowDialog(this);
            /*var newDocThread = new Thread(() => Application.Run(new XML_GUI_NewTable(){Owner = this}));
            newDocThread.SetApartmentState(ApartmentState.STA);
            newDocThread.IsBackground = false;
            newDocThread.Start();*/
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }
        
        private void excelSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openXlsFile();
        }

        private void fromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: @Yassine-Ag Implement your form here
            // Open a new databaseConnectionDialog as a new Dialog
            new DatabaseConnection().ShowDialog(this);
            /*Thread DBThread = new Thread(() => Application.Run(new DatabaseConnection()));
            DBThread.SetApartmentState(ApartmentState.STA);
            DBThread.IsBackground = false;
            DBThread.Start();*/
            //throw new System.NotImplementedException();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show(Resources.XmlGUI_exit_msg, Resources.XmlGUI_exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        
        private void toXLSXExcelSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportXlsFile();
        }

        private void toCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportCSVFile();
        }
        
        private void toDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: @Yassine-Ag Implement your form here
            // Open a new databaseConnectionDialog as a new Thread
            /*Thread DBThread = new Thread(() => Application.Run(new XML_GUI_DB_Export()));
            DBThread.IsBackground = false;
            DBThread.Start();*/
            throw new System.NotImplementedException();
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

        #region Drag&Drop Event

        private void xmlDataGrid_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void xmlDataGrid_DragDrop(object sender, DragEventArgs e)
        {
            var droppedDocumentPath = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            if (droppedDocumentPath.Length > 1) MessageBox.Show(Resources.XmlGUI_DragDrop_many_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if(Regex.IsMatch(Path.GetExtension(droppedDocumentPath[0])?.ToLower(), @"^.*\.(xml|xlsx|xls|csv)$")){
                FileStream droppedDocument = null;
                try
                {
                    // Load the contents of the file into xmlDataGrid
                    droppedDocument = new FileStream(droppedDocumentPath[0], FileMode.Open, FileAccess.Read); // [0] => the first selected file
                    xmlDataGrid.DataSource = (Path.GetExtension(droppedDocumentPath[0])?.ToLower() == ".xml") 
                        ? XmlUtils.getXmlData(droppedDocument).Tables[0] // if it's an xml document
                        : XmlUtils.getSpreadSheetData(droppedDocument).Tables[0]; // else if (xlsx|xls|csv)
                    enableCtrl(true);
                    currentOpenXmlPath = (Path.GetExtension(droppedDocumentPath[0])?.ToLower() == ".xml") ? droppedDocumentPath[0] : String.Empty; // Set the currentOpenPath variable to be used later for saving
                    this.Text = Resources.XmlGUI_title_ + '[' + Path.GetFileName(droppedDocumentPath[0]) +']'; // Change the Forms title to currentOpenDoc #10
                }
                catch (Exception)
                {
                    MessageBox.Show(Resources.XmlGUI_OpenDoc_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Fixes #29 file lock issue
                    droppedDocument?.Close();
                }
            } else {
                MessageBox.Show(Resources.XmlGUI_DragDrop_wrongExt_msg, Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
        
        #endregion

    }
}