using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace CSharpHacks
{
    public static class IListHacks
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return  list == null || list.Count == 0;
        }

        public static bool IsNotNullOrEmpty<T>(this IList<T> list)
        {
            return list != null && list.Count > 0;
        }

        public static bool IsNotNull<T>(this IList<T> list) => (list != null);
    }
}
