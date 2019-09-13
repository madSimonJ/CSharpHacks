using System;

namespace CSharpHacks
{
    public static class CodeStructures
    {
        public static TOutput Map<TInput, TOutput>(this TInput @this, Func<TInput, TOutput> converter) =>
            converter(@this);

    } 
}
