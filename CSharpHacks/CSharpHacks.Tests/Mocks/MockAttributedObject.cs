namespace CSharpHacks.Tests.Mocks
{
    [MockCustomAttribute]
    public class MockAttributedObject : IMockInterface
    {
        [MockCustomAttribute]
        public MockAttributedObject()
        {
            Integer = 69;
        }

        [MockCustomAttribute]
        public int Integer { get; set; }

        [MockCustomAttribute]
        public string HelloWorld = "Hello World!";
    }
}