using System.Collections.Generic;
using FluentAssertions;
using Xunit;
// ReSharper disable InconsistentNaming

namespace CSharpHacks.Tests
{
    public class IListTests
    {
        [Fact]
        public void IsNullOrEmpty_on_empty_list_should_return_true()
        {
            var list = new List<string>();

            list.IsNullOrEmpty().Should().Be(true);
        }

        [Fact]
        public void IsNullOrEmpty_on_populated_list_should_return_false()
        {
            var list = new List<string> { "item" };

            list.IsNullOrEmpty().Should().Be(false);
        }

        [Fact]
        public void IsNotNullOrEmpty_on_empty_list_should_return_false()
        {
            var list = new List<string>();

            list.IsNotNullOrEmpty().Should().Be(false);
        }

        [Fact]
        public void IsNotNullOrEmpty_on_populated_list_should_return_true()
        {
            var list = new List<string> { "item" };

            list.IsNotNullOrEmpty().Should().Be(true);
        }

        [Fact]
        public void IsNotNull_on_initialized_list_should_return_true()
        {
            var list = new List<string>();

            list.IsNotNull().Should().Be(true);
        }
    }
}
