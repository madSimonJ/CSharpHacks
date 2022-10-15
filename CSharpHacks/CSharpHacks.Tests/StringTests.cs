using System.Collections.Generic;
using FluentAssertions;
using Xunit;

// ReSharper disable StringLiteralTypo

namespace CSharpHacks.Tests
{
    public class StringTests
    {
        [Fact]
        public void ReplaceFirst_replaces_only_the_first_match()
        {
            var stringWithMultipleRepetitions = "1.2.3";
            stringWithMultipleRepetitions.ReplaceFirst(".", "-").Should().Be("1-2.3");
        }

        [Fact]
        public void ReplaceFirst_with_empty_string_removes_only_the_first_match()
        {
            var stringWithMultipleRepetitions = "1.2.3";
            stringWithMultipleRepetitions.ReplaceFirst(".", "").Should().Be("12.3");
        }

        [Fact]
        public void ReplaceFirst_returns_the_same_result_on_no_matches()
        {
            var stringWithMultipleRepetitions = "1.2.3";
            stringWithMultipleRepetitions.ReplaceFirst(",", "").Should().Be("1.2.3");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IfNullOrEmpty_ShouldReturnInjectedString_WhenInvokedOnNullOrEmptyString(string initial)
        {
            const string expected = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.IfNullOrEmpty(expected);

            actual.Should().Be(expected);
        }

        [Fact]
        public void IfNullOrEmpty_ShouldReturnOriginalString_WhenInvokedOnNonEmptyString()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.IfNullOrEmpty("Sorry, not sorry!");

            actual.Should().Be(initial);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IfNullOrWhitespace_ShouldReturnInjectedString_WhenInvokedOnNullEmptyOrWhitespaceString(string initial)
        {
            const string expected = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.IfNullOrWhitespace(expected);

            actual.Should().Be(expected);   
        }

        [Fact]
        public void IfNullOrWhitespace_ShouldReturnOriginalString_WhenInvokedOnNonEmptyString()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.IfNullOrWhitespace("Sorry, not sorry!");

            actual.Should().Be(initial);
        }

        [Theory]
        [InlineData(1, "1st")]
        [InlineData(2, "2nd")]
        [InlineData(3, "3rd")]
        [InlineData(4, "4th")]

        [InlineData(11, "11th")]
        [InlineData(12, "12th")]
        [InlineData(13, "13th")]
        [InlineData(14, "14th")]

        [InlineData(21, "21st")]
        [InlineData(22, "22nd")]
        [InlineData(23, "23rd")]
        [InlineData(24, "24th")]
        public void ToOrdinalNumeral_ShouldReturnExpectedString_WhenInvokedOnARangeOfIntegers(int value, string expected)
        {
            var actual = value.ToOrdinalNumeral();

            actual.Should().Be(expected);
        }

        [Fact]
        public void ContainsLetters_ShouldReturnTrue_WhenInputStringContainsLetters()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.ContainsLetters();

            actual.Should().BeTrue();
        }

        [Fact]
        public void ContainsLetters_ShouldReturnFalse_WhenInputStringContainsNoLetters()
        {
            const string initial = "1234567890";

            var actual = initial.ContainsLetters();

            actual.Should().BeFalse();
        }

        [Fact]
        public void OnlyContainsLetters_ShouldReturnFalse_WhenInputStringContainsOnlyLetters()
        {
            const string initial = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";

            var actual = initial.OnlyContainsLetters();

            actual.Should().BeTrue();
        }

        [Fact]
        public void OnlyContainsLetters_ShouldReturnFalse_WhenInputStringContainsNonLetters()
        {
            const string initial = "1234567890";

            var actual = initial.OnlyContainsLetters();

            actual.Should().BeFalse();
        }

        [Fact]
        public void ContainsNumbers_ShouldReturnTrue_WhenInputStringContainsNumbers()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.ContainsNumbers();

