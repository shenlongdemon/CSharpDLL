using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class UtilClass
    {
        public static object CreateInstance(this object obj, string fullyQualifiedName)
        {
            Type type = Type.GetType(fullyQualifiedName);
            if (type != null)
                return Activator.CreateInstance(type);
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(fullyQualifiedName);
                if (type != null)
                    return Activator.CreateInstance(type);
            }
            return null;
        }
        public static async Task<object> InvokeAsync(this object obj, string method, object[] objs)
        {
            Type type = obj.GetType();
            object res = await (Task<object>)type.GetMethod(method).Invoke(obj, objs);
            return res;
        }
    }
}
