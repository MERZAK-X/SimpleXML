using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace XML2DB.XML
{
    public static class XMLParser
    {
        public static void TEST()
        {
            var someXmlFile = new XmlDocument();
            var NodeNames = new List<String>();
            NodeNames.Add("TEST");
            /*someXmlFile.Load(Environment.CurrentDirectory + @"../../../lib/examples/contosoBooks.xml");
            var fileLoaded = checkValidXML(someXmlFile);
            Console.WriteLine("TEST " + (fileLoaded ? "PASS" : "FAIL"));*/
            printData(someXmlFile, NodeNames);
        }
        
        public static bool checkValidXML(XmlDocument xmlFile)
        {
            foreach (XmlNode node in xmlFile.DocumentElement) //SelectNodes("/bookstore/book")
            {
                foreach (XmlAttribute _ in node.Attributes)
                {
                    Console.WriteLine(_.InnerText);
                    //foreach (XmlNode child in xmlFile.DocumentElement.Attributes)
                    //{
                        //Console.WriteLine(child.InnerText);
                      //  Console.WriteLine("----------------------");
                    //}
                }
                Console.WriteLine("----------------------");
            }

            return true;
        }

        static void printData(XmlDocument xmlDoc, List<String> NodeNames)
        {
            xmlDoc.Load(Environment.CurrentDirectory + @"../../../lib/examples/test.xml");
            Console.WriteLine(xmlDoc.DocumentElement.SelectSingleNode(NodeNames[0]).InnerText);
            // TODO: Test in Windows OS with WinForms
        }
        
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
        
        /*public static (String, StreamReader) openXmlFile(){
            
            var fileContent = string.Empty;
            var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XML files (*.xml)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
                return (filePath, fileContent);
        }*/

        public static bool export2DB(DataTable xmlData, String connectionString)
        {
            bool pass = false;
            //string connectionString = @"Data Source = MyServerName/Instance; Integrated Security=true; Initial Catalog=YourDatabase";
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
        
    }
}