namespace CSharpHacks.Tests.Mocks
{
    public class OpenGenericDerivedTestClassOfString : OpenGenericTestBaseClassOfT<string>
    {
        public string Value { get; set; } = "Test Value";
    }
}