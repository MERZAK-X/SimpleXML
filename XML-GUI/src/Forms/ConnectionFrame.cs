﻿using System;
using System.Data.SqlClient;
using System.Drawing;
 using System.Reflection;
 using System.Windows.Forms;
 using XML_GUI.Properties;

 namespace XML2DB
{
    public partial class ConnectionFrame : Form
    {
        bool advancedOptions = false;

        public ConnectionFrame()
        {
            InitializeComponent();
            /*Icon = new Icon(
                Assembly.GetExecutingAssembly().GetManifestResourceStream("lib/icons/ssms.ico")
            );*/
            this.Height += advancedOptions ? advancedOptionsPanel.Height : -advancedOptionsPanel.Height;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            dbAuthType.SelectedItem = "Windows Authentication";
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (!advancedOptions)
            {
                ODBConnection.remote = false;
                if (dbAuthType.SelectedItem.Equals("Windows Authentication"))
                {
                    ODBConnection.connectionString = $"{dbName.Text}:{dbUser.Text}:{dbPass.Text}";
                    ODBConnection.winAuth = true;
                }
                else if (dbAuthType.SelectedItem.Equals("SQLServer Authentication"))
                {
                    ODBConnection.connectionString = $"{dbName.Text}:{dbUser.Text}:{dbPass.Text}";
                    ODBConnection.winAuth = false;
                }
            }
            else if (advancedOptions)
            {
                if (serverInstance.Text == "" || serverHostname.Text == "")
                {
                    MessageBox.Show("Instance name or server address is still empty !", Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    ODBConnection.remote = true;
                    if (dbAuthType.SelectedItem.Equals("Windows Authentication"))
                    {
                        ODBConnection.winAuth = true;
                        ODBConnection.connectionString = $"{dbName.Text}:{dbUser.Text}:{dbPass.Text}:{serverHostname.Text}:{serverInstance}";
                    }
                    else
                    {
                        ODBConnection.winAuth = false;
                        ODBConnection.connectionString = $"{dbName.Text}:{dbUser.Text}:{dbPass.Text}:{serverHostname.Text}:{serverInstance}";
                    }
                }
            }

            try
            {
                //ODBConnection.getConnection();
                ODBConnection.TableToXml("employees");
            }
            catch (SqlException sqle)
            {
                MessageBox.Show($"Connection failed :\nError-{sqle.Number} : {sqle.Message}", Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            //string[] tb = ODBConnection.GetAllTables();

            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }




        private void dbAuthType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool stat = dbAuthType.Text.Equals("SQL-Server Authentication");
            lbl_pwd.Enabled = stat;
            lbl_usr.Enabled = stat;
            dbUser.Enabled = stat;
            dbPass.Enabled = stat;
        }

        private void btn_cl_Click(object sender, EventArgs e)
        {
            this.Dispose();this.Close();
        }

        private void options_Click(object sender, EventArgs e)
        {
            advancedOptions = !advancedOptions;
            advancedOptionsPanel.Visible = advancedOptions;
            this.Height += advancedOptions ? +advancedOptionsPanel.Height : -advancedOptionsPanel.Height;
            this.options.Text = advancedOptions ? "Options <<" : "Options >>";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        
    }
}