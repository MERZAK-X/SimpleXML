using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
        
        public static DataSet getXmlData(String xmlDocPath){
            var xmlData = new DataSet();
            xmlData.ReadXml(xmlDocPath);
            return xmlData;
        }
        
        public static DataSet getXmlData(Stream xmlDoc){
            var xmlData = new DataSet();
            xmlData.ReadXml(xmlDoc);
            return xmlData;
        }
        
        public static void exportXmlData(DataTable xmlData, String xmlDocPath)
        {
            xmlData.WriteXml(xmlDocPath);
        }

        public static bool export2DB(DataTable xmlData, String connectionString)
        {
            var pass = false;
            //string connectionString = @"Data Source = ServerName/Instance; Integrated Security=true; Initial Catalog=Database";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    foreach (DataColumn c in xmlData.Columns)
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
 
                    bulkCopy.DestinationTableName = xmlData.TableName;
                    try
                    {
                        bulkCopy.WriteToServer(xmlData);
                        pass = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        pass = false;
                    }
                }
            }

            return pass;
        }
        
        public static bool export2CSV(DataGridView dgv, string filename)
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
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dgv.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            try{
                File.WriteAllText(filename, sb.ToString());
                flag = true;
            }catch(Exception){
                flag = false;
            }
            
            return flag;
        }

        public static bool export2Xls(DataTable xlsData, string filename)
        {
            var flag = false;
            var xlsWorkbook = new XLWorkbook();
            // Add the data table to the xls sheet
            xlsWorkbook.Worksheets.Add(xlsData, xlsData.TableName);
            
            /*
                //using GemBox.Spreadsheet
                
            // Import all tables from DataSet the new workbook
            foreach (DataTable dataTable in xlsData.Tables)
            {
                // Add new worksheet to the file.
                var xlsSheet = xlsWorkbook.Worksheets.Add(dataTable.TableName);
                // Change the value of the first cell in the DataTable.
                dataTable.Rows[0][0] = "TEST";
                // Insert the data from DataTable to the worksheet starting at cell "A1".
                xlsSheet.InsertDataTable(dataTable,
                    new InsertDataTableOptions("A1") { ColumnHeaders = true });
            }*/

            try{
                xlsWorkbook.SaveAs(filename);
                flag = true;
            }catch(Exception){
                flag = false;
            }

            return flag;
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
        
    }
}