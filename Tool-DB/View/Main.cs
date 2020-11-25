using System;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Tool_DB.Model;
using Tool_DB.Utils;

namespace Tool_DB.View
{
    public partial class Main : Form
    {
        SQLConnection con;
        SqlConnection sqlConnection;

        private DataTable dataSQL = new DataTable();
        private DataTable dataParam = new DataTable();
        private DataRow row;

        private string strSQLChar = string.Empty;
        private string strInputSQL = string.Empty;

        private bool statusConnection = false;
        private bool end = false;

        private int numSelectCase = 0;

        #region Main
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
                    btnExcute.Enabled = true;
                    txtStatus.Text = string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_CONNECTION);
                }
                else
                {
                    statusConnection = false;
                    btnExcute.Enabled = false;
                    txtStatus.Text = string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_DISCONNECT);
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtStatus.Text = CheckIsConnection()
                ? string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_CONNECTION)
                : string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_DISCONNECT);

            // load data input sql
            dataSQL.Columns.Add(CONSTANTS.CONST_STRING_COLUMNS_ID);
            dataSQL.Columns.Add(CONSTANTS.CONST_STRING_COLUMNS_SQL);

            // load data input param
            dataParam.Columns.Add(CONSTANTS.CONST_STRING_COLUMNS_PARAM);
            dataParam.Columns.Add(CONSTANTS.CONST_STRING_COLUMNS_VALUE);

            txtSQLChar.Text = ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_SQL_CHAR];
            btnConvert.Enabled = false;
            btnExcute.Enabled = false;
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
                    btnExcute.Enabled = true;
                    txtStatus.Text = string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_CONNECTION);
                }
                else
                {
                    statusConnection = false;
                    btnExcute.Enabled = false;
                    txtStatus.Text = string.Format(CONSTANTS.CONST_STRING_STATUS, CONSTANTS.CONST_STRING_STATUS_DISCONNECT);
                }
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
                con = new SQLConnection(connectionString);
                if (con.IsConnection)
                {
                    statusConnection = true;
                    return true;
                }

            }
            catch (Exception)
            {
                statusConnection = false;
                return false;
            }
            statusConnection = false;
            return false;
        }

        #endregion

        #region Input SQL
        private void btnFormat_Click(object sender, EventArgs e)
        {
            strSQLChar = txtSQLChar.Text.Trim();

            if (!string.IsNullOrEmpty(txtInputSQL.Text))
            {
                dataSQL.Clear();
                dataParam.Clear();
                lstDataSQL.Visible = true;
                lstInputParam.Visible = true;
                handleStringInput();
            }
            else
            {
                dataSQL.Clear();
                dataParam.Clear();
                lstDataSQL.Visible = false;
                lstInputParam.Visible = false;
            }

            lstDataSQL.DataSource = dataSQL;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInputSQL.Text = string.Empty;
            txtSQLChar.Text = string.Empty;
            lstDataSQL.DataSource = null;
            lstInputParam.DataSource = null;
            lstDataSQL.Visible = false;
            lstInputParam.Visible = false;
            btnConvert.Enabled = false;
            dataSQL.Clear();
        }

        private void handleStringInput()
        {
            string resultFormat = handFormatStringInput(txtInputSQL.Text);
            if (numSelectCase == 0)
            {
                row = dataSQL.NewRow();
                row[CONSTANTS.CONST_STRING_COLUMNS_ID] = 1;
                row[CONSTANTS.CONST_STRING_COLUMNS_SQL] = resultFormat;
                dataSQL.Rows.Add(row);
            }
            else
            {
                string[] arrInputSQL = resultFormat.Split(new string[] { CONSTANTS.CONST_STRING_CHECK_SELECT_CASE }, StringSplitOptions.None);
                handledSelectCaseString(arrInputSQL[0], arrInputSQL[1]);
            }

            numSelectCase = 0;
        }

        private string handFormatStringInput(string strInputSQL)
        {
            List<string> listString = new List<string>();
            string[] arrInputSQL = strInputSQL.Split(CONSTANTS.CONST_CHAR_LINE_BREAK);

            string regex = "[\u3040-\u30ff\u3400-\u4dbf\u4e00-\u9fff\uf900-\ufaff\uff66-\uff9f]";
            string result = string.Empty;
            string item = string.Empty;

            arrInputSQL = arrInputSQL.Where(
                (val, idx) => !(val.Contains(CONSTANTS.CONST_STRING_CHECK_APOSTROPHE) && (Regex.IsMatch(val, regex)
                             || val.Contains(CONSTANTS.CONST_STRING_CHECK_ADD_END) || val.Contains(CONSTANTS.CONST_STRING_CHECK_HASH)
                             || val.Contains(CONSTANTS.CONST_STRING_CHECK_REP_START) || val.Contains(CONSTANTS.CONST_STRING_CHECK_REP_END)
                             || val.Contains(CONSTANTS.CONST_STRING_CHECK_HYPHEN))) && !string.Empty.Equals(val)
                             && !val.Contains(string.Format(CONSTANTS.CONST_STRING_CHECK_APOSTROPHE_VALUE, strSQLChar))).ToArray();

            for (int i = 0; i < arrInputSQL.Length; i++)
            {
                item = arrInputSQL[i];

                item = item.Replace(CONSTANTS.CONST_STRING_TAB, string.Empty);
                if (string.Empty.Equals(item)) continue;

                // Replace format
                item = item.TrimStart();
                item = CUtils.ReplaceStringFormat(item, CONSTANTS.CONST_STRING_FORMAT_01, CONSTANTS.CONST_STRING_REPLACE_01, strSQLChar);
                item = CUtils.ReplaceStringFormat(item, CONSTANTS.CONST_STRING_FORMAT_02, CONSTANTS.CONST_STRING_REPLACE_02);
                item = CUtils.ReplaceStringFormat(item, CONSTANTS.CONST_STRING_FORMAT_03, CONSTANTS.CONST_STRING_REPLACE_03);
                item = Regex.Replace(item, CONSTANTS.CONST_STRING_FORMAT_04, CONSTANTS.CONST_STRING_REPLACE_04);
                item = Regex.Replace(item, CONSTANTS.CONST_STRING_FORMAT_05, CONSTANTS.CONST_STRING_REPLACE_05);
                if (item.EndsWith("\""))
                {
                    item = item.Remove(item.Length - 1);
                }

                // Format str SQL
                if (item.Contains(string.Format(CONSTANTS.CONST_STRING_CHECK_CONTAINS_01, strSQLChar)))
                {
                    item = CUtils.ReplaceStringFormat(item, CONSTANTS.CONST_STRING_CHECK_CONTAINS_01, string.Empty, strSQLChar);
                }
                else if (item.Contains(string.Format(CONSTANTS.CONST_STRING_CHECK_CONTAINS_02, strSQLChar)))
                {
                    item = CUtils.ReplaceStringFormat(item, CONSTANTS.CONST_STRING_CHECK_CONTAINS_02, string.Empty, strSQLChar);
                }
                else if (Regex.IsMatch(item, CONSTANTS.CONST_REGEX_WORD_CHARACTER))
                {
                    continue;
                }

                // add value in list
                if ((item.Contains(CONSTANTS.CONST_STRING_CHECK_IF) && !item.Contains(CONSTANTS.CONST_STRING_CHECK_END_IF))
                    || item.Contains(CONSTANTS.CONST_STRING_CHECK_ELSE))
                {
                    result = result + item.Trim() + CONSTANTS.CONST_CHAR_LINE_BREAK;
                }
                else if (item.Contains(CONSTANTS.CONST_STRING_CHECK_END_IF))
                {
                    continue;
                }
                else if (item.Contains(CONSTANTS.CONST_STRING_CHECK_SELECT_CASE))
                {
                    result = result + item.Trim().Replace(CONSTANTS.CONST_STRING_CHECK_SELECT_CASE,
                        CONSTANTS.CONST_STRING_CHECK_SELECT_CASE + CONSTANTS.CONST_STRING_IS_SELECT_CASE) + CONSTANTS.CONST_CHAR_LINE_BREAK;
                    numSelectCase++;
                }
                else
                {
                    result = result + item.Trim() + CONSTANTS.CONST_CHAR_LINE_BREAK;
                }
            }
            return result;
        }

        private void handledSelectCaseString(string strSQL, string strCase)
        {
            Dictionary<string, string> listDicCase = new Dictionary<string, string>();
            listDicCase.Add(CONSTANTS.CONST_STRING_COLUMNS_SQL, strSQL); ;

            string[] arrCase = strCase.Split(CONSTANTS.CONST_CHAR_LINE_BREAK);
            string strSelectCaseName = string.Empty;
            string strCaseName = string.Empty;

            bool isCaseElse = false;

            foreach (string item in arrCase)
            {
                if (item.Contains(CONSTANTS.CONST_STRING_IS_SELECT_CASE))
                {
                    strSelectCaseName = item.Replace(CONSTANTS.CONST_STRING_IS_SELECT_CASE, CONSTANTS.CONST_STRING_CHECK_SELECT_CASE);
                }
                else if (Regex.IsMatch(item.Trim(), CONSTANTS.CONST_REGEX_CASE_ELSE_ERROR) || isCaseElse)
                {
                    if (!isCaseElse)
                    {
                        row = dataSQL.NewRow();
                        row[CONSTANTS.CONST_STRING_COLUMNS_ID] = strCaseName;
                        row[CONSTANTS.CONST_STRING_COLUMNS_SQL] = listDicCase[strCaseName];
                        dataSQL.Rows.Add(row);
                    }
                    isCaseElse = true;
                    continue;
                }
                else if (item.Contains(CONSTANTS.CONST_STRING_CHECK_CASE) || item.Contains(CONSTANTS.CONST_STRING_CHECK_END_SELECT))
                {
                    if (!string.IsNullOrEmpty(strCaseName))
                    {
                        row = dataSQL.NewRow();
                        row[CONSTANTS.CONST_STRING_COLUMNS_ID] = strCaseName;
                        row[CONSTANTS.CONST_STRING_COLUMNS_SQL] = listDicCase[strCaseName];
                        dataSQL.Rows.Add(row);
                    }
                    strCaseName = strSelectCaseName + CONSTANTS.CONST_STRING_SPACE + item.Trim();
                    listDicCase.Add(strCaseName, strSQL);
                }
                else
                {
                    listDicCase[strCaseName] = listDicCase[strCaseName] + item.Trim() + CONSTANTS.CONST_CHAR_LINE_BREAK;
                }
            }
        }

        private void lstDataSQL_SelectionChanged(object sender, EventArgs e)
        {
            if (lstDataSQL.Rows.Count <= 0) return;

            try
            {
                int selectedrowindex = lstDataSQL.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = lstDataSQL.Rows[0];
                strInputSQL = selectedRow.Cells[CONSTANTS.CONST_STRING_COLUMNS_SQL].Value.ToString();
                handleInputParam(strInputSQL);
            }
            catch (Exception)
            {
                DataGridViewRow selectedRow = lstDataSQL.Rows[0];
                strInputSQL = selectedRow.Cells[CONSTANTS.CONST_STRING_COLUMNS_SQL].Value.ToString();
                handleInputParam(strInputSQL);
            }
        }

        #endregion

        #region Input Param

        public void handleInputParam(string strSQL)
        {
            string[] arrInputSQL = strSQL.Split(CONSTANTS.CONST_CHAR_LINE_BREAK);

            foreach (string item in arrInputSQL)
            {
                if (item.Contains(CONSTANTS.CONST_STRING_CHECK_IF) || item.Contains(CONSTANTS.CONST_STRING_CHECK_ELSE))
                {
                    if (item.Contains(CONSTANTS.CONST_STRING_CHECK_OPEN_BRACKETS) || item.Contains(CONSTANTS.CONST_STRING_CHECK_CLOSE_BRACKETS))
                    {
                        string[] arrItem = item.Split(new string[] { CONSTANTS.CONST_STRING_CHECK_OPEN_BRACKETS,
                                                                 CONSTANTS.CONST_STRING_CHECK_CLOSE_BRACKETS }, StringSplitOptions.None);
                    }
                    else
                    {
                        string strItem = item.Replace(CONSTANTS.CONST_STRING_CHECK_IF, string.Empty).
                                              Replace(CONSTANTS.CONST_STRING_CHECK_ELSE, string.Empty).Trim();

                        string[] arrItem = strItem.Split(new string[] { CONSTANTS.CONST_STRING_AND, CONSTANTS.CONST_STRING_OR }, StringSplitOptions.None);
                        foreach (string itemParam in arrItem)
                        {
                            row = dataParam.NewRow();
                            row[CONSTANTS.CONST_STRING_COLUMNS_PARAM] = itemParam.Trim().Substring(0, itemParam.IndexOf(CONSTANTS.CONST_CHAR_SPACE));
                            row[CONSTANTS.CONST_STRING_COLUMNS_VALUE] = string.Empty;
                            dataParam.Rows.Add(row);
                        }
                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(item)) continue;

                    int indexRow = 1;
                    string[] arrItem = item.Split(new string[] { CONSTANTS.CONST_STRING_CHECK_PARAM_OPEN,
                                                                 CONSTANTS.CONST_STRING_CHECK_PARAM_CLOSE }, StringSplitOptions.None);

                    while (indexRow < arrItem.Length)
                    {
                        if (!string.IsNullOrEmpty(arrItem[indexRow]))
                        {
                            row = dataParam.NewRow();
                            row[CONSTANTS.CONST_STRING_COLUMNS_PARAM] = arrItem[indexRow].Replace(CONSTANTS.CONST_STRING_CHECK_PARAM_CLOSE, string.Empty).Trim();
                            row[CONSTANTS.CONST_STRING_COLUMNS_VALUE] = string.Empty;
                            dataParam.Rows.Add(row);
                        }
                        indexRow = indexRow + 2;
                    };
                }
            }

            lstInputParam.DataSource = dataParam;
        }


        #endregion
    }
}