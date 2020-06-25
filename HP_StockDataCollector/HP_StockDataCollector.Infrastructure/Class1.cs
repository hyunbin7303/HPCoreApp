using HP_Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace HP_StockDataCollector.Infrastructure
{
    public static class ReflectionExtensions
    {
        // what is this?.... How can i use? 
        public static string GetAsyncVoidMethodsList(this Assembly assembly)
        {
            return string.Join("\r\n",
                GetLoadableTypes(assembly)
                    .SelectMany(type => type.GetMethods())
                    .Where(HasAttribute<AsyncStateMachineAttribute>)
                    .Where(method => method.ReturnType == typeof(void))
                    .Select(method =>
                        string.Format("Method '{0}' of '{1}' has an async void return type and that's bad",
                            method.Name,
                            method.DeclaringType.Name))
                    .ToList());
        }
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
        public static bool HasAttribute<TAttribute>(this MethodInfo method) where TAttribute : Attribute
        {
            return method.GetCustomAttributes(typeof(TAttribute), false).Any();
        }

        //public static string InstallDirectory => Path.GetDirectoryName(AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x=> )) 

    
    }
}
