using System;
using Xunit;

namespace CSharpHacks.Tests 
{
    public class TryCatchTests
    {
        [Fact]
        public void TryOrThrow_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                TryCatchHacks.TryOrThrow<InvalidOperationException>(
                    () => throw new InvalidOperationException()
                )
            );
        }

        [Fact]
        public void TryOrThrow_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                TryCatchHacks.TryOrThrow<ArgumentException>(
                    () => throw new ArgumentException()
                )
            );
        }
    }
}
