using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class UtilHtml
    {
        
        public static string AHref(string id, string innerHtml, string classes, string href = "#")
        {
            string ahref = "<a ";
            ahref += string.IsNullOrEmpty(id) ? "" : "id=\"" + id + "\" ";
            ahref += string.IsNullOrEmpty(classes) ? "" : "class=\"" + classes + "\" ";
            ahref += string.IsNullOrEmpty(href) ? "#" : "href=\"" + href + "\" ";
            ahref += " >" + innerHtml + "</a>";
            return ahref;
        }


        public static string Option(string id, string innerHtml)
        {
            string op = "<option id=\"" + id + "\">" + innerHtml + "</option>";
            return op;
        }
    }
}
