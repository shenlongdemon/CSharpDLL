using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public static class UtilString
    {
        public static string[] Split(this string str, string split)
        {
            string[] tokens = str.Split(new[] { split }, StringSplitOptions.None);
            return tokens;
        }
        public static string ToUpperCase(this string str, int index)
        {
            string resStr = string.Empty;
            if (string.IsNullOrEmpty(str))
            {
                resStr = string.Empty;
            }
            resStr = char.ToUpper(str[0]) + str.Substring(1);
            return resStr;
        }
        public static string RemoveHtmlTag(this string htmlString)
        {
            string resStr = Regex.Replace(htmlString, "<.*?>", String.Empty);
            string result = Regex.Replace(htmlString, @"<[^>]*>", String.Empty);
            string re = Regex.Replace(htmlString, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", String.Empty);


            return resStr;
        }
        //public static string ToSeoUrl(this string url) { 
        //    // make the url lowercase 
        //    string encodedUrl = (url ?? "").ToLower(); 
        //    // replace & with and 
        //    encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and"); 
        //    // remove characters 
        //    encodedUrl = encodedUrl.Replace("'", ""); 
        //    // remove invalid characters 
        //    encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-"); 
        //    // remove duplicates 
        //    encodedUrl = Regex.Replace(encodedUrl, @"-+", "-"); 
        //    // trim leading & trailing characters 
        //    encodedUrl = encodedUrl.Trim('-'); 
        //    return encodedUrl; 
        //}
        public static string ToSeoUrl(this string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            text = text.Replace(" ", "-");
            text = Regex.Replace(text, @"\&+", "and");
            text = text.Replace("'", ""); 
            text = Regex.Replace(text, @"-+", "-");
            text = text.Trim('-'); 
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
