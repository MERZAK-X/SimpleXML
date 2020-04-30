using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting;
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
        
        
    }
}