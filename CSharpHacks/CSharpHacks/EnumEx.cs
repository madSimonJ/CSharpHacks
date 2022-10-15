namespace CSharpHacks
{
    public static class EnumEx
    {
        /// <summary>
        ///     Gets the number of values within this enum.
        /// </summary>
        /// <typeparam name="T">The type of enum to evaluate.</typeparam>
        /// <returns>The number of entries within this enumeration.</returns>
        public static int Count<T>() where T : System.Enum
        {
            return typeof(T).GetEnumNames().Length;
        }
    }
}