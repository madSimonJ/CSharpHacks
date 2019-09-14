using System;
using System.Collections.Generic;

namespace CSharpHacks
{
    public static class DictionaryHacks
    {
        public static Func<TKey, TOutput> ToLookupWithDefault<TKey, TOutput>(this IDictionary<TKey, TOutput> @this, TOutput defaultValue) =>
            x => @this.ContainsKey(x)
                ? @this[x]
                : defaultValue;
    }
}
