using System;
namespace CSharpHacks
{
    public static class IntHacks
    {
        public static int SpesificDigitOfNumber(this int @this, int index)
        {
            return @this / (int)Math.Pow(10, index) % 10;
        }
    }
}
