using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class IntTests
    {
        [Fact]
        public void ReplaceFirst_replaces_only_the_first_match()
        {
            int number = 54674;
            number.SpesificDigitOfNumber(1).Should().Be(7);
        }
    }
}
