using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class UtilWeb
    {
        public static string[] GetUrlInfo(this string str)
        {
            List<string> resStrs = new List<string>();
            string resStr = str.Trim();
            if (string.IsNullOrEmpty(resStr))
            {

                return resStrs.ToArray();
            }
            else
            {
 
            }
            var uri = new Uri(resStr);
            var baseUri = uri.GetLeftPart(System.UriPartial.Authority);
            resStrs.Add(baseUri);
            resStrs.Add(uri.AbsolutePath);
            return resStrs.ToArray();
        }
    }
}
