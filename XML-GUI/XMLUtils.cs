using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLUtils
{
    public static class XmlUtils
    {
        /*static void printData(XmlDocument xmlDoc, List<String> NodeNames)
        {
            xmlDoc.Load(Environment.CurrentDirectory + @"../../../lib/examples/test.xml");
            Console.WriteLine(xmlDoc.DocumentElement.SelectSingleNode(NodeNames[0]).InnerText);
            // TODO: Test in Windows OS with WinForms
        }*/
        
        public static DataSet getXmlData(String xmlDocPath){
            DataSet xmlData = new DataSet();
            xmlData.ReadXml(xmlDocPath);
            return xmlData;
        }
        
        public static DataSet getXmlData(Stream xmlDoc){
            DataSet xmlData = new DataSet();
            xmlData.ReadXml(xmlDoc);
            return xmlData;
        }
        
        public static void exportXmlData(DataTable xmlData, String xmlDocPath)
        {
            xmlData.WriteXml(xmlDocPath);
        }

        public static bool export2DB(DataTable xmlData, String connectionString)
        {
            bool pass = false;
            //string connectionString = @"Data Source = ServerName/Instance; Integrated Security=true; Initial Catalog=Database";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
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
            bool pass = false;
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
        
    }
}