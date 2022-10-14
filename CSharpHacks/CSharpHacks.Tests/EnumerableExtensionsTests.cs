using System;
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
        
        [Fact]
        public void Omit_should_omit_last_x_elements_of_an_enumerable()
        {
            var expected = new[] { 1, 2, 3, 4, 5, 6};
            var test = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var result = test.Omit(4);

            result.Should().Equal(expected);
        }

        [Fact]
        public void Omit_should_return_empty_enumerable_if_number_is_larger_than_size_of_enumerable()
        {
            var expected = new int[] { };
            var test = new[] { 1, 2, 3, 4, 5, 6};

            var result = test.Omit(1000);

            result.Should().Equal(expected);
        }

        [Fact]
        public void Omit_should_be_affected_by_mutating_source()
        {
            var expected = new[] { 0, 2, 3, 4, 5, 6 };
            var test = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> result = test.Omit(4);
            test[0] = 0;

            result.Should().Equal(expected);
        }

        [Fact]
        public void Omit_should_update_with_growing_source()
        {
            var expected = new[] { 1, 2, 3, 4, 5 };
            var test = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.ToList();

            IEnumerable<int> result = test.Omit(6);
            test.Add(11);

            result.Should().Equal(expected);
        }

        [Fact]
        public void Last_should_Return_last_x_elements()
        {
            var expected = new[] { 7, 8, 9};
            var test = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            var result = test.Last(3);

            result.Should().Equal(expected);
        }

        [Fact]
        public void Last_should_return_whole_array_if_number_exceeds_element_size()
        {
            var expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var test = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

            var result = test.Last(1000);

            result.Should().Equal(expected);
        }

        [Fact]
        public void Last_should_be_affected_by_mutating_source()
        {
            var expected = new[] { 7, 8, 0 };
            var test = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            IEnumerable<int> result = test.Last(3);
            test[8] = 0;

            result.Should().Equal(expected);
        }

        [Fact]
        public void Last_should_update_with_growing_source()
        {
            var expected = new[] { 8, 9, 10 };
            var test = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToList();

            IEnumerable<int> result = test.Last(3);
            test.Add(10);

            result.Should().Equal(expected);
        }

        [Fact]
        public void Occurence_should_return_frequency_of_each_element()
        {
            string[] test = {"a", "ab", "a", "c", "b", "ab", "a", "hi", "my name", "a", "c"};
            var expected = new Dictionary<string, int>()
            {
                {"a", 4},
                {"ab", 2},
                {"b",1},
                {"c", 2},
                {"hi", 1},
                {"my name", 1}
            };
            Assert.Equal(expected, test.Occurrence());
        }

        [Fact]
        public void Batch_should_return_groups_of_given_elements()
        {
            int[] test = { 1, 2, 3, 4, 5, 6, 7};
            var expected = new[] 
            {
                new[] {1,2},
                new[] {3,4},
                new[] {5,6},
                new[] {7}
            };

            var result = test.Batch(2).ToArray();

            result.Length.Should().Be(expected.Length);
            for (int index = 0; index < expected.Length; index++)
            {
                result[index].Should().Equal(expected[index]);
            }
        }

        [Fact]
        public void Random_ShouldReturnExpectedValue_WhenCalledWithDeterministicRng()
        {
            EnumerableExtensions.RandomNumberGenerator = new Random(69);

            var data = Enumerable.Range(0, 100).ToList();

            var actual = new List<int>();

            for (var i = 0; i < 4; i++)
            {
                actual.Add(data.Random());
            }

            actual.Should().ContainInOrder(77, 6, 99, 28);
        }

        [Fact]
        public void AddOrUpdate_ShouldAddEntry_WhenItDoesNotAlreadyExistInTheSortedDictionary()
        {
            var actual = new SortedDictionary<string, string>();
            
            actual.AddOrUpdate("WillAdd", "Hello World!");

            actual.Should().HaveCount(1);
            actual.Should().Contain("WillAdd", "Hello World!");
        }

        [Fact]
        public void AddOrUpdate_ShouldUpdateEntry_WhenItDoesAlreadyExistInTheSortedDictionary()
        {
            var actual = new SortedDictionary<string, string>();

            actual.AddOrUpdate("WillUpdate", "¡Hola, mundo!");
            actual.AddOrUpdate(new KeyValuePair<string, string>("WillUpdate", "Hello World!"));

            actual.Should().HaveCount(1);
            actual.Should().NotContain("WillUpdate", "¡Hola, mundo!");
            actual.Should().Contain("WillUpdate", "Hello World!");
        }

        [Fact]
        public void AddOrUpdateRange_ShouldAddEntries_WhenTheyDoNotAlreadyExistInTheSortedDictionary()
        {
            var actual = new SortedDictionary<string, string>();

            var dataToAdd = new Dictionary<string, string>()
            {
                { "English", "Hello, World!" },
                { "Spanish", "¡Hola, mundo!" },
                { "German", "Hallo Welt!" },
                { "Goa'uld", "Chel hol, Tau'ri!" },
                { "Elder Futhark", "ᚺᛖᛚᛟ ᛗᛁᛞᚷᚨᚱᛞ" },
            };

            actual.AddOrUpdateRange(dataToAdd);
            
            actual.Should().HaveCount(5);
            actual.Should().Contain(dataToAdd);
        }

        [Fact]
        public void AddOrUpdateRange_ShouldUpdateEntries_WhenTheyDoAlreadyExistInTheSortedDictionary()
        {
            var actual = new SortedDictionary<string, string>();

            var dataToAdd = new Dictionary<string, string>()
            {
                { "English", "This will be updated later." },
                { "Spanish", "¡Hola, mundo!" },
                { "German", "Hallo Welt!" },
            };

            actual.AddOrUpdateRange(dataToAdd);

            var dataToAddOrUpdate = new Dictionary<string, string>()
            {
                { "English", "Hello, World!" },
                { "Goa'uld", "Chel hol, Tau'ri!" },
                { "Elder Futhark", "ᚺᛖᛚᛟ ᛗᛁᛞᚷᚨᚱᛞ" },
            };

            actual.AddOrUpdateRange(dataToAddOrUpdate);

            actual.Should().HaveCount(5);
            actual.Should().NotContain("English", "This will be updated later.");
            actual.Should().Contain("English", "Hello, World!");
        }

        [Fact]
        public void AddOrUpdate_ShouldAddEntry_WhenItDoesNotAlreadyExistInTheDictionary()
        {
            var actual = new Dictionary<string, string>();

            actual.AddOrUpdate("WillAdd", "Hello World!");

            actual.Should().HaveCount(1);
            actual.Should().Contain("WillAdd", "Hello World!");
        }

        [Fact]
        public void AddOrUpdate_ShouldUpdateEntry_WhenItDoesAlreadyExistInTheDictionary()
        {
            var actual = new Dictionary<string, string>();

            actual.AddOrUpdate("WillUpdate", "¡Hola, mundo!");
            actual.AddOrUpdate(new KeyValuePair<string, string>("WillUpdate", "Hello World!"));

            actual.Should().HaveCount(1);
            actual.Should().NotContain("WillUpdate", "¡Hola, mundo!");
            actual.Should().Contain("WillUpdate", "Hello World!");
        }

        [Fact]
        public void AddOrUpdateRange_ShouldAddEntries_WhenTheyDoNotAlreadyExistInTheDictionary()
        {
            var actual = new Dictionary<string, string>();

            var dataToAdd = new Dictionary<string, string>()
            {
                { "English", "Hello, World!" },
                { "Spanish", "¡Hola, mundo!" },
                { "German", "Hallo Welt!" },
                { "Goa'uld", "Chel hol, Tau'ri!" },
                { "Elder Futhark", "ᚺᛖᛚᛟ ᛗᛁᛞᚷᚨᚱᛞ" },
            };

            actual.AddOrUpdateRange(dataToAdd);

            actual.Should().HaveCount(5);
            actual.Should().Contain(dataToAdd);
        }

        [Fact]
        public void AddOrUpdateRange_ShouldUpdateEntries_WhenTheyDoAlreadyExistInTheDictionary()
        {
            var actual = new Dictionary<string, string>();

            var dataToAdd = new Dictionary<string, string>()
            {
                { "English", "This will be updated later." },
                { "Spanish", "¡Hola, mundo!" },
                { "German", "Hallo Welt!" },
            };

            actual.AddOrUpdateRange(dataToAdd);

            var dataToAddOrUpdate = new Dictionary<string, string>()
            {
                { "English", "Hello, World!" },
                { "Goa'uld", "Chel hol, Tau'ri!" },
                { "Elder Futhark", "ᚺᛖᛚᛟ ᛗᛁᛞᚷᚨᚱᛞ" },
            };

            actual.AddOrUpdateRange(dataToAddOrUpdate);

            actual.Should().HaveCount(5);
            actual.Should().NotContain("English", "This will be updated later.");
            actual.Should().Contain("English", "Hello, World!");
        }

        [Fact]
        public void AddIfNotPresent_ShouldReturnTrue_WhenItemAddedToDictionary()
        {
            var actual = new Dictionary<string, string>();
            
            var added = actual.AddIfNotPresent("English", "Hello, World!");
            
            added.Should().BeTrue();
            actual.Should().HaveCount(1);
            actual.Should().Contain("English", "Hello, World!");
        }

        [Fact]
        public void AddIfNotPresent_ShouldReturnFalse_WhenItemNotAddedToDictionary()
        {
            var actual = new Dictionary<string, string>
            {
                { "English", "Hello, World!" }
            };

            var added = actual.AddIfNotPresent("English", "This will not be updated.");

            added.Should().BeFalse();
            actual.Should().HaveCount(1);
            actual.Should().Contain("English", "Hello, World!");
            actual.Should().NotContain("English", "This will not be updated.");
        }

        [Fact]
        public void AddIfNotPresent_ShouldReturnTrue_WhenItemAddedToCollection()
        {
            var actual = new List<int>();

            var added = actual.AddIfNotPresent(69);

            added.Should().BeTrue();
            actual.Should().HaveCount(1);
            actual.Should().Contain(69);
        }

        [Fact]
        public void AddIfNotPresent_ShouldReturnFalse_WhenItemNotAddedToCollection()
        {
            var actual = new List<int> { 69 };

            var added = actual.AddIfNotPresent(69);

            added.Should().BeFalse();
            actual.Should().HaveCount(1);
            actual.Should().Contain(69);
        }

        [Fact]
        public void RemoveIfPresent_ShouldReturnFalse_WhenItemRemovedFromDictionary()
        {
            var actual = new Dictionary<string, string>();

            var added = actual.RemoveIfPresent("English");

            added.Should().BeFalse();
            actual.Should().BeEmpty();
            actual.Should().NotContainKey("English");
        }

        [Fact]
        public void RemoveIfPresent_ShouldReturnTrue_WhenItemNotRemovedFromDictionary()
        {
            var actual = new Dictionary<string, string>
            {
                { "English", "Hello, World!" }
            };

            var added = actual.RemoveIfPresent("English");

            added.Should().BeTrue();
            actual.Should().BeEmpty();
            actual.Should().NotContain("English", "Hello, World!");
        }

        [Fact]
        public void RemoveIfPresent_ShouldReturnFalse_WhenItemRemovedFromCollection()
        {
            var actual = new List<int>();

            var added = actual.RemoveIfPresent(69);

            added.Should().BeFalse();
            actual.Should().BeEmpty();
            actual.Should().NotContain(69);
        }

        [Fact]
        public void RemoveIfPresent_ShouldReturnTrue_WhenItemNotRemovedFromCollection()
        {
            var actual = new List<int> { 69 };

            var added = actual.RemoveIfPresent(69);

            added.Should().BeTrue();
            actual.Should().BeEmpty();
            actual.Should().NotContain(69);
        }

        [Fact]
        public void EnsureExistence_ShouldAddItem_IfInvokedAsTrue()
        {
            var actual = Enumerable.Range(0, 100).ToList();

            actual.EnsureExistence(value: 101, shouldExist: true);

            actual.Should().Contain(101);
        }

        [Fact]
        public void EnsureExistence_ShouldRemoveItem_IfInvokedAsFalse()
        {
            var actual = Enumerable.Range(0, 100).ToList();

            actual.EnsureExistence(value: 69, shouldExist: false);

            actual.Should().NotContain(69);
        }

        [Fact]
        public void ContainsAny_ShouldReturnTrue_WhenCollectionDoesContainElement()
        {
            var data = Enumerable.Range(0, 100).ToList();
            var range = new List<int> { 69, 101, 2600 };

            var actual = data.ContainsAny(range);

            actual.Should().BeTrue();
        }

        [Fact]
        public void ContainsAny_ShouldReturnFalse_WhenCollectionDoesNotContainAnyElement()
        {
            var data = Enumerable.Range(0, 100).ToList();
            var range = new List<int> { 690, 101, 2600 };

            var actual = data.ContainsAny(range);

            actual.Should().BeFalse();
        }

        [Fact]
        public void ContainsAny_ShouldReturnTrue_WhenDictionaryDoesContainElement()
        {
            var data = Enumerable.Range(0, 100).ToDictionary(p => p.ToString());
            var range = new Dictionary<string, int>
            {
                { "69", 69 }, 
                { "101", 101 }, 
                { "NaN", -1 }
            };

            var actual = data.ContainsAny(range);

            actual.Should().BeTrue();
        }

        [Fact]
        public void ContainsAny_ShouldReturnFalse_WhenDictionaryDoesNotContainAnyElement()
        {
            var data = Enumerable.Range(0, 100).ToDictionary(p => p.ToString());
            var range = new Dictionary<string, int>
            {
                { "690", 690 },
                { "101", 101 },
                { "NaN", -1 }
            };

            var actual = data.ContainsAny(range);

            actual.Should().BeFalse();
        }

        [Fact]
        public void ContainsAnyKey_ShouldReturnTrue_WhenDictionaryDoesContainElement()
        {
            var data = Enumerable.Range(0, 100).ToDictionary(p => p.ToString());
            var range = new List<string> { "69", "101", "NaN" };

            var actual = data.ContainsAnyKey(range);

            actual.Should().BeTrue();
        }

        [Fact]
        public void ContainsAnyKey_ShouldReturnFalse_WhenDictionaryDoesNotContainAnyElement()
        {
            var data = Enumerable.Range(0, 100).ToDictionary(p => p.ToString());
            var range = new List<string> { "690", "101", "NaN" };

            var actual = data.ContainsAnyKey(range);

            actual.Should().BeFalse();
        }

        [Fact]
        public void ContainsAnyValue_ShouldReturnTrue_WhenDictionaryDoesContainElement()
        {
            var data = Enumerable.Range(0, 100).ToDictionary(p => p.ToString());
            var range = new List<int> { 69, 101, 2600 };

            var actual = data.ContainsAnyValue(range);

            actual.Should().BeTrue();
        }

        [Fact]
        public void ContainsAnyValue_ShouldReturnFalse_WhenDictionaryDoesNotContainAnyElement()
        {
            var data = Enumerable.Range(0, 100).ToDictionary(p => p.ToString());
            var range = new List<int> { 690, 101, 2600 };

            var actual = data.ContainsAnyValue(range);

            actual.Should().BeFalse();
        }
    }
}
