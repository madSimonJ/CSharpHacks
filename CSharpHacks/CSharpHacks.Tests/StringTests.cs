using FluentAssertions;
using Xunit;

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
    }
}
