using System.Linq;
using CSharpHacks.Reflection;
using CSharpHacks.Tests.Mocks;
using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class AssemblyExtensionsTests
    {
        [Fact]
        public void GetAllTypesImplementingOpenGenericType_ShouldPopulateCorrectly_WhenPassedOpenGenericInterface()
        {
            var assembly = GetType().Assembly;

            var actual = assembly
                .GetAllTypesImplementingOpenGenericType(typeof(IOpenGeneric<>))
                .ToList();

            actual.Should().HaveCount(4);
            actual.Should().Contain(typeof(OpenGenericTestClassOfInt));
            actual.Should().Contain(typeof(OpenGenericTestBaseClassOfT<>));
            actual.Should().Contain(typeof(OpenGenericDerivedTestClassOfString));
            actual.Should().Contain(typeof(OpenGenericDerivedTestClassOfBool));
        }

        [Fact]
        public void GetAllTypesImplementingOpenGenericType_ShouldPopulateCorrectly_WhenPassedOpenGenericBaseClass()
        {
            var assembly = GetType().Assembly;

            var actual = assembly
                .GetAllTypesImplementingOpenGenericType(typeof(OpenGenericTestBaseClassOfT<>))
                .ToList();

            actual.Should().HaveCount(2);
            actual.Should().Contain(typeof(OpenGenericDerivedTestClassOfString));
            actual.Should().Contain(typeof(OpenGenericDerivedTestClassOfBool));
        }

        [Fact]
        public void InstantiateAllTypes_ShouldReturnPopulatedListOfConstructedObjects_WhenAssemblyContainsMatchingTypes()
        {
            var assembly = GetType().Assembly;

            var actual = assembly.InstantiateAllTypes<OpenGenericTestBaseClassOfT<string>>().ToList();

            actual.Should().HaveCount(1);
            actual.Should().AllBeAssignableTo<OpenGenericTestBaseClassOfT<string>>();
            actual[0].Should().BeOfType<OpenGenericDerivedTestClassOfString>();
            actual[0].As<OpenGenericDerivedTestClassOfString>().Value.Should().Be("Test Value");
        }

        [Fact]
        public void InstantiateAllTypes_ShouldReturnPopulatedListOfConstructedObjects_WhenAssemblyContainsNoMatchingTypes()
        {
            var assembly = GetType().Assembly;

            var actual = assembly.InstantiateAllTypes<OpenGenericTestBaseClassOfT<int>>().ToList();

            actual.Should().BeEmpty();
        }
    }
}
