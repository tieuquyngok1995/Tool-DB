using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tool_DB.Utils
{
    class CUtils
    {
        #region Format String
        public static string ReplaceStringFormat(string str, string oldValue, string newValue, string formatValue = "")
        {
            try
            {
                if (string.Empty.Equals(formatValue))
                {
                    return str.Replace(oldValue, newValue);
                }
                else
                {
                    return str.Replace(string.Format(oldValue, formatValue), string.Format(newValue, formatValue));
                }
            }
            catch (Exception)
            {
                return str;
            }
        }

        public static bool ConvertStringToBoolean(string text)
        {
            bool result = false;
            string conditional = string.Empty;
            Dictionary<string, string> lstDic = ConvertStringConditionalToLsit(text);

            foreach (KeyValuePair<string, string> item in lstDic)
            {
                if (string.Empty.Equals(item.Key))
                {
                    result = bool.Parse(item.Value);
                }
                else
                {
                    conditional = Regex.Replace(item.Key, CONSTANTS.CONST_REGEX_KEY_LIST_DIC, string.Empty).Trim();
                    result = CompareConditional(result, conditional, bool.Parse(item.Value));
                }
            }

            return result;
        }

        private static Dictionary<string, string> ConvertStringConditionalToLsit(string text)
        {
            text = text.Replace(CONSTANTS.CONST_STRING_CHECK_IF, string.Empty).Replace(CONSTANTS.CONST_STRING_CHECK_THEN, string.Empty).Trim();
            string key = string.Empty;
            string resultCompare = string.Empty;

            bool isBrace = false;

            Dictionary<string, string> lstDic = new Dictionary<string, string>();
            lstDic.Add(key, string.Empty);

            string[] arrText = text.Split(CONSTANTS.CONST_CHAR_SPACE);
            int index = 0;

            foreach (string item in arrText)
            {
                index++;

                if (item.Contains("("))
                {
                    isBrace = true;
                }

                if (item.ToUpper().Equals(CONSTANTS.CONST_STRING_AND))
                {
                    if (isBrace)
                    {
                        resultCompare = resultCompare + CompareString(lstDic[key]) + CONSTANTS.CONST_CHAR_SPACE
                            + CONSTANTS.CONST_STRING_AND + CONSTANTS.CONST_CHAR_SPACE;
                        lstDic[key] = string.Empty;
                    }
                    else
                    {
                        lstDic[key] = CompareString(lstDic[key]);
                        key = string.Format(CONSTANTS.CONST_STRING_KEY_LIST_DIC, lstDic.Count) + CONSTANTS.CONST_STRING_AND;
                        lstDic.Add(key, string.Empty);
                    }
                }
                else if (item.ToUpper().Equals(CONSTANTS.CONST_STRING_OR))
                {
                    if (isBrace)
                    {
                        resultCompare = resultCompare + CompareString(lstDic[key]) + CONSTANTS.CONST_CHAR_SPACE
                            + CONSTANTS.CONST_STRING_AND + CONSTANTS.CONST_CHAR_SPACE;
                        lstDic[key] = string.Empty;
                    }
                    else
                    {
                        lstDic[key] = CompareString(lstDic[key]);
                        key = string.Format(CONSTANTS.CONST_STRING_KEY_LIST_DIC, lstDic.Count) + CONSTANTS.CONST_STRING_OR;
                        lstDic.Add(key, string.Empty);
                    }
                }
                else
                {
                    if (isBrace)
                    {
                        if (item.Contains(")"))
                        {
                            lstDic[key] = lstDic[key] + item.Replace(")", string.Empty) + CONSTANTS.CONST_CHAR_SPACE;
                        }
                        else
                        {
                            lstDic[key] = lstDic[key] + item.Replace("(", string.Empty) + CONSTANTS.CONST_CHAR_SPACE;
                        }
                    }
                    else
                    {
                        lstDic[key] = lstDic[key] + item + CONSTANTS.CONST_CHAR_SPACE;
                    }

                    if (index == arrText.Length)
                    {
                        lstDic[key] = CompareString(lstDic[key]);
                    }
                }

                if (item.Contains(")"))
                {
                    resultCompare = resultCompare + CompareString(lstDic[key]);

                    string[] arrResult = resultCompare.Split(CONSTANTS.CONST_CHAR_SPACE);

                    if (arrResult.Length == 3)
                    {
                        lstDic[key] = CompareConditional(bool.Parse(arrResult[0]), arrResult[1], bool.Parse(arrResult[2])).ToString();
                        isBrace = false;
                    }
                    else if (arrText.Length > 3)
                    {
                        bool result = bool.Parse(arrResult[0]);
                        for (int i = 1; i < arrResult.Length; i = i + 2)
                        {
                            result = CompareConditional(result, arrResult[i], bool.Parse(arrResult[i + 1]));
                        }
                        lstDic[key] = result.ToString();
                        isBrace = false;
                    }
                }
            }
            return lstDic;
        }

        private static bool CompareConditional(bool left, string operators, bool right)
        {
            switch (operators)
            {
                case "AND": case "&&": return left && right;
                case "OR": case "||": return left || right;
                default: throw new ArgumentException("Invalid comparison operator: {0}", operators);
            }
        }

        private static string CompareString(string text)
        {
            text = text.Trim();
            string[] arrText = text.Split(CONSTANTS.CONST_CHAR_SPACE);

            if (arrText.Length == 1 && (CONSTANTS.CONST_STRING_FALSE.Equals(arrText[0]) || CONSTANTS.CONST_STRING_TRUE.Equals(arrText[0])))
            {
                return text;
            }
            else if (arrText.Length == 3)
            {
                if (CONSTANTS.CONST_STRING_EMPTY.Equals(arrText[0]) || CONSTANTS.CONST_STRING_CHECK_EMPTY.Equals(arrText[0]))
                {
                    arrText[0] = string.Empty;
                }

                if (CONSTANTS.CONST_STRING_EMPTY.Equals(arrText[2]) || CONSTANTS.CONST_STRING_CHECK_EMPTY.Equals(arrText[2]))
                {
                    arrText[2] = string.Empty;
                }

                return CompareOperators(arrText[0], arrText[1], arrText[2]).ToString();
            }
            return string.Empty;
        }

        private static bool CompareOperators<ICompare>(ICompare left, string operators, ICompare right) where ICompare : IComparable
        {

            switch (operators)
            {
                case "==":
                case "=": return left.CompareTo(right) == 0;
                case "!=":
                case "<>": return left.CompareTo(right) != 0;
                case ">": return left.CompareTo(right) > 0;
                case ">=": return left.CompareTo(right) >= 0;
                case "<": return left.CompareTo(right) < 0;
                case "<=": return left.CompareTo(right) <= 0;
                default: throw new ArgumentException("Invalid comparison operator: {0}", operators);
            }
        }
        #endregion
    }
}
