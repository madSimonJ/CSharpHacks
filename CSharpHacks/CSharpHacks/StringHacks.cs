using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpHacks
{
    public static class StringHacks
    {
        public static int ToInt(this string @this) =>
            int.TryParse(@this, out var result)
                ? result
                : 0;

        public static double ToDouble(this string @this) =>
            double.TryParse(@this, out var result)
                ? result
                : 0;

        public static decimal ToDecimal(this string @this) =>
            decimal.TryParse(@this, out var result)
                ? result
                : 0;

        public static float ToFloat(this string @this) =>
            float.TryParse(@this, out var result)
                ? result
                : 0;

        public static string[] SplitOn(this string @this, string thingToSplitOn) =>
            @this.Split(new string[] { thingToSplitOn }, StringSplitOptions.RemoveEmptyEntries);

        public static IEnumerable<T> ParseFromCsv<T>(this string @this, string lineSpltter, string fieldSplitter, Func<string[], T> converter) =>
            @this.SplitOn(lineSpltter)
                .Select(x => x.SplitOn(fieldSplitter))
                .Select(x => converter(x));
    }
}
