using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tool_DB.Utils;

namespace Tool_DB.View
{
    public partial class Setting : Form
    {
        public SqlConnection sqlConnection;

        public Setting()
        {
            InitializeComponent();
        }

        public void getSetting()
        {
            txtServerName.Text = ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_SERVER_NAME];
            txtDatabaseName.Text = ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_DATABASE_NAME];
            txtUserName.Text = ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_USER_NAME];
            txtPassword.Text = ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_PASSWORD];
            txtSQLChar.Text = ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_SQL_CHAR];
            txtParamChar.Text = ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_PARAM_CHAR];
        }

        public void saveSetting()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings.Count == 0)
            {
                settings.Add(CONSTANTS.CONST_STRING_SERVER_NAME, txtServerName.Text);
                settings.Add(CONSTANTS.CONST_STRING_DATABASE_NAME, txtDatabaseName.Text);
                settings.Add(CONSTANTS.CONST_STRING_USER_NAME, txtUserName.Text);
                settings.Add(CONSTANTS.CONST_STRING_PASSWORD, txtPassword.Text);
                settings.Add(CONSTANTS.CONST_STRING_SQL_CHAR, txtSQLChar.Text);
                settings.Add(CONSTANTS.CONST_STRING_PARAM_CHAR, txtParamChar.Text);
            }
            else
            {
                settings[CONSTANTS.CONST_STRING_SERVER_NAME].Value = txtServerName.Text;
                settings[CONSTANTS.CONST_STRING_DATABASE_NAME].Value = txtDatabaseName.Text;
                settings[CONSTANTS.CONST_STRING_USER_NAME].Value = txtUserName.Text;
                settings[CONSTANTS.CONST_STRING_PASSWORD].Value = txtPassword.Text;
                settings[CONSTANTS.CONST_STRING_SQL_CHAR].Value = txtSQLChar.Text;
                settings[CONSTANTS.CONST_STRING_PARAM_CHAR].Value = txtParamChar.Text;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                txtServerName.Text, txtDatabaseName.Text, txtUserName.Text, txtPassword.Text);
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connection database is succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            saveSetting();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            getSetting();
        }
    }
}
