using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            xmlDataGrid.DataSource = XML2DB.XML.XMLParser.getXmlData(@"C:\Users\MS7WN7D V3N0M\Documents\ISMO-NTIC\XML\contosoBooks.xml");
            //xmlDataGrid.DataSource
        }
    }
}