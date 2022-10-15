using System.Drawing;
using CSharpHacks.Enum;
using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class ColourExtensionsTests
    {
        [Fact]
        public void UpdateColourChannel_ShouldUpdateColourValue_WhenInvokedUponEachChannel()
        {
            var initial = Color.FromArgb(0, 0, 0, 0);
            var expected = Color.FromArgb(255, 255, 255, 255);

            var updatedRed = initial.UpdateColourChannel(ColourChannel.R, 255);
            var updatedGreen = updatedRed.UpdateColourChannel(ColourChannel.G, 255);
            var updatedBlue = updatedGreen.UpdateColourChannel(ColourChannel.B, 255);
            var actual = updatedBlue.UpdateColourChannel(ColourChannel.A, 255);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ToNormalisedRgba_ShouldReturnExpectedArray_WhenInvokedOnColorObject()
        {
            var initial = Color.FromArgb(alpha: 0, red: 255, green: 0, blue: 255);

            var actual = initial.ToNormalisedRgba();

            actual.Should().ContainInOrder(1d, 0d, 1d, 0d);
        }

        [Fact]
        public void ToNormalisedRgba_ShouldReturnExpectedArray_WhenInvokedOnDoubleArray()
        {
            var initial = Color.FromArgb(alpha: 0, red: 255, green: 0, blue: 255).ToRgbaDoubleArray();

            var actual = initial.ToNormalisedRgba();

            actual.Should().ContainInOrder(1d, 0d, 1d, 0d);
        }

        [Fact]
        public void ToNormalisedArgb_ShouldReturnExpectedArray_WhenInvokedOnColorObject()
        {
            var initial = Color.FromArgb(alpha: 0, red: 255, green: 0, blue: 255);

            var actual = initial.ToNormalisedArgb();

            actual.Should().ContainInOrder(0d, 1d, 0d, 1d);
        }

        [Fact]
        public void ToNormalisedArgb_ShouldReturnExpectedArray_WhenInvokedOnDoubleArray()
        {
            var initial = Color.FromArgb(alpha: 0, red: 255, green: 0, blue: 255).ToArgbDoubleArray();

            var actual = initial.ToNormalisedArgb();

            actual.Should().ContainInOrder(0d, 1d, 0d, 1d);
        }

        [Fact]
        public void ToRgbHexString_ShouldReturnCorrectlyFormattedString_WhenInvoked()
        {
            var colour = Color.FromArgb(alpha: 255, red: 255, green: 0, blue: 0);
            const string expected = "#FF0000";

            var actual = colour.ToRgbHexString();

            actual.Should().Be(expected);
        }

        [Fact]
        public void ToArgbHexString_ShouldReturnCorrectlyFormattedString_WhenInvoked()
        {
            var colour = Color.FromArgb(alpha: 255, red: 255, green: 0, blue: 0);
            const string expected = "#FFFF0000";
            
            var actual = colour.ToArgbHexString();

            actual.Should().Be(expected);
        }

        [Fact]
        public void ToRgbaHexString_ShouldReturnCorrectlyFormattedString_WhenInvoked()
        {
            var colour = Color.FromArgb(alpha: 255, red: 255, green: 0, blue: 0);
            const string expected = "#FF0000FF";

            var actual = colour.ToRgbaHexString();

            actual.Should().Be(expected);
        }

        [Fact]
        public void ToRgbString_ShouldReturnCorrectlyFormattedString_WhenInvoked()
        {
            var colour = Color.FromArgb(alpha: 255, red: 255, green: 0, blue: 0);
            const string expected = "RGB(255, 0, 0)";

            var actual = colour.ToRgbString();

            actual.Should().Be(expected);
        }
    }
}
