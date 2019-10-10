using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpHacks
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Omit<T>(this IEnumerable<T> x, int n)
        {
            return x.Reverse().Skip(n).Reverse();
        }

        public static IEnumerable<T> Last<T>(this IEnumerable<T> x, int n)
        {
            return x.Reverse().Take(n).Reverse();
        }

        public static IDictionary<T, int> Occurrence<T>(this IEnumerable<T> x)
        {
            var frequency = new Dictionary<T, int>();
            foreach(var  t in x)
            {
                if (frequency.ContainsKey(t))
                {
                    frequency[t]++;
                }
                else
                {
                    frequency[t] = 1;
                }
            }
            return frequency;
        }

        
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            source.ArgumentNotNull(nameof(source));
            keySelector.ArgumentNotNull(nameof(keySelector));

            var seenKeys = new HashSet<TKey>();

            return source.Where(element => seenKeys.Add(keySelector(element)));
        }

        public static IEnumerable<TSource> EmptyIfNull<TSource>(this IEnumerable<TSource> source)
        {
            return source ?? Enumerable.Empty<TSource>();
        }

        public static IEnumerable<TSource> SelectByMin<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            source.ArgumentNotNull(nameof(source));
            selector.ArgumentNotNull(nameof(selector));

            return source.GroupBy(selector).OrderBy(g => g.Key).FirstOrDefault() ?? source;
        }

        public static IEnumerable<TSource> SelectByMax<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            source.ArgumentNotNull(nameof(source));
            selector.ArgumentNotNull(nameof(selector));

            return source.GroupBy(selector).OrderByDescending(g => g.Key).FirstOrDefault() ?? source;
        }

        public static IEnumerable<TSource> TakePerKey<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, int count)
        {
            source.ArgumentNotNull(nameof(source));
            keySelector.ArgumentNotNull(nameof(keySelector));
            var comparer = EqualityComparer<TKey>.Default;

            var lastKey = default(TKey);
            var returnedPerKey = 0;
            foreach (var o in source)
            {
                var key = keySelector(o);

                if (!comparer.Equals(key, lastKey))
                {
                    lastKey = key;
                    returnedPerKey = 0;
                }

                if (returnedPerKey < count)
                {
                    returnedPerKey++;
                    yield return o;
                }
            }
        }

        private static T ArgumentNotNull<T>(this T argumentValue, string argumentName = null)
            where T : class
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName, $"The provided argument {argumentName} must not be Null.");
            }

            return argumentValue;
        }
        
        
    }
}
