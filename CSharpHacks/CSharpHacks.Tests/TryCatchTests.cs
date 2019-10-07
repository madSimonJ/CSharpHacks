using System;
using Xunit;
using FluentAssertions;

namespace CSharpHacks.Tests 
{
    public class TryCatchTests
    {
        [Fact]
        public void TryOrFailFast_PerformsAction()
        {
            Action sut = () => TryCatchHacks.TryOrFailFast<InvalidOperationException>(
                () =>
                {
                    var sum = 1 + 1;
                    sum += sum;
                }
            );

            sut.Should().NotThrow<InvalidOperationException>();
        }

        [Fact]
        public void TryOrThrow_ThrowsInvalidOperationException()
        {
            Action sut = () => TryCatchHacks.TryOrThrow<InvalidOperationException>(
                () => throw new InvalidOperationException()
            );

            sut.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void TryOrLogToConsole_ThrowsArgumentException_AndHandleItInternally()
        {
            Action sut = () => TryCatchHacks.TryOrLogToConsole<ArgumentException>(
                () => throw new ArgumentException("To Console")
            );

            sut.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void TryOrLogToDebug_ThrowsArgumentException_AndHandleItInternally()
        {
            Action sut = () => TryCatchHacks.TryOrLogToDebug<ArgumentException>(
                () => throw new ArgumentException("To Debug")
            );

            sut.Should().NotThrow<ArgumentException>();
        }
    }
}
