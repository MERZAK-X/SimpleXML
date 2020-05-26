using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SimpleXML.Properties;
using XMLUtils;

namespace SimpleXML
{
    public partial class SimpleXml : Form
    {
        #region Variables

        private String currentOpenDocumentPath = String.Empty;
        private bool newDocument = false;

        #endregion

        #region Constructors

        public SimpleXml()
        {
            InitializeComponent();
            enableCtrl(false); // Disable control since no xml doc is loaded  
            this.Visible = true; // Make the form visible
        }
        
        public SimpleXml(List<String> columns, String entityName)
        {
            InitializeComponent();
            this.newDocument = true; // Specify that we're making a new Xml Document
            // Fixes #25 & #43 for newly created xml documents tag names (entity name is no longer taken from file name)
            entityName = (newDocument) ? entityName : "data"; // Fixes #42
            var newData = new DataTable(entityName); // Fixes #25
            // Load DataGrid columns from List
            foreach (var column in columns)
                newData.Columns.Add(column);
            dataGrid.DataSource = newData;
            this.Text = Resources.XmlGUI_title_ + string.Format(Resources.XmlGUI__Unsaved_new_title, entityName);
            enableCtrl(true); // Enable control for new xml doc 
            this.Visible = true; // Make the form visible
            readOnlyToolStripMenuItem.PerformClick();
        }
        
        public SimpleXml(DataTable table, String entityName)
        {
            InitializeComponent();
            this.newDocument = true; // Specify that we're making a new Xml Document
            // Fixes #25 & #43 for newly created xml documents tag names (entity name is no longer taken from file name)
            table.TableName = entityName;
            dataGrid.DataSource = table;
            this.Text = Resources.XmlGUI_title_ + string.Format(Resources.XmlGUI__Unsaved_new_title, entityName);
            this.Visible = true; // Make the form visible
            enableCtrl(true);
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
            dataGrid.DataSource = XmlUtils.getXmlData(xmlDoc).Tables[0];
        }
        
