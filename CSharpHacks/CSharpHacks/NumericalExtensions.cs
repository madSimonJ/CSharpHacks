using System;
using System.Globalization;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace CSharpHacks
{
    /// <summary>
    ///     Provides extension methods for numeric types.
    /// </summary>
    public static class NumericalExtensions
    {
        /// <summary>
        ///     Determines whether a value with within a given inclusive range.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="min">The inclusive minimum value.</param>
        /// <param name="max">The inclusive maximum value.</param>
        /// <returns>
        ///   <c>true</c> if the value is within range of the minimum and maximum values; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWithinRange<T>(this T val, T min, T max) where T : IComparable
        {
            return val.IsGreaterThanOrEqualTo(min) && val.IsLessThanOrEqualTo(max);
        }

        /// <summary>
        ///     Determines whether a value is greater than a given minimum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The exclusive minimum value.</param>
        /// <returns>
        ///     <c>true</c> if the value is greater than the given minimum value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGreaterThan<T>(this T value, T min) where T : IComparable
        {
            return value.CompareTo(min) > 0;
        }

        /// <summary>
        ///     Determines whether a value is less than a given maximum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="max">The exclusive maximum value.</param>
        /// <returns>
        ///     <c>true</c> if the value is less than the given maximum value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLessThan<T>(this T value, T max) where T : IComparable
        {
            return value.CompareTo(max) < 0;
        }

        /// <summary>
        ///     Determines whether a value is greater than, or equal to, a given minimum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The inclusive minimum value.</param>
        /// <returns>
        ///     <c>true</c> if the value is greater than the given minimum value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGreaterThanOrEqualTo<T>(this T value, T min) where T : IComparable
        {
            return value.CompareTo(min) >= 0;
        }

        /// <summary>
        ///     Determines whether a value is less than, or equal to, a given maximum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="max">The inclusive maximum value.</param>
        /// <returns>
        ///     <c>true</c> if the value is less than the given maximum value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLessThanOrEqualTo<T>(this T value, T max) where T : IComparable
        {
            return value.CompareTo(max) <= 0;
        }

        /// <summary>
        ///     Formats the number in text form, with numerical group separators, for the current locale, set within <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="number">The number to format.</param>
        /// <param name="locale">The locale to use to determine separator amounts, and deliminators.</param>
        /// <returns>Returns a string representation of the number, in human readable form.</returns>
        public static string FormatLargeNumber(this int number, string locale = "en") 
            => string.Format(CultureInfo.GetCultureInfo(locale), "{0:#,##0.##}", number);

        /// <summary>
        ///     Formats the number in text form, with numerical group separators, for the current locale, set within <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="number">The number to format.</param>
        /// <param name="locale">The locale to use to determine separator amounts, and deliminators.</param>
        /// <returns>Returns a string representation of the number, in human readable form.</returns>
        public static string FormatLargeNumber(this long number, string locale = "en") 
            => string.Format(CultureInfo.GetCultureInfo(locale), "{0:#,##0.##}", number);

        /// <summary>
        ///     Formats the number in text form, with numerical group separators, for the current locale, set within <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="number">The number to format.</param>
        /// <param name="locale">The locale to use to determine separator amounts, and deliminators.</param>
        /// <param name="maxDecimals">The maximum number of decimal places to round the number to.</param>
        /// <returns>Returns a string representation of the number, in human readable form.</returns>
        public static string FormatLargeNumber(this float number, int maxDecimals = 2, string locale = "en")
            => string.Format(CultureInfo.GetCultureInfo(locale), $"{{0:N{maxDecimals}}}", number);

        /// <summary>
        ///     Formats the number in text form, with numerical group separators, for the current locale, set within <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="number">The number to format.</param>
        /// <param name="locale">The locale to use to determine separator amounts, and deliminators.</param>
        /// <param name="maxDecimals">The maximum number of decimal places to round the number to.</param>
        /// <returns>Returns a string representation of the number, in human readable form.</returns>
        public static string FormatLargeNumber(this double number, int maxDecimals = 2, string locale = "en")
            => string.Format(CultureInfo.GetCultureInfo(locale), $"{{0:N{maxDecimals}}}", number);
    }
}
