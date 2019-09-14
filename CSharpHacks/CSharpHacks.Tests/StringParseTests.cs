using System;
using Xunit;
using FluentAssertions;

namespace CSharpHacks.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Valid_integer_should_parse_to_integer()
        {
            var stringThatIsAnInt = "123";
            stringThatIsAnInt.ToInt().Should().Be(123);
        }

        [Fact]
        public void invalid_integer_should_parse_to_zero()
        {
            var stringThatIsNotAnInt = "123a";
            stringThatIsNotAnInt.ToInt().Should().Be(0);
        }

        [Fact]
        public void Valid_double_should_parse_to_double()
        {
            var stringThatIsaDouble = "123.45";
            stringThatIsaDouble.ToDouble().Should().Be(123.45);
        }

        [Fact]
        public void invalid_double_should_parse_to_zero()
        {
            var stringThatIsNotaDouble = "123a";
            stringThatIsNotaDouble.ToDouble().Should().Be(0.0);
        }

        [Fact]
        public void Valid_decimal_should_parse_to_decimal()
        {
            var stringThatIsaDecimal = "123.45";
            stringThatIsaDecimal.ToDecimal().Should().Be(123.45M);
        }

        [Fact]
        public void invalid_decimal_should_parse_to_zero()
        {
            var stringThatIsNotaDouble = "123a";
            stringThatIsNotaDouble.ToDecimal().Should().Be(0.0M);
        }

        [Fact]
        public void Valid_float_should_parse_to_float()
        {
            var stringThatIsaDecimal = "123.45";
            stringThatIsaDecimal.ToFloat().Should().Be(123.45F);
        }

        [Fact]
        public void invalid_float_should_parse_to_zero()
        {
            var stringThatIsNotaDouble = "123a";
            stringThatIsNotaDouble.ToFloat().Should().Be(0.0F);
        }
    }
}