        private void openFile(){
            using (var openFileDialog = new OpenFileDialog()){
                
                openFileDialog.Filter = Resources.XMLGUI_supportedfiles_opendialogExtension;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(Regex.IsMatch(Path.GetExtension(openFileDialog.FileName)?.ToLower(), @"^.*\.(xml|xlsx|xls|csv)$")){
                        Stream openedDocument = null;
                        try
                        {
                            // Load the contents of the file into dataGrid
                            openedDocument = openFileDialog.OpenFile();
                            dataGrid.DataSource = (Path.GetExtension(openFileDialog.FileName)?.ToLower() == ".xml") 
                                ? XmlUtils.getXmlData(openedDocument).Tables[0] // if it's an xml document
                                : XmlUtils.getSpreadSheetData(openedDocument as FileStream).Tables[0]; // else if (xlsx|xls|csv)
                            enableCtrl(true);
                            // TODO: implement by Excel Sheets full support. 
                            //currentOpenDocumentPath = (Path.GetExtension(openFileDialog.FileName)?.ToLower() == ".xml") ? openFileDialog.FileName : String.Empty;
                            currentOpenDocumentPath = openFileDialog.FileName;
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

        private void saveFile()
        {
            if (currentOpenDocumentPath != String.Empty)
            {
                if (!readOnly.Checked && !newDocument)
                {
                    var fileSuccessfullyExported = false;
                    switch (Path.GetExtension(currentOpenDocumentPath)?.ToLower())
                    {
                        // Save the file depending on the chosen extension, !Export -> if export fails, return instead is to display err msg only
                        case ".xml":
                            fileSuccessfullyExported = XmlUtils.ExportXML(dataGrid.DataSource as DataTable, currentOpenDocumentPath);
                            break;
                        case ".xlsx":
                            fileSuccessfullyExported = XmlUtils.ExportXLS(dataGrid.DataSource as DataTable, currentOpenDocumentPath);
                            break;
                        case ".csv":
                            fileSuccessfullyExported = XmlUtils.ExportCSV(dataGrid, currentOpenDocumentPath);
                            break;
                    }
                    if (fileSuccessfullyExported)
                        MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenDocumentPath, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    else 
                        MessageBox.Show(string.Format(Resources.XmlGUI_saveFile_fail_msg, currentOpenDocumentPath), Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (readOnly.Checked && !newDocument)
                {
                    MessageBox.Show(Resources.XMLGUI_saveXml_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (newDocument || currentOpenDocumentPath == String.Empty) {
                exportFile();
            }
        }

        private void exportFile()
        {
            if (dataGrid.ColumnCount > 0)
            {
                using (var fileDialog = new SaveFileDialog()){
                    
                    fileDialog.Filter = Resources.XMLGUI_supportedFiles_extension;
                    fileDialog.FilterIndex = 1;
                    fileDialog.RestoreDirectory = true;

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileSuccessfullyExported = false;
                        switch (Path.GetExtension(fileDialog.FileName)?.ToLower())
                        {
                            // Export the file depending on the chosen extension, !Export -> if export fails, return instead is to display err msg only
                            case ".xml":
                                fileSuccessfullyExported = XmlUtils.ExportXML(dataGrid.DataSource as DataTable, fileDialog.FileName);
                                break;
                            case ".xlsx":
                                fileSuccessfullyExported = XmlUtils.ExportXLS(dataGrid.DataSource as DataTable, fileDialog.FileName);
                                break;
                            case ".csv":
                                fileSuccessfullyExported = XmlUtils.ExportCSV(dataGrid, fileDialog.FileName);
                                break;
                        }

                        if (fileSuccessfullyExported) {
                            currentOpenDocumentPath = fileDialog.FileName;
                            this.Text = Resources.XmlGUI_title_ + '[' + Path.GetFileName(currentOpenDocumentPath) +']'; // Change the Forms title to currentOpenDoc #10
                            MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenDocumentPath, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        } else 
                            MessageBox.Show(string.Format(Resources.XmlGUI_saveFile_fail_msg, fileDialog.FileName), Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveEmptyTable_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void openXmlFile(){
            using (var openFileDialog = new OpenFileDialog()){
                //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                openFileDialog.Filter = Resources.XMLGUI_xmlfile_dialogextension;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(Path.GetExtension(openFileDialog.FileName).ToLower() == ".xml"){
                        Stream xmlDoc = null;
                        try
                        {
                            // Load the contents of the file into dataGrid
                            xmlDoc = openFileDialog.OpenFile();
                            loadXmlFile(xmlDoc);
                            enableCtrl(true);
                            currentOpenDocumentPath = openFileDialog.FileName; // Set the currentOpenPath variable to be used later for saving
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
            if (dataGrid.ColumnCount > 0)
            {
                using (var fileDialog = new SaveFileDialog())
                {
                    //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                    fileDialog.Filter = Resources.XMLGUI_xmlfile_dialogextension;
                    fileDialog.FilterIndex = 1;
                    fileDialog.RestoreDirectory = true;

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var ds = (DataTable) dataGrid.DataSource;
                        // Save the contents of the dataGrid into the chosen file
                        XmlUtils.ExportXML(ds, fileDialog.FileName);
                        currentOpenDocumentPath = fileDialog.FileName; // Save to the exported file if future edits
                        newDocument = false; // Set flag to false since the document was being exported to the disk
                        this.Text = Resources.XmlGUI_title_ + '[' + Path.GetFileName(fileDialog.FileName) +']'; // Change the Forms title to currentOpenDoc #10
                        MessageBox.Show(Resources.XMLGUI_saveCurrent_success + currentOpenDocumentPath, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveEmptyTable_fail_msg,Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void exportXlsFile()
        {
            if (dataGrid.ColumnCount > 0)
            {
                using (var fileDialog = new SaveFileDialog()){
                    //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                    fileDialog.Filter = Resources.XMLGUI_xlsfile_dialogextension;
                    fileDialog.FilterIndex = 1;
                    fileDialog.RestoreDirectory = true;

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the contents of the dataGrid into the chosen file
                        if(XmlUtils.ExportXLS(dataGrid.DataSource as DataTable, fileDialog.FileName))
                            MessageBox.Show(Resources.XMLGUI_saveCurrent_success + fileDialog.FileName, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else 
                            MessageBox.Show(Resources.XMLGUI_saveCSV_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveEmptyTable_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void exportCSVFile()
        {
            if (dataGrid.ColumnCount > 0)
            {
                using (var fileDialog = new SaveFileDialog()){
                    //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                    fileDialog.Filter = Resources.XMLGUI_csvfile_extension;
                    fileDialog.FilterIndex = 1;
                    fileDialog.RestoreDirectory = true;

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the contents of the dataGrid into the chosen file
                        if(XmlUtils.ExportCSV(dataGrid, fileDialog.FileName))
                            MessageBox.Show(Resources.XMLGUI_saveCurrent_success + fileDialog.FileName, Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else 
                            MessageBox.Show(Resources.XMLGUI_saveCSV_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveEmptyTable_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openXlsFile(){
            using (var openFileDialog = new OpenFileDialog()){
                //openFileDialog.InitialDirectory = @"%HOMEPATH%";
                openFileDialog.Filter = Resources.XMLGUI_xlsfile_dialogextension;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(Regex.IsMatch(Path.GetExtension(openFileDialog.FileName)?.ToLower(), @"^.*\.(xlsx|xls|csv)$")){
                        Stream xlsSheet = null;
                        try
                        {
                            // Load the contents of the file into dataGrid
                            xlsSheet = openFileDialog.OpenFile();
                            dataGrid.DataSource = XmlUtils.getSpreadSheetData(xlsSheet as FileStream).Tables[0];
                            enableCtrl(true);
                            // TODO: either add export Excel Sheets by saving or remove option. 
                            //currentOpenDocumentPath = openFileDialog.FileName; // Set the currentOpenPath variable to be used later for saving
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
            var exit = (e.CloseReason == CloseReason.UserClosing) // Fixes #48
                ? MessageBox.Show(Resources.XmlGUI_exit_msg, Resources.XmlGUI_exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                : DialogResult.Yes;
            if (exit == DialogResult.Yes)
            {
                foreach (var form in OwnedForms) // Fixes #41
                    form.Close();
            }
            else if (exit == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) // Ctrl + Key Hotkeys setup 
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    saveCurrent.PerformClick();
                    return true;
                /*case Keys.Control | Keys.O:
                    openXml.PerformClick();
                    return true;*/
                case Keys.Control | Keys.Alt | Keys.E:
                    exportToolStripMenuItem.PerformClick();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #endregion

        #region Buttons & Controls

        private void readOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (newDocument || currentOpenDocumentPath != String.Empty)
            {
                saveCurrent.Enabled = !readOnly.Checked;
                dataGrid.ReadOnly = readOnly.Checked;
                dataGrid.AllowUserToDeleteRows = !readOnly.Checked;
            }
        }

        private void readOnly_CheckStateChanged(object sender, EventArgs e)
        {
            readOnlyToolStripMenuItem.CheckState = readOnly.CheckState;
        }
        
        private void OpenXmlDoc_Click(object sender, EventArgs e)
        {
            openFile();
        }
        
        private void saveCurrent_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        #endregion
        
        #region Menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open a new documentDialog as a new Dialog
            new NewDocument().ShowDialog(this);
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
            // Check whether ODBConnection._Connection is open and usable  
            if (ODBConnection.valid)
            {
                try
                {
                    new IEDatabase(ODBConnection.GetTableNames()).ShowDialog();
                }
                catch (SqlException)
                {
                    MessageBox.Show(Resources.IEDatabase_connectionFail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }else{
                var result = new DatabaseConnection().ShowDialog();
                if (result == DialogResult.OK && ODBConnection.valid)
                    fromDatabaseToolStripMenuItem_Click(sender, e);
                else if (result == DialogResult.Cancel)
                    return;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show(Resources.XmlGUI_quit_msg, Resources.XmlGUI_exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }
        
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileToolStripMenuItem.HideDropDown();
            exportFile();
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
            if (dataGrid.ColumnCount > 0) // Fixes #56
            {
                // Check whether ODBConnection._Connection is open and usable  
                if (ODBConnection.valid)
                {
                    try
                    {
                        var dbTables = ODBConnection.GetTableNames();
                        var exportTable = dataGrid.DataSource as DataTable;
                        new IEDatabase(dbTables, exportTable).ShowDialog();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show(Resources.IEDatabase_connectionFail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    var result = new DatabaseConnection().ShowDialog();
                    if (result == DialogResult.OK && ODBConnection.valid)
                        toDatabaseToolStripMenuItem_Click(sender, e);
                    else if (result == DialogResult.Cancel)
                        return;
                }
            } else {
                MessageBox.Show(Resources.XMLGUI_saveEmptyTable_fail_msg, Resources.XMLGUI__fail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            readOnly_CheckedChanged(sender, e);
        }
        
        private void databaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DatabaseConnection().ShowDialog();
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
                    // Load the contents of the file into dataGrid
                    droppedDocument = new FileStream(droppedDocumentPath[0], FileMode.Open, FileAccess.Read); // [0] => the first selected file
                    dataGrid.DataSource = (Path.GetExtension(droppedDocumentPath[0])?.ToLower() == ".xml") 
                        ? XmlUtils.getXmlData(droppedDocument).Tables[0] // if it's an xml document
                        : XmlUtils.getSpreadSheetData(droppedDocument).Tables[0]; // else if (xlsx|xls|csv)
                    enableCtrl(true);
                    currentOpenDocumentPath = (Path.GetExtension(droppedDocumentPath[0])?.ToLower() == ".xml") ? droppedDocumentPath[0] : String.Empty; // Set the currentOpenPath variable to be used later for saving
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