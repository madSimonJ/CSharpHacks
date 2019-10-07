using FluentAssertions;
using System;
using Xunit;

namespace CSharpHacks.Tests
{
    public class DoubleTests
    {
        [Fact]
        public void Zero_should_be_zero()
        {
            double value = 0;
            value.IsZero().Should().Be(true);
        }

        [Fact]
        public void PointOne_should_not_be_zero()
        {
            double value = 0.1;
            value.IsZero().Should().Be(false);
        }

        [Fact]
        public void Small_value_should_not_be_zero()
        {
            double value = 0.000001;
            value.IsZero().Should().Be(false);
        }

        [Fact]
        public void Two_doubles_should_be_close_within_tolerance()
        {
            double valueOne = 0.34584634561;
            double valueTwo = 0.34565875678;

            valueOne.IsCloseTo(valueTwo, 0.0002).Should().Be(true);
        }

        [Fact]
        public void Two_doubles_should_not_be_close_within_tolerance()
        {
            double valueOne = 0.34584634561;
            double valueTwo = 0.34565875678;

            valueOne.IsCloseTo(valueTwo, 0.0001).Should().Be(false);
        }

        [Fact]
        public void Double_ToDateTime_should_be_correct_datetime()
        {
            double value= 1570443335;
            DateTime expected = new DateTime(2019,10,7,10,15,35);
            value.ToDateTime().Should().Be(expected);
        }

        [Fact]
        public void Double_ToDateTimeMs_should_be_correct_datetime()
        {
            double value= 1570443335000;
            DateTime expected = new DateTime(2019,10,7,10,15,35);
            value.ToDateTimeMs().Should().Be(expected);
        }
    }
}
