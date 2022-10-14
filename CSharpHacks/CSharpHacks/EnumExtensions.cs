using System.ComponentModel;

namespace CSharpHacks
{
    public static class EnumExtensions
    {
        /// <summary>
        ///     Gets the description for the enum member, decorated with a <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A string representation of the description of the enum member, decorated with a DescriptionAttribute.</returns>
        public static string GetDescription(this System.Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