            actual.Should().BeTrue();
        }

        [Fact]
        public void ContainsNumbers_ShouldReturnFalse_WhenInputStringContainsNoNumbers()
        {
            const string initial = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";

            var actual = initial.ContainsNumbers();

            actual.Should().BeFalse();
        }

        [Fact]
        public void OnlyContainsNumbers_ShouldReturnFalse_WhenInputStringContainsOnlyNumbers()
        {
            const string initial = "1234567890";

            var actual = initial.OnlyContainsNumbers();

            actual.Should().BeTrue();
        }

        [Fact]
        public void OnlyContainsNumbers_ShouldReturnFalse_WhenInputStringContainsNonNumbers()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.OnlyContainsNumbers();

            actual.Should().BeFalse();
        }

        [Fact]
        public void GetLetters_ShouldReturnStringOfOnlyLetters_WhenInputStringContainsAMixOfCharacters()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.GetLetters();

            actual.Should().Be("aHRcHMLydcueWdHViZSjbvdFYgdjkUXcdzlXZhjUQ");
        }

        [Fact]
        public void GetDigits_ShouldReturnStringOfOnlyNumbers_WhenInputStringContainsAMixOfCharacters()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.GetDigits();

            actual.Should().Be("0693391520202101");
        }

        [Fact]
        public void GetAlphaNumerics_ShouldReturnStringOfOnlyAlphaNumerics_WhenInputStringContainsAMixOfCharacters()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.GetAlphaNumerics();

            actual.Should().Be("aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2gdj1kUXc0dzlXZ1hjUQ");
        }

        [Fact]
        public void GetNonAlphaNumerics_ShouldReturnStringOfOnlyNonAlphaNumerics_WhenInputStringContainsAMixOfCharacters()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.GetNonAlphaNumerics();

            actual.Should().Be("/==");
        }

        [Fact]
        public void SplitPascalCase_ShouldReturnSentence_WhenInvokedOnPascalCaseString()
        {
            const string initial = nameof(StringTests);

            var actual = initial.SplitPascalCase();

            actual.Should().Be("String Tests");
        }

        [Fact]
        public void SplitPascalCase_ShouldReturnSentence_WhenInvokedOnPascalCaseStringWithUnderscores()
        {
            const string initial = nameof(SplitPascalCase_ShouldReturnSentence_WhenInvokedOnPascalCaseStringWithUnderscores);

            var actual = initial.SplitPascalCase();

            actual.Should().Be("Split Pascal Case Should Return Sentence When Invoked On Pascal Case String With Underscores");
        }

        [Fact]
        public void EnsureEndsWith_ShouldAppendSuffix_WhenItDoesNotAlreadyExist()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g";
            const string suffix = "/dj1kUXc0dzlXZ1hjUQ==";
            const string expected = initial + suffix;

            var actual = initial.EnsureEndsWith(suffix);

            actual.Should().Be(expected);
        }

        [Fact]
        public void EnsureEndsWith_ShouldNotAppendSuffix_WhenItDoesAlreadyExist()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";
            const string suffix = "/dj1kUXc0dzlXZ1hjUQ==";

            var actual = initial.EnsureEndsWith(suffix);

            actual.Should().Be(initial);
        }

        [Fact]
        public void EnsureStartsWith_ShouldAppendSuffix_WhenItDoesNotAlreadyExist()
        {
            const string prefix = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g";
            const string initial = "/dj1kUXc0dzlXZ1hjUQ==";
            const string expected = prefix + initial;

            var actual = initial.EnsureStartsWith(prefix);

            actual.Should().Be(expected);
        }

        [Fact]
        public void EnsureStartsWith_ShouldNotAppendSuffix_WhenItDoesAlreadyExist()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";
            const string prefix = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g";

            var actual = initial.EnsureStartsWith(prefix);

            actual.Should().Be(initial);
        }

        [Theory]
        [InlineData(0, "moose", "meese")]
        [InlineData(1, "goose", "geese")]
        [InlineData(2, "mouse", "mice")]
        public void Pluralise_ShouldReturnCorrectString_WhenPassedARangeOfValues(int value, string singular, string plural)
        {
            var expected = value == 1 ? singular : plural;

            var actual = singular.Pluralise(value, plural);

            actual.Should().Be(expected);
        }

        [Fact]
        public void StartsWithAnyOf_ShouldReturnTrue_WhenStringDoesStartWithARangeOfPrefixes()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.StartsWithAnyOf(range);

            actual.Should().BeTrue();
        }

        [Fact]
        public void StartsWithAnyOf_ShouldReturnFalse_WhenStringDoesNotStartWithARangeOfPrefixes()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.StartsWithAnyOf(range);

            actual.Should().BeFalse();
        }

        [Fact]
        public void StartsWithNoneOf_ShouldReturnFalse_WhenStringDoesStartWithARangeOfPrefixes()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.StartsWithNoneOf(range);

            actual.Should().BeFalse();
        }

        [Fact]
        public void StartsWithNoneOf_ShouldReturnTrue_WhenStringDoesNotStartWithARangeOfPrefixes()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.StartsWithNoneOf(range);

            actual.Should().BeTrue();
        }

        [Fact]
        public void EndsWithAnyOf_ShouldReturnTrue_WhenStringDoesEndWithARangeOfSuffixes()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "/dj1kUXc0dzlXZ1hjUQ==",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.EndsWithAnyOf(range);

            actual.Should().BeTrue();
        }

        [Fact]
        public void EndsWithAnyOf_ShouldReturnFalse_WhenStringDoesNotEndWithARangeOfSuffixes()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.EndsWithAnyOf(range);

            actual.Should().BeFalse();
        }

        [Fact]
        public void EndsWithNoneOf_ShouldReturnFalse_WhenStringDoesEndWithARangeOfSuffixes()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "/dj1kUXc0dzlXZ1hjUQ==",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.EndsWithNoneOf(range);

            actual.Should().BeFalse();
        }

        [Fact]
        public void EndsWithNoneOf_ShouldReturnTrue_WhenStringDoesNotEndWithARangeOfSuffixes()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.EndsWithNoneOf(range);

            actual.Should().BeTrue();
        }

        [Fact]
        public void ContainsAnyOf_ShouldReturnTrue_WhenStringDoesContainARangeOfSubStrings()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.ContainsAnyOf(range);

            actual.Should().BeTrue();
        }

        [Fact]
        public void ContainsAnyOf_ShouldReturnFalse_WhenStringDoesNotContainARangeOfSubStrings()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.ContainsAnyOf(range);

            actual.Should().BeFalse();
        }

        [Fact]
        public void ContainsNoneOf_ShouldReturnFalse_WhenStringDoesContainARangeOfSubStrings()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.ContainsNoneOf(range);

            actual.Should().BeFalse();
        }

        [Fact]
        public void ContainsNoneOf_ShouldReturnTrue_WhenStringDoesNotContainARangeOfSubStrings()
        {
            const string initial = "aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==";

            var range = new List<string>
            {
                "Never Gonna Give You Up",
                "Never Gonna Let You Down",
                "Never Gonna Run Around",
                "And Desert You"
            };

            var actual = initial.ContainsNoneOf(range);

            actual.Should().BeTrue();
        }
    }
}
