using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.Types.Reflection
{
    public class ClassReflection
    {
        public static object? CreateClass(string name, object?[]? ctorParameters, Type[] ctorParamTypes)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                if(type.Name == name)
                {
                    return FindClass(type, ctorParameters, ctorParamTypes);
                }
            }

            return null;
        }

        public static object? InvokeMethod(Type type,string methodName, object?[]? parameters,BindingFlags flags, object? obj = default)
        {
            return type.GetMethod(methodName, flags)?.Invoke(obj, parameters);
        }

        private static object? FindClass(Type targetType, object?[]? ctorParameters, Type[] ctorParamTypes)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.Equals(targetType))
                {
                    return type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, ctorParamTypes)?.Invoke(ctorParameters);
                }
            }

            return null;
        }
    }
}
