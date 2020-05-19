using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDataReader;

namespace XMLUtils
{
    public static class XmlUtils
    {
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
            var pass = false;
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
            System.IO.File.WriteAllText(filename, sb.ToString());
            pass = true;
            
            return pass;
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