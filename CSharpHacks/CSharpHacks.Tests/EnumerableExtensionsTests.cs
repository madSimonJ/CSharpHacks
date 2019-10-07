using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void should_return_distinct_list_by_key()
        {
            var source = new List<(int Key, string Value)>
            {
                (1, "Test"),
                (2, "Test"),
                (2, "Test"),
                (3, "Test")
            };

            var result = source.DistinctBy(x => x.Key).ToList();
            result.Count.Should().Be(3);
            result.Count(x => x.Key == 2).Should().Be(1);
        }

        [Fact]
        public void should_return_empty_enumerable_if_null()
        {
            List<int> nullList = null;

            var result = nullList.EmptyIfNull();
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void should_return_input_enumerable_if_not_null()
        {
            List<int> list = new List<int>{1, 2, 3};

            var result = list.EmptyIfNull();
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void should_return_minimum_by_selector()
        {
            var source = new List<(int Key, string Value)>
            {
                (1, "ZZZ"),
                (1, "ABC"),
                (2, "YYY"),
                (3, "AAA")
            };

            var result = source.SelectByMin(x => x.Key).ToList();
            result.Count.Should().Be(2);
            result.Should().Contain(x => x.Value == "ZZZ");
            result.Should().Contain(x => x.Value == "ABC");
        }

        [Fact]
        public void should_return_maximum_by_selector()
        {
            var source = new List<(int Key, string Value)>
            {
                (3, "ZZZ"),
                (3, "ABC"),
                (2, "YYY"),
                (1, "AAA")
            };

            var result = source.SelectByMax(x => x.Key).ToList();
            result.Count.Should().Be(2);
            result.Should().Contain(x => x.Value == "ZZZ");
            result.Should().Contain(x => x.Value == "ABC");
        }

        [Fact]
        public void should_take_first_two_elements_by_key()
        {
            var source = new List<(int Key, string Value)>
            {
                (3, "AAA"),
                (3, "BBB"),
                (3, "CCC"),
                (2, "DDD"),
                (2, "EEE"),
                (1, "FFF")
            };

            var result = source.TakePerKey(x => x.Key, 2).ToList();
            result.Count.Should().Be(5);
            result.Should().NotContain(x => x.Value == "CCC");
        }
    }
}
