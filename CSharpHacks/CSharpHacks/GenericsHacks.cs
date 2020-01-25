using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpHacks
{
    public static class GenericsHacks
    {
        public static bool LimitTypeOfGeneric<T>(Type data)
        {
            return data == typeof(ObjectOne) || data == typeof(ObjectTwo);
        }


        public class ObjectOne
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class ObjectTwo
        {
            public int Id { get; set; }
            public int Age { get; set; }
        }
    }
}
