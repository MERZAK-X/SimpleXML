using System;
using System.Windows.Forms;
using SimpleXML.Utils;

namespace SimpleXML
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Licenses.Syncfusion_LicenseKey);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleXml());
        }
    }
}