using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace MIGS.Extensions
{
    public static class ListExtensions
    {
        public static string ToUrlQueryString(this IDictionary<string, string> value, bool enableUrlEncoding = false, bool excludeSecureHash = true)
        {
            if (value == null) return "";
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in value)
            {
                if (excludeSecureHash && (kvp.Key.Equals("vpc_SecureHash") || kvp.Key.Equals("vpc_SecureHashType")))
                {
                    continue;
                }

                if (!String.IsNullOrEmpty(kvp.Value))
                {
                    if (enableUrlEncoding)
                        data.Append(kvp.Key).Append("=").Append(HttpUtility.UrlEncode(kvp.Value)).Append("&");
                    else
                        data.Append(kvp.Key).Append("=").Append(kvp.Value).Append("&");
                }
            }
            // Delete trailing '&' from string.
            if (data.Length > 0)
            {
                data.Remove(data.Length - 1, 1);
            }
            return data.ToString();
        }

        public static string ToUrlQueryString(this NameValueCollection value, bool enableUrlEncoding = false, bool excludeSecureHash = true)
        {
            return value.ToDictionary().ToUrlQueryString(enableUrlEncoding, excludeSecureHash);
        }

        public static IDictionary<string, string> ToDictionary(this NameValueCollection value)
        {
            return value
                .AllKeys
                .Select(k => new KeyValuePair<string, string>(k, value[k]))
                .ToDictionary(t => t.Key, t => t.Value);
        }

        public static IDictionary<string, string> ToSortedDictionary(this NameValueCollection value, IComparer<string> comparer)
        {
            return new SortedDictionary<string, string>(value.ToDictionary(), comparer);
        }
    }
}
