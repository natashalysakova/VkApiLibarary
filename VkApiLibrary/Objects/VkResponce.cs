using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace VkApiLibrary.Objects
{
    public static class VkResponse
    {

        internal static XmlDocument ExecuteCommand(string name, NameValueCollection qs)
        {
            XmlDocument result = new XmlDocument();

            result.Load(String.Format("https://api.vkontakte.ru/method/{0}.xml?access_token={1}&{2}", name, VkontakteApi._token, String.Join("&", from item in qs.AllKeys select item + "=" + qs[item])));
            return result;
        }

        internal static string GetDataFromXmlNode(XmlNode input)
        {
            if (input == null || String.IsNullOrEmpty(input.InnerText))
            {
                return String.Empty;
            }
            else
            {
                return input.InnerText;
            }
        }

        static Dictionary<string, string> ParseJson(string res)
        {
            var lines = res.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var ht = new Dictionary<string, string>(20);
            var st = new Stack<string>(20);

            for (int i = 0; i < lines.Length; ++i)
            {
                var line = lines[i];
                var pair = line.Split(":".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);

                if (pair.Length == 2)
                {
                    var key = ClearString(pair[0]);
                    var val = ClearString(pair[1]);

                    if (val == "{")
                    {
                        st.Push(key);
                    }
                    else
                    {
                        if (st.Count > 0)
                        {
                            key = string.Join("_", st) + "_" + key;
                        }

                        if (ht.ContainsKey(key))
                        {
                            ht[key] += "&" + val;
                        }
                        else
                        {
                            ht.Add(key, val);
                        }
                    }
                }
                else if (line.IndexOf('}') != -1 && st.Count > 0)
                {
                    st.Pop();
                }
            }

            return ht;
        }

        static string ClearString(string str)
        {
            str = str.Trim();

            var ind0 = str.IndexOf("\"");
            var ind1 = str.LastIndexOf("\"");

            if (ind0 != -1 && ind1 != -1)
            {
                str = str.Substring(ind0 + 1, ind1 - ind0 - 1);
            }
            else if (str[str.Length - 1] == ',')
            {
                str = str.Substring(0, str.Length - 1);
            }

            str = HttpUtility.UrlDecode(str);

            return str;
        }
    }
}