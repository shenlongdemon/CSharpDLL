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
            var t = obj.GetType().Assembly.GetTypes();
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
        public static async Task<dynamic> InvokeAsync(this object obj, string methodName, object[] objs)           
        {
            Type type = obj.GetType();            
            MethodInfo method = type.GetMethodByName(methodName);
            dynamic res = await (Task<dynamic>)method.Invoke(obj, objs);            
            return res;
        }
        public static MethodInfo GetMethodByName(this Type type, string methodname)
        {
            MethodInfo method = type.GetMethod(methodname);
            if (method == null)
            {
                method = type.GetRuntimeMethods().FirstOrDefault(p=> p.Name.ToLower().Equals(methodname.ToLower()));
            }
            return method;
        }
    }
}
