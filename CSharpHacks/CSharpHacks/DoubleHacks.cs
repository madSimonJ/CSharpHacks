namespace CSharpHacks
{
    public static class DoubleHacks
    {
        public static bool IsZero(this double @this) =>
            @this.IsCloseTo(0, 0.0000001);

        public static bool IsCloseTo(this double @this, double value, double tolerance) =>
            (@this - value) <= tolerance;
    }
}
