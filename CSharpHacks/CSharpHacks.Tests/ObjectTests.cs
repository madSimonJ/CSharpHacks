using System;
using System.Dynamic;
using FluentAssertions;
using Xunit;

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

        #region Dynamic Properties

        // ExpandoObject does not play nice with FluentAssertion's "Should()", as it is dynamically typed.

        private interface IMockInterface { }

        private class MockObject : IMockInterface { }
        private class MockObject2 : IMockInterface { }

        [Fact]
        public void DynamicProperties_ShouldReturnEmptyExpandoObject_WhenFirstCalled()
        {
            var sut = new MockObject();

            var actual = sut.DynamicProperties();

            Assert.IsType<ExpandoObject>(actual);
            Assert.Empty(actual);
        }

        [Fact]
        public void DynamicProperties_ShouldRetainData_WhenPassedArguments()
        {
            var sut = new MockObject();

            const string expected = "Hello World!";
            var actual = sut.DynamicProperties();

            sut.DynamicProperties().HelloWorld = expected;

            Assert.NotEmpty(actual);
            Assert.Equal(actual.HelloWorld, expected);
        }

        #endregion

        #region Dynamic Casting

        [Fact]
        public void To_ShouldUnboxToT_WhenAppliedToBoxedObjectOfT()
        {
            const int expected = 69;
            var boxed = (object)expected;

            var actual = boxed.To<int>();

            actual.Should().BeOfType(typeof(int));
            actual.Should().Be(expected);
        }

        [Fact]
        public void To_ShouldThrowInvalidCastException_WhenAppliedToIncompatibleObject()
        {
            object boxed = 0;
            boxed
                .Invoking(b => b.To<float>())
                .Should()
                .Throw<InvalidCastException>();
        }

        [Fact]
        public void As_ShouldUnboxToT_WhenAppliedToBoxedValueTypeObjectOfT()
        {
            const int expected = 69;
            var boxed = (object)expected;

            var actual = boxed.As<int>();

            actual.Should().BeOfType(typeof(int));
            actual.Should().Be(expected);
        }

        [Fact]
        public void As_ShouldUnboxToDefaultOfT_WhenAppliedToBoxedValueTypeObjectNotOfT()
        {
            const int initial = 69;
            const float cast = initial;
            var boxed = (object)cast;

            var actual = boxed.As<int>();

            actual.Should().BeOfType(typeof(int));
            actual.Should().Be(default);
        }

        [Fact]
        public void As_ShouldUnboxToT_WhenAppliedToBoxedReferenceTypeObjectOfT()
        {
            var mockObject = new MockObject();
            var boxed = (object)mockObject;

            var actual = boxed.As<IMockInterface>();

            actual.Should().NotBeNull();
            actual.Should().BeAssignableTo<MockObject>();
        }

        [Fact]
        public void As_ShouldUnboxToNull_WhenAppliedToBoxedReferenceTypeObjectNotOfT()
        {
            var mockObject = new MockObject();
            var boxed = (object)mockObject;
            
            var actual = boxed.As<MockObject2>();

            actual.Should().BeNull();
        }

        #endregion
    }
}
