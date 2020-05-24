using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClosedXML.Excel;
using ExcelDataReader;

namespace XMLUtils
{
    public static class XmlUtils
    {
        public static bool validInput(string text) // Check for #33 
        {
            return (text != "" && Regex.IsMatch(text, @"^([a-zA-Z_][a-zA-Z0-9_]*)$"));
        }
        
        public static DataSet getXmlData(Stream xmlDoc){
            var xmlData = new DataSet();
            xmlData.ReadXml(xmlDoc);
            return xmlData;
        }

        public static DataSet getSpreadSheetData(FileStream excelSheet)
        {
            DataSet spreadSheet;
            using (IExcelDataReader excelReader = (Path.GetExtension(excelSheet.Name)?.ToLower() != ".csv") 
                ? ExcelReaderFactory.CreateReader(excelSheet)
                : ExcelReaderFactory.CreateCsvReader(excelSheet))
            {
                spreadSheet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration(){UseHeaderRow = true}
                });
                excelReader.Close();
            }
            return spreadSheet;
        }
        
        public static bool ExportXML(DataTable xmlData, String xmlDocPath)
        {
            var flag = false;
            try{
                xmlData.WriteXml(xmlDocPath);
                flag = true;
            }catch(Exception){
                flag = false;
            }
            return flag;
        }
        
        public static bool ExportCSV(DataGridView dgv, string filename)
        {
            var flag = false;
            /*// Method 1
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText; // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dgv.SelectAll(); // Select all the cell
            DataObject dataObject = dgv.GetClipboardContent(); // Copy selected cells to DataObject
            if (dataObject != null)
            {
                // Get the text of the DataObject, and serialize it to a file
                File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
                pass = true;
            }*/
            
            // Method 2
             
            var sb = new StringBuilder();
            var headers = dgv.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + SecurityElement.Escape(column.HeaderText.ToString()) + "\"").ToArray()));

            foreach (DataGridViewRow row in dgv.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + SecurityElement.Escape(cell?.Value + String.Empty) + "\"").ToArray()));
            }

            try{
                File.WriteAllText(filename, sb.ToString());
                flag = true;
            }catch(Exception){
                flag = false;
            }
            
            return flag;
        }

        public static bool ExportXLS(DataTable xlsData, string filename)
        {
            var flag = false;
            var xlsWorkbook = new XLWorkbook();
            // Add the data table to the xls sheet
            xlsWorkbook.Worksheets.Add(xlsData, xlsData.TableName);
            try{
                xlsWorkbook.SaveAs(filename);
                flag = true;
            }catch(Exception){
                flag = false;
            }
            return flag;
        }
        
    }
}