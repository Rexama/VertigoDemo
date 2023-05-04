using System;

namespace Tools
{
    public static class ExtensionMethods
    {
        public static T GetRandomElement<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty");
            }
            
            Random rnd = new Random();
            int index = rnd.Next(0, array.Length);
            return array[index];
        }
    }
}