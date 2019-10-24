using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CSharpHacks.Tests
{
    public class ObjectTests
    {
        [Fact]
        public void Also_should_run_additional_code()
        {
            var result = ("a" + "b")
                .Also(TestConsole.WriteLine);

            result.Should().Be("ab");
            TestConsole.TextWritten.Should().Be("ab");
        }

        private static class TestConsole
        {
            public static string TextWritten = "";

            public static void WriteLine(string text)
            {
                TextWritten += text;
            }
        }
    }
}
