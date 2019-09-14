using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class DictionaryTests
    {
        [Fact]
        public void if_key_contained_return_value()
        {
            var lookupFunction = new Dictionary<string, string>
            {
                {"key", "value" }
            }.ToLookupWithDefault("defaultValue");

            lookupFunction("key").Should().Be("value");
        }

        [Fact]
        public void if_key_not_contained_return_default_value()
        {
            var lookupFunction = new Dictionary<string, string>
            {
                {"key", "value" }
            }.ToLookupWithDefault("defaultValue");

            lookupFunction("somethingelse").Should().Be("defaultValue");
        }
    }
}
