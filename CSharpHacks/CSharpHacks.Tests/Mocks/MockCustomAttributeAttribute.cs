using System;
using CSharpHacks.Tests.Mocks;

[module: MockCustomAttribute]
[assembly: MockCustomAttribute]

namespace CSharpHacks.Tests.Mocks
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class MockCustomAttributeAttribute : Attribute { }
}
