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
    }
}
