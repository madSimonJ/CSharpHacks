using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpHacks
{
    public static class EnumerableExtensions
    {
        [ThreadStatic]
        internal static Random RandomNumberGenerator = new(); // Exposed to test suite.

        /// <summary>
        ///     Chooses a value, at random, from a list of values.
        /// </summary>
        /// <typeparam name="T">The type of values within the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>A value, of type <typeparamref name="T"/>, selected at random from the <paramref name="collection"/>.</returns>
        public static T Random<T>(this IEnumerable<T> collection)
        {
            var list  = collection.ToList();
            var index = RandomNumberGenerator.Next(0, list.Count);
            return list.ElementAt(index);
        }

        /// <summary>
        ///     Adds a range of entries into a sorted dictionary.
        ///     Includes a work around the fact that keys within Sorted Dictionaries cannot normally be overwritten.
        /// </summary>
        /// <param name="dict">The dictionary to add to, or update.</param>
        /// <param name="range">The range of entries to add, or update.</param>
        public static void AddOrUpdateRange<TKey, TValue>(this SortedDictionary<TKey, TValue> dict, IDictionary<TKey, TValue> range)
        {
            foreach (var record in range) dict.AddOrUpdate(record);
        }

        /// <summary>
        ///     Adds a range of entries into a sorted dictionary.
        ///     Includes a work around the fact that keys within Sorted Dictionaries cannot normally be overwritten.
        /// </summary>
        /// <param name="dict">The dictionary to add to, or update.</param>
        /// <param name="range">The range of entries to add, or update.</param>
        public static void AddOrUpdateRange<TKey, TValue>(this SortedDictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> range)
        {
            foreach (var record in range) dict.AddOrUpdate(record);
        }

        /// <summary>
        ///     Adds an entry into a sorted dictionary.
        ///     Includes a work around the fact that keys within Sorted Dictionaries cannot normally be overwritten.
        /// </summary>
        /// <param name="dict">The dictionary to save the syntax list to.</param>
        /// <param name="record">The key-value pair to add.</param>
        public static void AddOrUpdate<TKey, TValue>(this SortedDictionary<TKey, TValue> dict, KeyValuePair<TKey, TValue> record)
        {
            dict.AddOrUpdate(record.Key, record.Value);
        }

        /// <summary>
        ///     Adds an entry into a sorted dictionary.
        ///     Includes a work around the fact that keys within Sorted Dictionaries cannot normally be overwritten.
        /// </summary>
        /// <param name="dict">The dictionary to save the syntax list to.</param>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        public static void AddOrUpdate<TKey, TValue>(this SortedDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            try
            {
                dict.Add(key, value);
            }
            catch (ArgumentException)
            {
                dict.Remove(key);
                dict.Add(key, value);
            }
        }

        /// <summary>
        ///     Adds an item to the <see cref="IDictionary{TKey,TValue}" />, if it not already present in the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of the elements of <paramref name="key" />.</typeparam>
        /// <typeparam name="TValue">The type of the elements of <paramref name="value" />.</typeparam>
        /// <param name="collection">The collection to add the item to.</param>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add.</param>
        /// <returns><c>true</c> if the item was added to collection, <c>false</c> otherwise.</returns>
        public static bool AddIfNotPresent<TKey, TValue>(this IDictionary<TKey, TValue> collection, TKey key, TValue value)
        {
            var contains = collection.ContainsKey(key);
            if (!contains) collection.Add(key, value);
            return !contains;
        }

        /// <summary>
        ///     Adds an item to the <see cref="ICollection{TValue}" />, if it not already present in the collection.
        /// </summary>
        /// <typeparam name="TValue">The type of the elements of <paramref name="value" />.</typeparam>
        /// <param name="collection">The collection to add the item to.</param>
        /// <param name="value">The value to add.</param>
        /// <returns><c>true</c> if the item was added to collection, <c>false</c> otherwise.</returns>
        public static bool AddIfNotPresent<TValue>(this ICollection<TValue> collection, TValue value)
        {
            var contains = collection.Contains(value);
            if (!contains) collection.Add(value);
            return !contains;
        }

        /// <summary>
        ///     Adds an item to the <see cref="IDictionary{TKey,TValue}" />, if it not already present in the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of the the key within the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the value within the dictionary.</typeparam>
        /// <param name="collection">The collection to add the item to.</param>
        /// <param name="record">The record to add.</param>
        /// <returns><c>true</c> if the item was added to collection, <c>false</c> otherwise.</returns>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> collection, KeyValuePair<TKey, TValue> record)
        {
            collection.AddOrUpdate(record.Key, record.Value);
        }

        /// <summary>
        ///     Adds an item to the <see cref="IDictionary{TKey,TValue}" />, if it not already present in the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of the elements of <paramref name="key" />.</typeparam>
        /// <typeparam name="TValue">The type of the elements of <paramref name="value" />.</typeparam>
        /// <param name="collection">The collection to add the item to.</param>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add.</param>
        /// <returns><c>true</c> if the item was added to collection, <c>false</c> otherwise.</returns>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> collection, TKey key, TValue value)
        {
            if (!collection.ContainsKey(key))
            {
                collection.Add(key, value);
                return;
            }
            collection[key] = value;
        }

        /// <summary>
        ///     Adds an item to the <see cref="IDictionary{TKey,TValue}" />, if it not already present in the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of the the key within the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the value within the dictionary.</typeparam>
        /// <param name="collection">The collection to add the item to.</param>
        /// <param name="range">The range of items to add.</param>
        /// <returns><c>true</c> if the item was added to collection, <c>false</c> otherwise.</returns>
        public static void AddOrUpdateRange<TKey, TValue>(this IDictionary<TKey, TValue> collection, IDictionary<TKey, TValue> range)
        {
            foreach (var record in range) collection.AddOrUpdate(record.Key, record.Value);
        }

        /// <summary>
        ///     Adds an item to the <see cref="IDictionary{TKey,TValue}" />, if it not already present in the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of the the key within the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the value within the dictionary.</typeparam>
        /// <param name="collection">The collection to add the item to.</param>
        /// <param name="range">The range of items to add.</param>
        /// <returns><c>true</c> if the item was added to collection, <c>false</c> otherwise.</returns>
        public static void AddOrUpdateRange<TKey, TValue>(this IDictionary<TKey, TValue> collection, IEnumerable<KeyValuePair<TKey, TValue>> range)
        {
            foreach (var record in range) collection.AddOrUpdate(record.Key, record.Value);
        }

        /// <summary>
        ///     If the value should exist, and it doesn't, it will be removed from the collection.
        ///     If the value shouldn't exist, and it does, it will be removed from the collection.
        /// </summary>
        /// <typeparam name="TValue">The type of the elements of <paramref name="value" />.</typeparam>
        /// <param name="collection">The collection to add the item to.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="shouldExist">Whether or not the value should exist within the collection.</param>
        /// <returns><c>true</c> if the item was added to collection, <c>false</c> otherwise.</returns>
        public static void EnsureExistence<TValue>(this List<TValue> collection, TValue value, bool shouldExist) where TValue : IEquatable<TValue>
        {
            collection.RemoveAll(p => p.Equals(value));
            if (shouldExist) collection.Add(value);
        }

        /// <summary>
        ///     Removes an item to the <see cref="ICollection{TItem}" />, if it is already present in the collection.
        /// </summary>
        /// <returns><c>true</c> if the item was removed from the collection, <c>false</c> otherwise.</returns>
        public static bool RemoveIfPresent<TKey, TValue>(this IDictionary<TKey, TValue> collection, TKey key)
        {
            var contains = collection.ContainsKey(key);
            if (contains) collection.Remove(key);
            return contains;
        }

        /// <summary>
        ///     Removes an item to the <see cref="ICollection{TItem}" />, if it is already present in the collection.
        /// </summary>
        /// <typeparam name="TItem">The type of the elements of <paramref name="item" />.</typeparam>
        /// <param name="collection">The collection to remove the item from.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns><c>true</c> if the item was removed from the collection, <c>false</c> otherwise.</returns>
        public static bool RemoveIfPresent<TItem>(this ICollection<TItem> collection, TItem item)
        {
            var contains = collection.Contains(item);
            if (contains) collection.Remove(item);
            return contains;
        }

        /// <summary>
        ///     Determines whether the given collection contains any value within a given list of values.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="values">The list of values.</param>
        /// <returns>
        ///     <c>true</c> if the specified collection contains any of the range of values; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsAny<TValue>(this IEnumerable<TValue> source, IEnumerable<TValue> values)
        {
            return values.Any(source.Contains);
        }

        /// <summary>
        ///     Determines whether the given dictionary contains any key within a given list of keys.
        /// </summary>
        /// <typeparam name="TKey">The type of the key held in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values held in the dictionary.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="keys">The list of keys.</param>
        /// <returns>
        ///     <c>true</c> if the specified dictionary contains any of the range of keys; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsAnyKey<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<TKey> keys)
        {
            return source.Keys.ContainsAny(keys);
        }

        /// <summary>
        ///     Determines whether the given dictionary contains any values within a given list of values.
        /// </summary>
        /// <typeparam name="TKey">The type of the key held in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values held in the dictionary.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="values">The list of values.</param>
        /// <returns>
        ///     <c>true</c> if the specified dictionary contains any of the range of keys; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsAnyValue<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<TValue> values)
        {
            return source.Values.ContainsAny(values);
        }

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

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
        {
            source.ArgumentNotNull(nameof(source));

            if (batchSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(batchSize));
            }

            T[] batch = null;
            var elementIndex = 0;

            foreach (var item in source)
            {
                if (batch == null)
                {
                    batch = new T[batchSize];
                }

                batch[elementIndex++] = item;

                if (elementIndex == batchSize)
                {
                    yield return batch;

                    batch = null;
                    elementIndex = 0;
                }
            }

            if (batch != null && elementIndex > 0)
            {
                yield return batch.Take(elementIndex).ToArray();
            }            
        }

        private static T ArgumentNotNull<T>(this T argumentValue, string argumentName = null) where T : class
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName, $"The provided argument {argumentName} must not be Null.");
            }

            return argumentValue;
        }               
    }
}
