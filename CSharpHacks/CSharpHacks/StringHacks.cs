using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public static IEnumerable<double> GetNumbers(this string @this) =>
            Regex.Matches(@this, @"-?\d+(\.\d+)?").Cast<Match>().Where(m => m.Success).Select(m => double.Parse(m.Value));

        public static string[] SplitOn(this string @this, string thingToSplitOn) =>
            @this.Split(new string[] { thingToSplitOn }, StringSplitOptions.RemoveEmptyEntries);

        public static IEnumerable<T> ParseFromCsv<T>(this string @this, string lineSplitter, string fieldSplitter, Func<string[], T> converter) =>
            @this.SplitOn(lineSplitter)
                .Select(x => x.SplitOn(fieldSplitter))
                .Select(converter);

        public static string ReplaceFirst(this string @this, string oldValue, string newValue) =>
            new Regex(Regex.Escape(oldValue)).Replace(@this, newValue, 1);


        /// <summary>
        ///     Returns a default string, if a specified string is <see langword="null" />,empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="defaultString">The default string.</param>
        /// <returns>If the input string,<paramref name="str"/>, is null, empty, or whitespace, returns <paramref name="defaultString"/>, otherwise returns <paramref name="str"/>.</returns>
        public static string IfNullOrWhitespace(this string str, string defaultString)
        {
            return string.IsNullOrWhiteSpace(str) ? defaultString : str;
        }

        /// <summary>
        ///     Returns a default string, if a specified string is <see langword="null" />, or empty.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="defaultString">The default string.</param>
        /// <returns>If the input string,<paramref name="str"/>, is null or empty, returns <paramref name="defaultString"/>, otherwise returns <paramref name="str"/>.</returns>
        public static string IfNullOrEmpty(this string str, string defaultString)
        {
            return string.IsNullOrEmpty(str) ? defaultString : str;
        }

        /// <summary>
        ///     Converts a number to its ordinal numeral string representation.
        /// </summary>
        /// <param name="num">The number to convert.</param>
        /// <returns>A string that represents the number, in ordinal numeral form.</returns>
        public static string ToOrdinalNumeral(this int num)
        {
            return (num % 100) switch
            {
                11 => num.ToString("#,###0") + "th",
                12 => num.ToString("#,###0") + "th",
                13 => num.ToString("#,###0") + "th",
                _ => (num % 10) switch
                {
                    1 => num.ToString("#,###0") + "st",
                    2 => num.ToString("#,###0") + "nd",
                    3 => num.ToString("#,###0") + "rd",
                    _ => num.ToString("#,###0") + "th"
                }
            };
        }

        /// <summary>
        ///     Determines whether a string contains any letters.
        /// </summary>
        /// <param name="input">the input string</param>
        /// <returns><c>true</c> is the string contains letters [Aa..Zz]; otherwise <c>false</c>.</returns>
        public static bool ContainsLetters(this string input)
        {
            return input?.Any(char.IsLetter) ?? false;
        }

        /// <summary>
        ///     Determines whether a string contains any uppercase, or lowercase letters. Supports Unicode.
        /// </summary>
        /// <param name="input">the input string</param>
        /// <returns><c>true</c> is the string contains letters [Aa..Zz]; otherwise <c>false</c>.</returns>
        public static bool OnlyContainsLetters(this string input)
        {
            return input?.All(char.IsLetter) ?? false;
        }

        /// <summary>
        ///     Determines whether a string contains any numbers. Supports Unicode.
        /// </summary>
        /// <param name="input">the input string</param>
        /// <returns><c>true</c> is the string contains numbers [0..9]; otherwise <c>false</c>.</returns>
        public static bool ContainsNumbers(this string input)
        {
            return input?.Any(char.IsNumber) ?? false;
        }

        /// <summary>
        ///     Determines whether a string only contains any numbers. Supports Unicode.
        /// </summary>
        /// <param name="input">the input string</param>
        /// <returns><c>true</c> is the string only contains numbers [0..9]; otherwise <c>false</c>.</returns>
        public static bool OnlyContainsNumbers(this string input)
        {
            return input?.All(char.IsNumber) ?? false;
        }

        /// <summary>
        ///    Strips out non-numeric characters in string, returning only digits. Supports Unicode.
        ///    ref.: https://stackoverflow.com/questions/3977497/stripping-out-non-numeric-characters-in-string
        /// </summary>
        /// <param name="input">the input string</param>
        /// <returns>the input string numeric part: for example, if input is "XYZ1234A5U6" it will return "123456"</returns>
        public static string GetDigits(this string input)
        {
            return new string(input?.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        ///     Strips out numeric and special characters in string, returning only letters. Supports Unicode.
        /// </summary>
        /// <param name="input">the input string</param>
        /// <returns>the letters contained within the input string: for example, if input is "XYZ1234A5U6~()" it will return "XYZAU"</returns>
        public static string GetLetters(this string input)
        {
            return new string(input?.Where(char.IsLetter).ToArray());
        }

        /// <summary>
        ///     Strips out any special characters in string, returning only letters and numbers. Supports Unicode.
        /// </summary>
        /// <param name="input">the input string</param>
        /// <returns>the letters contained within the input string: for example, if input is "XYZ1234A5U6~()" it will return "XYZ1234A5U6"</returns>
        public static string GetAlphaNumerics(this string input)
        {
            return new string(input?.Where(char.IsLetterOrDigit).ToArray());
        }

        /// <summary>
        ///     Strips out any letters and numbers in string, returning only non-alpha-numeric characters. Supports Unicode.
        /// </summary>
        /// <param name="input">the input string</param>
        /// <returns>the special characters contained within the input string: for example, if input is "XYZ1234A5U6~()" it will return "~()"</returns>
        public static string GetNonAlphaNumerics(this string input)
        {
            return new string(input?.Where(c => !char.IsLetterOrDigit(c)).ToArray());
        }

        /// <summary>
        ///     Splits a string into sentence form, from a pascal case word.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Returns a <see cref="string"/>, where each word of the input string is separated by a space: for example, if input is "SplitPascalCase", it will return "Split Pascal Case".</returns>
        public static string SplitPascalCase(this string input)
        {
            var words = Regex
                .Matches(input, @"[A-Z]+(?=[A-Z][a-z]+)|\d|[A-Z][a-z]+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();
            return string.Join(" ", words);
        }

        /// <summary>
        ///     Appends a suffix to a string, if the suffix does not already appear at the end of the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns>A new <see cref="string"/> with the assured suffix.</returns>
        public static string EnsureEndsWith(this string text, string suffix)
        {
            return text.EndsWith(suffix) ? text : $"{text}{suffix}";
        }

        /// <summary>
        ///     Prepends a prefix to a string, if the prefix does not already appear at the start of the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns>A new <see cref="string"/> with the assured prefix.</returns>
        public static string EnsureStartsWith(this string text, string prefix)
        {
            return text.StartsWith(prefix) ? text : $"{prefix}{text}";
        }

        /// <summary>
        ///     Pluralises the specified string, based on a input value.
        /// </summary>
        /// <param name="singular">The singular.</param>
        /// <param name="value">The value.</param>
        /// <param name="plural">The plural.</param>
        /// <returns>Either the <paramref name="singular"/> value, or <paramref name="plural"/> value, based on whether <paramref name="value"/> is 1, or otherwise.</returns>
        public static string Pluralise(this string singular, int value, string plural)
        {
            return Math.Abs(value) == 1 ? singular : plural;
        }

        /// <summary>
        ///     Determines whether a string starts with any strings within a given set.
        /// </summary>
        /// <param name="this">The string to test.</param>
        /// <param name="subStrings">The set of sub-strings to search for.</param>
        /// <returns><c>true</c>, if the string does start with any of the sub-strings; otherwise, <c>false</c></returns>
        public static bool StartsWithAnyOf(this string @this, IEnumerable<string> subStrings) => subStrings.Any(@this.StartsWith);

        /// <summary>
        ///     Determines whether a string starts with any strings within a given set.
        /// </summary>
        /// <param name="this">The string to test.</param>
        /// <param name="subStrings">The set of sub-strings to search for.</param>
        /// <returns><c>false</c>, if the string does start with any of the sub-strings; otherwise, <c>true</c></returns>
        public static bool StartsWithNoneOf(this string @this, IEnumerable<string> subStrings) => !@this.StartsWithAnyOf(subStrings);

        /// <summary>
        ///     Determines whether a string contains any strings within a given set.
        /// </summary>
        /// <param name="this">The string to test.</param>
        /// <param name="subStrings">The set of sub-strings to search for.</param>
        /// <returns><c>true</c>, if the string contains any of the sub-strings; otherwise, <c>false</c></returns>
        public static bool ContainsAnyOf(this string @this, IEnumerable<string> subStrings) => subStrings.Any(@this.Contains);

        /// <summary>
        ///     Determines whether a string contains any strings within a given set.
        /// </summary>
        /// <param name="this">The string to test.</param>
        /// <param name="subStrings">The set of sub-strings to search for.</param>
        /// <returns><c>false</c>, if the string contains any of the sub-strings; otherwise, <c>true</c></returns>
        public static bool ContainsNoneOf(this string @this, IEnumerable<string> subStrings) => !@this.ContainsAnyOf(subStrings);

        /// <summary>
        ///     Determines whether a string ends with any strings within a given set.
        /// </summary>
        /// <param name="this">The string to test.</param>
        /// <param name="subStrings">The set of sub-strings to search for.</param>
        /// <returns><c>true</c>, if the string does end with any of the sub-strings; otherwise, <c>false</c></returns>
        public static bool EndsWithAnyOf(this string @this, IEnumerable<string> subStrings) => subStrings.Any(@this.EndsWith);

        /// <summary>
        ///     Determines whether a string ends with any strings within a given set.
        /// </summary>
        /// <param name="this">The string to test.</param>
        /// <param name="subStrings">The set of sub-strings to search for.</param>
        /// <returns><c>false</c>, if the string does end with any of the sub-strings; otherwise, <c>true</c></returns>
        public static bool EndsWithNoneOf(this string @this, IEnumerable<string> subStrings) => !@this.EndsWithAnyOf(subStrings);
    }
}