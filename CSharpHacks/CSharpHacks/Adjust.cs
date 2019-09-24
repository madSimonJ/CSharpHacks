using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpHacks
{
    public static class AdjustExtensions
    {
        public class AdjustSelector<T>
        {
            internal AdjustSelector() { }

            public Func<T, int, bool> ByPosition(int position) =>
                (_, pos) => position == pos;

            public Func<T, int, bool> ByProp(Func<T, bool> predicate) =>
                (obj, _) => predicate(obj);
        }

        public static IEnumerable<T> Adjust<T>(this IEnumerable<T> @this, Func<T, int, bool> shouldReplace, T replacement) =>
            @this.Select((obj, pos) =>
                shouldReplace(obj, pos)
                   ? replacement
                   : obj);

        public static IEnumerable<T> Adjust<T>(this IEnumerable<T> @this, Func<AdjustSelector<T>, Func<T, int, bool>> selector, T replacement) =>
            @this.Adjust(selector(new AdjustSelector<T>()), replacement);
    }
}
