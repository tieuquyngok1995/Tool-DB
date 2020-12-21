namespace Tool_DB.Utils
{
    class CONSTANTS
    {
        #region Char
        public const char CONST_CHAR_LINE_BREAK = '\n';
        public const char CONST_CHAR_SPACE = ' ';
        public const char CONST_CHAR_QUOTATION = '"';
        public const char CONST_CHAR_O_BRACKETS = '(';
        public const char CONST_CHAR_C_BRACKETS = ')';

        #endregion

        #region String
        public const string CONST_STRING_STATUS = "Status: {0}";
        public const string CONST_STRING_STATUS_CONNECTION = "Connect";
        public const string CONST_STRING_STATUS_DISCONNECT = "Disconnect";

        public const string CONST_STRING_SPACE = " ";
        public const string CONST_STRING_TAB = "\t";
        public const string CONST_STRING_COLUMNS_ID = "ID";
        public const string CONST_STRING_COLUMNS_SQL = "SQL";
        public const string CONST_STRING_COLUMNS_PARAM = "PARAM";
        public const string CONST_STRING_COLUMNS_VALUE = "VALUE";

        public const string CONST_STRING_IS_SELECT_CASE = " IsSelectCase: ";
        public const string CONST_STRING_AND = "AND";
        public const string CONST_STRING_OR = "OR";
        public const string CONST_STRING_LOWER_AND = "And";
        public const string CONST_STRING_LOWER_OR = "Or";
        public const string CONST_STRING_KEY_LIST_DIC = "Key_{0}: ";
        public const string CONST_STRING_FALSE = "False";
        public const string CONST_STRING_TRUE = "True";
        public const string CONST_STRING_WHERE = "WHERE";
        public const string CONST_STRING_EQUAL = "=";
        public const string CONST_STRING_IS = "IS";
        public const string CONST_STRING_NULL = "NULL";
        public const string CONST_STRING_LIKE = "LIKE";

        public const string CONST_STRING_EMPTY = "String.Empty";
        #endregion

        #region String Config
        public const string CONST_STRING_SERVER_NAME = "ServerName";
        public const string CONST_STRING_DATABASE_NAME = "DatabaseName";
        public const string CONST_STRING_USER_NAME = "UserName";
        public const string CONST_STRING_PASSWORD = "Password";
        public const string CONST_STRING_SQL_CHAR = "SQLChar";
        public const string CONST_STRING_PARAM_CHAR = "ParamChar";
        #endregion

        #region String Check
        public const string CONST_STRING_CHECK_APOSTROPHE = " '";
        public const string CONST_STRING_CHECK_ADD_END = "ADD END";
        public const string CONST_STRING_CHECK_HYPHEN = "---";
        public const string CONST_STRING_CHECK_HASH = "#";
        public const string CONST_STRING_CHECK_REP_START = "REP-START";
        public const string CONST_STRING_CHECK_REP_END = "REP-END";
        public const string CONST_STRING_CHECK_APOSTROPHE_VALUE = "'' {0}";

        public const string CONST_STRING_CHECK_EMPTY = "\"\"";
        public const string CONST_STRING_CHECK_IF = "If";
        public const string CONST_STRING_CHECK_THEN = "Then";
        public const string CONST_STRING_CHECK_ELSE = "Else";
        public const string CONST_STRING_CHECK_END = "End";
        public const string CONST_STRING_CHECK_END_IF = "End If";
        public const string CONST_STRING_CHECK_SELECT_CASE = "Select Case";
        public const string CONST_STRING_CHECK_END_SELECT = "End Select";
        public const string CONST_STRING_CHECK_CASE = "Case";
        public const string CONST_STRING_CHECK_AND = "&";
        public const string CONST_STRING_CHECK_OPEN_BRACKETS = " (";
        public const string CONST_STRING_CHECK_CLOSE_BRACKETS = ") ";
        public const string CONST_STRING_CHECK_DIFFERENCE = "<>";
        public const string CONST_STRING_CHECK_SUBSTRING = ".Substring";
        public const string CONST_STRING_CHECK_AS = "AS";
        public const string CONST_STRING_CHECK_PARAM_OPEN = "\" & ";
        public const string CONST_STRING_CHECK_PARAM_CLOSE = "& \"";

        public const string CONST_STRING_CHECK_CONTAINS_01 = "{0} = \"";
        public const string CONST_STRING_CHECK_CONTAINS_02 = "{0} = {0} & \"";
        #endregion

        #region String Format
        public const string CONST_STRING_FORMAT_01 = "{0}=";
        public const string CONST_STRING_FORMAT_02 = "=\"";
        public const string CONST_STRING_FORMAT_03 = "'\"&";
        public const string CONST_STRING_FORMAT_04 = "&[a-zA-Z0-9\"]";
        public const string CONST_STRING_FORMAT_05 = @"\s+";
        public const string CONST_STRING_FORMAT_06 = "&";
        public const string CONST_STRING_FORMAT_07 = "'\n";
        public const string CONST_STRING_FORMAT_08 = ".";
        public const string CONST_STRING_FORMAT_09 = "='";
        public const string CONST_STRING_FORMAT_10 = "= '";
        public const string CONST_STRING_FORMAT_11 = "\'\" & ";
        public const string CONST_STRING_FORMAT_12 = " & \"\'";

        public const string CONST_STRING_REPLACE_01 = "{0} =";
        public const string CONST_STRING_REPLACE_02 = "= \"";
        public const string CONST_STRING_REPLACE_03 = "'\" & ";
        public const string CONST_STRING_REPLACE_04 = " & \"";
        public const string CONST_STRING_REPLACE_05 = " ";
        public const string CONST_STRING_REPLACE_06 = "\'";
        public const string CONST_STRING_REPLACE_07 = "\'";
        #endregion

        #region String Regex
        public const string CONST_REGEX_WORD_CHARACTER = "'[a-zA-Z0-9]";
        public const string CONST_REGEX_CASE_ELSE_ERROR = @"Case Else[a-zA-Z0-9\s_=]+ERROR";
        public const string CONST_REGEX_KEY_LIST_DIC = "Key_[0-9]+:\\s";
        #endregion
    }
}
