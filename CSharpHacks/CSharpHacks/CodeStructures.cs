using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpHacks
{
    public static class CodeStructures
    {
        public static TOutput Map<TInput, TOutput>(this TInput @this, Func<TInput, TOutput> converter) =>
            converter(@this);

        public static bool Validate<T>(this T @this, params Func<T, bool>[] rules) =>
            rules.All(x => x(@this));

        public static TOutput Alt<TInput, TOutput>(this TInput @this, params Func<TInput, TOutput>[] alts)
        {
            foreach(var a in alts)
            {
                try
                {
                    var result = a(@this);
                    if (!EqualityComparer<TOutput>.Default.Equals(result, default(TOutput)))
                    {
                        return result;
                    }
                }
                catch (Exception)
                {

                }
            }
            return default(TOutput);
        }


    } 
}
