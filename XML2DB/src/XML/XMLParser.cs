using System;
using System.Xml;
using System.Xml.Schema;

namespace XML2DB.XML
{
    public static class XMLParser
    {
        public static void TEST()
        {
            var someXmlFile = new XmlDocument();
            someXmlFile.Load(Environment.CurrentDirectory + @"../../../lib/examples/contosoBooks.xml");
            var fileLoaded = checkValidXML(someXmlFile);
            Console.WriteLine("TEST " + (fileLoaded ? "PASS" : "FAIL"));
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
        
        
        
    }
}