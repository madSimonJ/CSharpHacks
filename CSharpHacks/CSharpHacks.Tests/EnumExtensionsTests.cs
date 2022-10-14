using System;
using CSharpHacks.Tests.Mocks;
using FluentAssertions;
using Xunit;

namespace CSharpHacks
{
    public class EnumExtensionsTests
    {
        [Fact]
        public void GetDescription_ShouldReturnCorrectString_WhenCalledOnEnumWithDescriptionAttribute()
        {
            const string expected = "First Value";

            var actual = MockEnum.First.GetDescription();

            actual.Should().Be(expected);
        }

        [Fact]
        public void GetDescription_ShouldReturnToStringEquivalent_WhenCalledOnEnumWithoutDescriptionAttribute()
        {
            var expected = MockEnum.Fourth.ToString();

            var actual = MockEnum.Fourth.GetDescription();

            actual.Should().Be(expected);
        }
    }
}