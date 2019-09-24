using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class AdjustTests
    {
        [Fact]
        public void AdjustArrayByPos()
        {
            var stringArray = new[]
            {
                "a",
                "b",
                "c",
                "d"
            };

            var array2 = stringArray.Adjust(x => x.ByPosition(2), "z");
            array2.Should().Equal("a", "b", "z", "d");
        }

        [Fact]
        public void AdjustArrayByPosTwice()
        {
            var stringArray = new[]
            {
                "a",
                "b",
                "c",
                "d"
            }
                .Adjust(x => x.ByPosition(2), "z")
                .Adjust(x => x.ByPosition(3), "y");
            stringArray.Should().Equal("a", "b", "z", "y");
        }

        [Fact]
        public void AdjustArrayByProperties()
        {
            var stringArray = new[]
            {
                "a",
                "bb",
                "cccc",
                "ddddd"
            }
                .Adjust(x => x.ByProp(y => y.Length == 2), "zz");
            stringArray.Should().Equal(
                 "a",
                "zz",
                "cccc",
                "ddddd");
        }
    }
}
