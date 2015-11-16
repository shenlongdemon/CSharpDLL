using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class UtilException
    {
        public static string GetHierarchyString(this Exception ex)
        {
            Exception e = ex;
            string exStr = e.Message;
            while (e.InnerException != null)
            {
                e = e.InnerException;
                exStr += "\r\n\t" + e.Message;
            }
            return exStr;

        }
    }
}
