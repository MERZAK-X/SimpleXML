using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SimpleXML.Properties;
using XMLUtils;

 namespace SimpleXML
{
    public partial class DatabaseConnection : Form
    {
        bool advancedOptions = false, connectionSuccess = false;

        public DatabaseConnection()
        {
            InitializeComponent();
            this.Height += advancedOptions ? advancedOptionsPanel.Height : -advancedOptionsPanel.Height;
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            dbAuthType.SelectedItem = "Windows Authentication";
        }

        private void DatabaseConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
           //if (e.CloseReason == CloseReason.UserClosing) this.DialogResult = DialogResult.Cancel;
        }

        private void connect_Click(object sender, EventArgs e)
        {
            var databaseName = String.Empty;
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
                if (serverHostname.Text == "")
                {
                    MessageBox.Show("Server address is still empty !", Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    if (serverInstance.Text == "" || serverInstance.Text == "\\")
                    {
                        var result = MessageBox.Show(Resources.DatabaseConnection_emptyInstance_msg, Resources.XMLGUI__warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                        serverInstance.Text = "";
                    }
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
                databaseName = ODBConnection.getConnection().Database;
                connectionSuccess = true;
            }
            catch (SqlException sqle)
            {
                MessageBox.Show(string.Format(Resources.Connection_fail_msg, sqle.Number, sqle.Message), Resources.XMLGUI__warning, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(string.Format(Resources.IEDatabase_successConnection_msg, databaseName), Resources.success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.DialogResult = DialogResult.OK;
            this.Close();
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        private void dbName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) connect.PerformClick();
        }
    }
}