using CSharpHacks.Reflection;
using CSharpHacks.Tests.Mocks;
using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class CustomAttributeExtensionsTests
    {
        #region HasCustomAttribute

        [Fact]
        public void HasCustomAttribute_ShouldReturnTrue_WhenTypeHasAttributeOfT()
        {
            var sut = typeof(MockAttributedObject);

            var actual = sut.HasCustomAttribute<MockCustomAttributeAttribute>();

            actual.Should().BeTrue();
        }

        [Fact]
        public void HasCustomAttribute_ShouldReturnTrue_WhenAssemblyHasAttributeOfT()
        {
            var sut = typeof(MockAttributedObject).Assembly;

            var actual = sut.HasCustomAttribute<MockCustomAttributeAttribute>();

            actual.Should().BeTrue();
        }

        [Fact]
        public void HasCustomAttribute_ShouldReturnTrue_WhenPropertyHasAttributeOfT()
        {
            var sut = typeof(MockAttributedObject).GetProperty("Integer");

            var actual = sut.HasCustomAttribute<MockCustomAttributeAttribute>();

            actual.Should().BeTrue();
        }

        [Fact]
        public void HasCustomAttribute_ShouldReturnTrue_WhenFieldHasAttributeOfT()
        {
            var sut = typeof(MockAttributedObject).GetField("HelloWorld");

            var actual = sut.HasCustomAttribute<MockCustomAttributeAttribute>();

            actual.Should().BeTrue();
        }

        [Fact]
        public void HasCustomAttribute_ShouldReturnFalse_WhenTypeHasNoAttributeOfT()
        {
            var sut = typeof(MockUnattributedObject);

            var actual = sut.HasCustomAttribute<MockCustomAttributeAttribute>();

            actual.Should().BeFalse();
        }

        [Fact]
        public void HasCustomAttribute_ShouldReturnFalse_WhenAssemblyHasNoAttributeOfT()
        {
            var sut = typeof(CustomAttributeExtensions).Assembly;

            var actual = sut.HasCustomAttribute<MockCustomAttributeAttribute>();

            actual.Should().BeFalse();
        }

        [Fact]
        public void HasCustomAttribute_ShouldReturnFalse_WhenPropertyHasNoAttributeOfT()
        {
            var sut = typeof(MockUnattributedObject).GetProperty("Integer");

            var actual = sut.HasCustomAttribute<MockCustomAttributeAttribute>();

            actual.Should().BeFalse();
        }

        [Fact]
        public void HasCustomAttribute_ShouldReturnFalse_WhenFieldHasNoAttributeOfT()
        {
            var sut = typeof(MockUnattributedObject).GetField("HelloWorld");

            var actual = sut.HasCustomAttribute<MockCustomAttributeAttribute>();

            actual.Should().BeFalse();
        }

        #endregion

        #region TryGetCustomAttribute

        [Fact]
        public void TryGetCustomAttribute_ShouldReturnTrue_WhenTypeHasAttributeOfT()
        {
            var sut = typeof(MockAttributedObject);

            var actual = sut.TryGetCustomAttribute<MockCustomAttributeAttribute>(out var attribute);

            actual.Should().BeTrue();
            attribute.Should().BeOfType<MockCustomAttributeAttribute>();
        }

        [Fact]
        public void TryGetCustomAttribute_ShouldReturnTrue_WhenAssemblyHasAttributeOfT()
        {
            var sut = typeof(MockAttributedObject).Assembly;

            var actual = sut.TryGetCustomAttribute<MockCustomAttributeAttribute>(out var attribute);

            actual.Should().BeTrue();
            attribute.Should().BeOfType<MockCustomAttributeAttribute>();
        }

        [Fact]
        public void TryGetCustomAttribute_ShouldReturnTrue_WhenPropertyHasAttributeOfT()
        {
            var sut = typeof(MockAttributedObject).GetProperty("Integer");

            var actual = sut.TryGetCustomAttribute<MockCustomAttributeAttribute>(out var attribute);

            actual.Should().BeTrue();
            attribute.Should().BeOfType<MockCustomAttributeAttribute>();
        }

        [Fact]
        public void TryGetCustomAttribute_ShouldReturnTrue_WhenFieldHasAttributeOfT()
        {
            var sut = typeof(MockAttributedObject).GetField("HelloWorld");

            var actual = sut.TryGetCustomAttribute<MockCustomAttributeAttribute>(out var attribute);

            actual.Should().BeTrue();
            attribute.Should().BeOfType<MockCustomAttributeAttribute>();
        }

        [Fact]
        public void TryGetCustomAttribute_ShouldReturnFalse_WhenTypeHasNoAttributeOfT()
        {
            var sut = typeof(MockUnattributedObject);

            var actual = sut.TryGetCustomAttribute<MockCustomAttributeAttribute>(out var attribute);

            actual.Should().BeFalse();
            attribute.Should().BeNull();
        }

        [Fact]
        public void TryGetCustomAttribute_ShouldReturnFalse_WhenAssemblyHasNoAttributeOfT()
        {
            var sut = typeof(CustomAttributeExtensions).Assembly;

            var actual = sut.TryGetCustomAttribute<MockCustomAttributeAttribute>(out var attribute);

            actual.Should().BeFalse();
            attribute.Should().BeNull();
        }

        [Fact]
        public void TryGetCustomAttribute_ShouldReturnFalse_WhenPropertyHasNoAttributeOfT()
        {
            var sut = typeof(MockUnattributedObject).GetProperty("Integer");

            var actual = sut.TryGetCustomAttribute<MockCustomAttributeAttribute>(out var attribute);

            actual.Should().BeFalse();
            attribute.Should().BeNull();
        }

        [Fact]
        public void TryGetCustomAttribute_ShouldReturnFalse_WhenFieldHasNoAttributeOfT()
        {
            var sut = typeof(MockUnattributedObject).GetField("HelloWorld");

            var actual = sut.TryGetCustomAttribute<MockCustomAttributeAttribute>(out var attribute);

            actual.Should().BeFalse();
            attribute.Should().BeNull();
        }

        #endregion

        #region GetDerivedTypesFromAssembly

        [Fact]
        public void GetDerivedTypesFromAssembly_ShouldReturnPopulatedList_WhenAssemblyContainsTypesWithAttributeOfT()
        {
            var attribute = new MockCustomAttributeAttribute();

            var expected = typeof(MockAttributedObject);
            var assembly = expected.Assembly;

            var actual = attribute.GetDerivedTypesFromAssembly(assembly);

            actual.Should().ContainEquivalentOf((expected, attribute));
        }

        [Fact]
        public void GetDerivedTypesFromAssembly_ShouldReturnEmptyList_WhenAssemblyContainsNoTypesWithAttributeOfT()
        {
            var attribute = new MockCustomAttributeAttribute();

            var type = typeof(CustomAttributeExtensions);
            var assembly = type.Assembly;

            var actual = attribute.GetDerivedTypesFromAssembly(assembly);

            actual.Should().BeEmpty();
        }

        #endregion

        #region GetTypesWithAttribute

        [Fact]
        public void GetTypesWithAttribute_ShouldReturnPopulatedList_WhenAssemblyContainsTypesWithAttributeOfT()
        {
            var attribute = new MockCustomAttributeAttribute();
            var expected = typeof(MockAttributedObject);
            var assembly = expected.Assembly;

            var actual = assembly.GetTypesWithAttribute<MockCustomAttributeAttribute>();

            actual.Should().ContainEquivalentOf((expected, attribute));
        }

        [Fact]
        public void GetTypesWithAttribute_ShouldReturnEmptyList_WhenAssemblyContainsNoTypesWithAttributeOfT()
        {
            var type = typeof(CustomAttributeExtensions);
            var assembly = type.Assembly;

            var actual = assembly.GetTypesWithAttribute<MockCustomAttributeAttribute>();

            actual.Should().BeEmpty();
        }

        #endregion
    }
}