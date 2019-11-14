using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class ByteArrayTests
    {
        [Fact]
        public void CheckNullDelimiter()
        {
            var byteArray = Enumerable.Range(0, 255).Select(x => (byte)x).ToArray();

            byteArray.ToHex((string)null).Should().Be(BitConverter.ToString(byteArray).Replace("-", string.Empty));
            byteArray.ToHex(0, (string)null).Should().Be(BitConverter.ToString(byteArray, 0).Replace("-", string.Empty));
            byteArray.ToHex(0, 1, (string)null).Should().Be(BitConverter.ToString(byteArray, 0, 1).Replace("-", string.Empty));
        }

        [Fact]
        public void CheckEmptyDelimiter()
        {
            var byteArray = Enumerable.Range(0, 255).Select(x => (byte)x).ToArray();

            byteArray.ToHex(string.Empty).Should().Be(BitConverter.ToString(byteArray).Replace("-", string.Empty));
            byteArray.ToHex(0, string.Empty).Should().Be(BitConverter.ToString(byteArray, 0).Replace("-", string.Empty));
            byteArray.ToHex(0, 1, string.Empty).Should().Be(BitConverter.ToString(byteArray, 0 ,1).Replace("-", string.Empty));
        }

        [Fact]
        public void CheckBasicConversion()
        {
            var byteArray = Enumerable.Range(0, 255).Select(x => (byte)x).ToArray();

            // without delimiter
            byteArray.ToHex().Should().Be(BitConverter.ToString(byteArray));

            // with delimiter
            byteArray.ToHex("+-+").Should().Be(BitConverter.ToString(byteArray).Replace("-", "+-+"));
        }

        [Fact]
        public void CheckConversionWithStart()
        {
            var byteArray = Enumerable.Range(0, 255).Select(x => (byte)x).ToArray();

            // without delimiter
            byteArray.ToHex(20).Should().Be(BitConverter.ToString(byteArray, 20));

            // with delimiter
            byteArray.ToHex(20, "+-+").Should().Be(BitConverter.ToString(byteArray, 20).Replace("-", "+-+"));
        }

        [Fact]
        public void CheckConversionWithStartAndLength()
        {
            var byteArray = Enumerable.Range(0, 255).Select(x => (byte)x).ToArray();

            // without delimiter
            byteArray.ToHex(20, 5).Should().Be(BitConverter.ToString(byteArray, 20, 5));

            // with delimiter
            byteArray.ToHex(20, 5, "+-+").Should().Be(BitConverter.ToString(byteArray, 20, 5).Replace("-", "+-+"));
        }
    }
}
