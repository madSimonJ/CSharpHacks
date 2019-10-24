using System;

namespace CSharpHacks
{
    public static class ObjectHacks
    {
        public static T Also<T>(this T @this, Action<T> action)
        {
            action(@this);
            return @this;
        }
    }
}
