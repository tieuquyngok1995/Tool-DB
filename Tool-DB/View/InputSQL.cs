using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tool_DB.Utils;

namespace Tool_DB.View
{
    public partial class InputSQL : Form
    {
        public DataTable data = new DataTable();

        private string strSQLChar = string.Empty;
        private int numSelectCase = 0;

        public InputSQL()
        {
            InitializeComponent();
        }

        private void InputSQL_Load(object sender, EventArgs e)
        {
            data.Columns.Add(CONSTANTS.CONST_STRING_COLUMNS_ID);
            data.Columns.Add(CONSTANTS.CONST_STRING_COLUMNS_SQL);
            txtSQLChar.Text = ConfigurationManager.AppSettings[CONSTANTS.CONST_STRING_SQL_CHAR];
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            strSQLChar = txtSQLChar.Text.Trim();

            if (!string.IsNullOrEmpty(txtInputSQL.Text))
            {
                handleStringInput();
            }
            else
            {
                data.Clear();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInputSQL.Text = string.Empty;
            txtSQLChar.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string handFormatStringInput(string strInputSQL)
        {
            string[] arrInputSQL = strInputSQL.Split(CONSTANTS.CONST_CHAR_LINE_BREAK);

            string regex = "[\u3040-\u30ff\u3400-\u4dbf\u4e00-\u9fff\uf900-\ufaff\uff66-\uff9f]";
            string result = string.Empty;
            string item = string.Empty;

            arrInputSQL = arrInputSQL.Where(
                (val, idx) => !(val.Contains(CONSTANTS.CONST_STRING_CHECK_APOSTROPHE) && (Regex.IsMatch(val, regex)
                             || val.Contains(CONSTANTS.CONST_STRING_CHECK_ADD_END) || val.Contains(CONSTANTS.CONST_STRING_CHECK_HYPHEN)))
                           && !string.Empty.Equals(val)).ToArray();

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

        private DataTable handleStringInput()
        {
            string resultFormat = handFormatStringInput(txtInputSQL.Text);
            if (numSelectCase == 0)
            {
                DataRow row = data.NewRow();
                row[CONSTANTS.CONST_STRING_COLUMNS_ID] = 1;
                row[CONSTANTS.CONST_STRING_COLUMNS_SQL] = handFormatStringInput(txtInputSQL.Text);
                data.Rows.Add(row);
            }
            else
            {
                string[] arrInputSQL = resultFormat.Split(new string[] { CONSTANTS.CONST_STRING_CHECK_SELECT_CASE }, StringSplitOptions.None);
                handledSelectCaseString(arrInputSQL[0], arrInputSQL[1]);
            }

            numSelectCase = 0;
            return data;
        }

        private DataTable handledSelectCaseString(string strSQL, string strCase)
        {
            DataRow row;
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
                        row = data.NewRow();
                        row[CONSTANTS.CONST_STRING_COLUMNS_ID] = strCaseName;
                        row[CONSTANTS.CONST_STRING_COLUMNS_SQL] = listDicCase[strCaseName];
                        data.Rows.Add(row);
                    }
                    isCaseElse = true;
                    continue;
                }
                else if (item.Contains(CONSTANTS.CONST_STRING_CHECK_CASE))
                {
                    if (!string.IsNullOrEmpty(strCaseName))
                    {
                        row = data.NewRow();
                        row[CONSTANTS.CONST_STRING_COLUMNS_ID] = strCaseName;
                        row[CONSTANTS.CONST_STRING_COLUMNS_SQL] = listDicCase[strCaseName];
                        data.Rows.Add(row);
                    }
                    strCaseName = strSelectCaseName + CONSTANTS.CONST_STRING_SPACE + item.Trim();
                    listDicCase.Add(strCaseName, strSQL);
                }
                else
                {
                    listDicCase[strCaseName] = listDicCase[strCaseName] + item.Trim() + CONSTANTS.CONST_CHAR_LINE_BREAK;
                }
            }

            return data;
        }
    }
}
