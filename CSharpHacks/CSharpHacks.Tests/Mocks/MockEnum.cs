using System.ComponentModel;

namespace CSharpHacks.Tests.Mocks
{
    public enum MockEnum
    {
        [Description("First Value")]
        First,

        [Description("Second Value")]
        Second,

        [Description("Third Value")]
        Third,

        Fourth
    }
}