﻿using System;
using System.Data.SqlClient;
using System.Drawing;
 using System.Reflection;
 using System.Windows.Forms;

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


        private void button1_Click(object sender, EventArgs e)
        {
            if (!advancedOptions)
            {
                if (dbAuthType.Equals("Windows Authentication"))
                {
                    ODBConnection.connectionString = $"{dbName.Text}:{dbUser.Text}:{dbPass.Text}";
                    ODBConnection.winAuth = true;
                }
                else if (dbAuthType.Equals("SQLServer Authentication"))
                {
                    ODBConnection.connectionString = $"{dbName.Text}:{dbUser.Text}:{dbPass.Text}";
                    ODBConnection.winAuth = false;
                }
            }
            else if (this.advancedOptions == true)
            {
                /*
                if (instance == "" || addr == "")
                {
                    MessageBox.Show("Instance Name or Machine address is still empty!!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (auth.Equals("Windows Authentication"))
                    {
                        this.connetionString = @"Data Source=(" + addr + ")/" + instance + "," + port +
                                               ";Network Library=DBMSSOCN;Initial Catalog=" + dbname +
                                               ";Integrated Security = true";
                    }
                    else if (auth.Equals("SQLServer Authentication"))
                    {
                        this.connetionString = @"Data Source=(" + addr + ")/" + instance + "," + port +
                                               ";Network Library=DBMSSOCN;Initial Catalog=" + dbname + ";User ID=" +
                                               username + ";Password=" + password + "";
                    }
                }*/
                //ODBConnection.connectionString = $"{dbname}:{username}:{password}";
                throw new NotImplementedException();
            }


            //Connection to SQLServer

            ODBConnection.getConnection();
            //cn.OpenConection();


            string[] tb = ODBConnection.GetAllTables();

            //cn.CloseConnection();
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool stat = dbAuthType.Text.Equals("SQLServer Authentication");
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

        private void tb_ip2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tb_ip3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tb_ip4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}