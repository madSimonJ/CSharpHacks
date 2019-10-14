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
            Action doSum = () =>
            {
                var sum = 1 + 1;
                sum += sum;
            };
            Action sut = () => doSum.TryOrFailFast<InvalidOperationException>();

            sut.Should().NotThrow<InvalidOperationException>();
        }

        [Fact]
        public void TryOrThrow_ThrowsInvalidOperationException()
        {
            Action throwException = () => throw new InvalidOperationException();
            Action sut = () => throwException.TryOrThrow<InvalidOperationException>();

            sut.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void TryOrLogToConsole_ThrowsArgumentException_AndHandleItInternally()
        {
            Action throwException = () => throw new ArgumentException("To Console");
            Action sut = () => throwException.TryOrLogToConsole<ArgumentException>();

            sut.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void TryOrLogToDebug_ThrowsArgumentException_AndHandleItInternally()
        {
            Action throwException = () => throw new ArgumentException("To Debug");
            Action sut = () => throwException.TryOrLogToDebug<ArgumentException>();

            sut.Should().NotThrow<ArgumentException>();
        }
    }
}
