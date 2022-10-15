using CSharpHacks.Tests.Mocks;
using FluentAssertions;
using Xunit;

namespace CSharpHacks
{
    public class EnumExTests
    {
        [Fact]
        public void Count_ShouldReturnToStringEquivalent_WhenCalledOnEnumWithoutDescriptionAttribute()
        {
            const int expected = 4;

            var actual = EnumEx.Count<MockEnum>();

            actual.Should().Be(expected);
        }
    }
}