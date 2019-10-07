using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharpHacks.Tests
{
    public class DateTimeTests
    {
        [Fact]
        public void DateTime_ToEpoch_should_be_correct_epoch()
        {
            DateTime value = new DateTime(2019,10,7,10,15,35);
            double expected = 1570443335;
            value.ToEpoch().Should().Be(expected);
        }
        
        [Fact]
        public void DateTime_ToEpochMs_should_be_correct_epoch()
        {
            DateTime value = new DateTime(2019,10,7,10,15,35);
            double expected = 1570443335000;
            value.ToEpochMs().Should().Be(expected);
        }

        
    }
}
