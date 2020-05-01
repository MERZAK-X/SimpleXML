using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xmlDataGrid.DataSource = XML2DB.XML.XMLParser.getXmlData(@"C:\Users\MS7WN7D V3N0M\Documents\ISMO-NTIC\XML\contosoBooks.xml").Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openXmlFile();
        }
        private void saveXml_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        
        
        private void loadXmlFile(Stream xmlFile)
        {
            xmlDataGrid.DataSource = XML2DB.XML.XMLParser.getXmlData(xmlFile).Tables[0];
        }
        private void openXmlFile(){
            using (OpenFileDialog openFileDialog = new OpenFileDialog()){
            //openFileDialog.InitialDirectory = @"%HOMEPATH%";
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Load the contents of the file into xmlDataGrid
                loadXmlFile(openFileDialog.OpenFile());
            }
        }
    }

        private static Stream xmlDoc;

    }
}