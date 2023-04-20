using System;
using System.Linq;
using System.Runtime.Serialization;

namespace _Code.Tools
{
    internal static class ExtensionMethods
    {
        public static string GetEnumMemberValue(this Enum value)
        {
            var enumMemberAttribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;
            return enumMemberAttribute?.Value ?? value.ToString();
        }


        public static T GetRandomEnum<T>() where T : Enum
        {
            T[] values = (T[]) Enum.GetValues(typeof(T));
            int randomIndex = new Random().Next(values.Length);
            return values[randomIndex];
        }
    }
}