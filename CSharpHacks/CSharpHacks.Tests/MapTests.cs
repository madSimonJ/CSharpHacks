using Xunit;
using FluentAssertions;

namespace CSharpHacks.Tests
{
    public class MapTests
    {
        [Fact]
        public void input_should_be_converted_to_ouput()
        {
            var input = "abc";
            var output = input.Map(x => x + "def");
            output.Should().Be("abcdef");
        }

    }
}
