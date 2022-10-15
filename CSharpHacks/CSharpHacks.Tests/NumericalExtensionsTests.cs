using System;
using FluentAssertions;
using Xunit;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace CSharpHacks.Tests
{
    /// <summary>
    ///     Provides extension methods for numeric types.
    /// </summary>
    public class NumericalExtensionsTests
    {
        [Theory]
        [InlineData(1, 1, false)]
        [InlineData(1, 2, false)]
        [InlineData(2, 1, true)]

        [InlineData(1L, 1, false)]
        [InlineData(1L, 2, false)]
        [InlineData(2L, 1, true)]

        [InlineData(1f, 1, false)]
        [InlineData(1f, 2, false)]
        [InlineData(2f, 1, true)]

        [InlineData(1d, 1, false)]
        [InlineData(1d, 2, false)]
        [InlineData(2d, 1, true)]
        public void IsGreaterThan_ShouldReturnCurrentValue_WhenPassedARangeOfNumericalTypes<T>(T value, T min, bool expected) where T: IComparable
        {
            var actual = value.IsGreaterThan(min);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, false)]
        [InlineData(2, 1, true)]

        [InlineData(1L, 1, true)]
        [InlineData(1L, 2, false)]
        [InlineData(2L, 1, true)]

        [InlineData(1f, 1, true)]
        [InlineData(1f, 2, false)]
        [InlineData(2f, 1, true)]

        [InlineData(1d, 1, true)]
        [InlineData(1d, 2, false)]
        [InlineData(2d, 1, true)]
        public void IsGreaterOrEqualToThan_ShouldReturnCurrentValue_WhenPassedARangeOfNumericalTypes<T>(T value, T min, bool expected) where T : IComparable
        {
            var actual = value.IsGreaterThanOrEqualTo(min);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 1, false)]
        [InlineData(1, 2, true)]
        [InlineData(2, 1, false)]

        [InlineData(1L, 1, false)]
        [InlineData(1L, 2, true)]
        [InlineData(2L, 1, false)]

        [InlineData(1f, 1, false)]
        [InlineData(1f, 2, true)]
        [InlineData(2f, 1, false)]

        [InlineData(1d, 1, false)]
        [InlineData(1d, 2, true)]
        [InlineData(2d, 1, false)]
        public void IsLessThan_ShouldReturnCurrentValue_WhenPassedARangeOfNumericalTypes<T>(T value, T min, bool expected) where T : IComparable
        {
            var actual = value.IsLessThan(min);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, true)]
        [InlineData(2, 1, false)]

        [InlineData(1L, 1, true)]
        [InlineData(1L, 2, true)]
        [InlineData(2L, 1, false)]

        [InlineData(1f, 1, true)]
        [InlineData(1f, 2, true)]
        [InlineData(2f, 1, false)]

        [InlineData(1d, 1, true)]
        [InlineData(1d, 2, true)]
        [InlineData(2d, 1, false)]
        public void IsLessOrEqualToThan_ShouldReturnCurrentValue_WhenPassedARangeOfNumericalTypes<T>(T value, T min, bool expected) where T : IComparable
        {
            var actual = value.IsLessThanOrEqualTo(min);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 1, 3, true)]
        [InlineData(2, 1, 3, true)]
        [InlineData(3, 1, 3, true)]
        [InlineData(4, 1, 3, false)]

        [InlineData(1L, 1, 3, true)]
        [InlineData(2L, 1, 3, true)]
        [InlineData(3L, 1, 3, true)]
        [InlineData(4L, 1, 3, false)]

        [InlineData(1f, 1, 3, true)]
        [InlineData(2f, 1, 3, true)]
        [InlineData(3f, 1, 3, true)]
        [InlineData(4f, 1, 3, false)]

        [InlineData(1d, 1, 3, true)]
        [InlineData(2d, 1, 3, true)]
        [InlineData(3d, 1, 3, true)]
        [InlineData(4d, 1, 3, false)]
        public void IsWithinRange_ShouldReturnCurrentValue_WhenPassedARangeOfNumericalTypes<T>(T value, T min, T max, bool expected) where T : IComparable
        {
            var actual = value.IsWithinRange(min, max);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(100, "en", "100")]
        [InlineData(100, "fr", "100")]
        [InlineData(100, "de", "100")]
        [InlineData(1_000, "en", "1,000")]
        [InlineData(1_000, "fr", "1 000")]
        [InlineData(1_000, "de", "1.000")]
        [InlineData(1_000_000, "en", "1,000,000")]
        [InlineData(1_000_000, "fr", "1 000 000")]
        [InlineData(1_000_000, "de", "1.000.000")]
        public void FormatLargeNumber_ShouldFormatCorrectly_WhenPassedARangeOfIntegersInDifferentCultures(int value, string culture, string expected)
        {
            var actual = value.FormatLargeNumber(culture);
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(100L, "en", "100")]
        [InlineData(100L, "fr", "100")]
        [InlineData(100L, "de", "100")]
        [InlineData(1_000L, "en", "1,000")]
        [InlineData(1_000L, "fr", "1 000")]
        [InlineData(1_000L, "de", "1.000")]
        [InlineData(1_000_000L, "en", "1,000,000")]
        [InlineData(1_000_000L, "fr", "1 000 000")]
        [InlineData(1_000_000L, "de", "1.000.000")]
        public void FormatLargeNumber_ShouldFormatCorrectly_WhenPassedARangeOfLongsInDifferentCultures(long value, string culture, string expected)
        {
            var actual = value.FormatLargeNumber(culture);
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(123.4f, 1, "en", "123.4")]
        [InlineData(123.4f, 1, "fr", "123,4")]
        [InlineData(123.4f, 1, "de", "123,4")]
        [InlineData(1_234.5f, 2, "en", "1,234.50")]
        [InlineData(1_234.5f, 2, "fr", "1 234,50")]
        [InlineData(1_234.5f, 2, "de", "1.234,50")]
        [InlineData(1_234_567.89f, 3, "en", "1,234,567.875")]
        [InlineData(1_234_567.89f, 3, "fr", "1 234 567,875")]
        [InlineData(1_234_567.89f, 3, "de", "1.234.567,875")]
        // KNOWN FRAMEWORK BUG: Rounding float errors explained here: https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
        public void FormatLargeNumber_ShouldFormatCorrectly_WhenPassedARangeOfFloatsInDifferentCultures(float value, int maxDecimals, string culture, string expected)
        {
            var actual = value.FormatLargeNumber(maxDecimals, culture);
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(123.4d, 1, "en", "123.4")]
        [InlineData(123.4d, 1, "fr", "123,4")]
        [InlineData(123.4d, 1, "de", "123,4")]
        [InlineData(1_234.5d, 2, "en", "1,234.50")]
        [InlineData(1_234.5d, 2, "fr", "1 234,50")]
        [InlineData(1_234.5d, 2, "de", "1.234,50")]
        [InlineData(1_234_567.89d, 3, "en", "1,234,567.890")]
        [InlineData(1_234_567.89d, 3, "fr", "1 234 567,890")]
        [InlineData(1_234_567.89d, 3, "de", "1.234.567,890")]
        public void FormatLargeNumber_ShouldFormatCorrectly_WhenPassedARangeOfDoublesInDifferentCultures(double value, int maxDecimals, string culture, string expected)
        {
            var actual = value.FormatLargeNumber(maxDecimals, culture);
            actual.Should().Be(expected);
        }
    }
}
