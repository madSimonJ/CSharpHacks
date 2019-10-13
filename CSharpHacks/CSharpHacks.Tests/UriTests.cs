using System;
using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class UriTests
    {
        [Fact]
        public void QueryString_should_contain_existing_and_added_query_param()
        {
            var uri = new Uri("http://localhost/?param1=value1");
            uri = uri.AddParameter("newParam", "newValue");

            uri.Query.Should().Be("?param1=value1&newParam=newValue");
        }

        [Fact]
        public void QueryString_should_contain_query_param()
        {
            var uri = new Uri("http://localhost/");
            uri = uri.AddParameter("newParam", "newValue");

            uri.Query.Should().Be("?newParam=newValue");
        }

        [Fact]
        public void QueryString_should_omit_missing_value()
        {
            var uri = new Uri("http://localhost/");

            uri = uri.AddParameter("newParam");

            uri.Query.Should().Be("?newParam");
        }

        [Fact]
        public void QueryString_should_add_many_parameters()
        {
            var uri = new Uri("http://localhost/");
            var parameters = new System.Collections.Generic.Dictionary<string, string>()
            {
                ["newParam1"] = "newValue1",
                ["newParam2"] = "newValue2",
                ["newParam3"] = "newValue3",
                ["newParam4"] = "newValue4",
                ["newParam5"] = "newValue5",
            };

            uri = uri.AddParameter(parameters);

            uri.Query.Should().Be("?newParam1=newValue1&newParam2=newValue2&newParam3=newValue3&newParam4=newValue4&newParam5=newValue5");
        }
    }
}
