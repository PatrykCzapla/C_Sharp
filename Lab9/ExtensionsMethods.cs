using System;
using System.Collections.Generic;

namespace lab09_a
{
    public static class ExtensionsMethods
    {
        //public delegate void Function<T>(T a);
        public static void MyEach<T>(this IEnumerable<T> IEnum, Action<T> fun)
        {
            foreach (var elem in IEnum)
            {
                fun(elem);
            }
        }
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> IEnum, Func<T, bool> fun)
        {
            foreach (var elem in IEnum)
            {
                if (fun(elem)) yield return elem;
            }

        }
        public static T[] ToTransformedArray<T>(this IEnumerable<T> IEnum, Func<T,T> fun)
        {
            if (IEnum == null) return null;
            int i = 0;
            foreach (var elem in IEnum)
            {
                i++;
            }
            T[] tab = new T[i];
            i = 0;
            foreach(var elem in IEnum)
            {
                tab[i] = fun(elem);
                i++;
            }
            return tab;
        }

    }
}
