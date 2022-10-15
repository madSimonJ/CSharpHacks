using System.ComponentModel;

namespace CSharpHacks.Enum
{
    /// <summary>
    ///     Specifies a single colour channel within an ARGB colour.
    /// </summary>
    public enum ColourChannel
    {
        /// <summary>
        ///     The Alpha channel.
        /// </summary>
        [Description("Alpha")] A,

        /// <summary>
        ///     The Red channel.
        /// </summary>
        [Description("Red")] R,

        /// <summary>
        ///     The Green channel.
        /// </summary>
        [Description("Green")] G,

        /// <summary>
        ///     The Blue channel.
        /// </summary>
        [Description("Blue")] B
    }
}