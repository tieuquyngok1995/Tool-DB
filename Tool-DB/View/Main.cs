using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tool_DB.View;
using Tool_DB.Utils;
using System.Configuration;

namespace Tool_DB.View
{
    public partial class Main : Form
    {
        Connection con;
        SqlConnection sqlConnection;

        public string textRowSelect = string.Empty;
        public bool statusConnection = false;

        public Main()
        {
            InitializeComponent();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting frmSetting = new Setting();

            frmSetting.ShowDialog();
            frmSetting.Dispose();

            if (frmSetting.DialogResult == DialogResult.OK)
            {
                sqlConnection = frmSetting.sqlConnection;
                if (sqlConnection != null && sqlConnection.State.Equals(System.Data.ConnectionState.Open))
                {
                    statusConnection = true;
                    txtStatus.Text = string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_CONNECTION);
                }
                else
                {
                    statusConnection = false;
                    txtStatus.Text = string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_DISCONNECT);
                }
                btnInputSQL.Enabled = statusConnection;
                btnInputParam.Enabled = statusConnection;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtStatus.Text = CheckIsConnection()
                ? string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_CONNECTION)
                : string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_DISCONNECT);

            btnInputSQL.Enabled = statusConnection;
            btnInputParam.Enabled = statusConnection;

            if (dataGridView.Rows.Count == 0)
            {
                btnInputParam.Enabled = false;
            }
        }

        private bool CheckIsConnection()
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
               ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_SERVER_NAME],
               ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_DATABASE_NAME],
               ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_USER_NAME],
               ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_PASSWORD]);

            try
            {
                con = new Connection(connectionString);
                if (con.IsConnection)
                {
                    statusConnection = true;
                    return true;
                }

            }
            catch (Exception)
            {
            }
            statusConnection = false;
            return false;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (statusConnection) return;

            Setting frmSetting = new Setting();

            frmSetting.ShowDialog();
            frmSetting.Dispose();

            if (frmSetting.DialogResult == DialogResult.OK)
            {
                sqlConnection = frmSetting.sqlConnection;
                if (sqlConnection != null && sqlConnection.State.Equals(System.Data.ConnectionState.Open))
                {
                    statusConnection = true;
                    txtStatus.Text = string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_CONNECTION);
                }
                else
                {
                    statusConnection = false;
                    txtStatus.Text = string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_DISCONNECT);
                }
                btnInputSQL.Enabled = statusConnection;
                btnInputParam.Enabled = statusConnection;
            }
        }

        private void btnInputSQL_Click(object sender, EventArgs e)
        {
            InputSQL frmInputSQL = new InputSQL();

            frmInputSQL.ShowDialog();
            frmInputSQL.Dispose();

            if (frmInputSQL.DialogResult == DialogResult.OK)
            {
                dataGridView.DataSource = frmInputSQL.data;

                if (dataGridView.Rows.Count == 0)
                {
                    dataGridView.Visible = false;
                    btnInputParam.Enabled = false;
                }
                else
                {
                    dataGridView.Visible = true;
                    btnInputParam.Enabled = true;
                }
            }
        }

        private void btnInputParam_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];
            textRowSelect = selectedRow.Cells[CONSTANTS.CONST_STRING_COLUMNS_SQL].Value.ToString();
            InputParam frmInputParam = new InputParam(textRowSelect);
            frmInputParam.ShowDialog();
            frmInputParam.Dispose();
        }
    }
}
