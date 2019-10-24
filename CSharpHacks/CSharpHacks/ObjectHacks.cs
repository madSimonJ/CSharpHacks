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

        public static K Let<T, K>(this T @this, Func<T, K> func)
        {
            return func(@this);
        }
    }
}
