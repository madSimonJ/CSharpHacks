namespace CSharpHacks.Tests.Mocks
{
    public class MockUnattributedObject : IMockInterface
    {
        public MockUnattributedObject()
        {
            Integer = 69;
        }
        
        public int Integer { get; set; }
        
        public string HelloWorld = "Hello World!";
    }
}