using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using CSharpHacks.Enum;

// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable StringLiteralTypo
// ReSharper disable MemberCanBePrivate.Global

namespace CSharpHacks
{
    /// <summary>
    ///     Extension Methods for when working with Colours.
    /// </summary>
    public static class ColourExtensions
    {
        /// <summary>
        ///     Updates a single colour channel within a <see cref="Color"/>.
        /// </summary>
        /// <param name="colour">The colour to change the channel of.</param>
        /// <param name="channel">The channel to change the value of.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>A new instance of <see cref="Color"/>, with the updated values.</returns>
        public static Color UpdateColourChannel(this Color colour, ColourChannel channel, byte value)
        {
            return channel switch
            {
                ColourChannel.A => Color.FromArgb(value, colour.R, colour.G, colour.B),
                ColourChannel.R => Color.FromArgb(colour.A, value, colour.G, colour.B),
                ColourChannel.G => Color.FromArgb(colour.A, colour.R, value, colour.B),
                ColourChannel.B => Color.FromArgb(colour.A, colour.R, colour.G, value),
                _ => throw new ArgumentOutOfRangeException(nameof(channel), channel, null)
            };
        }

        /// <summary>
        ///      Converts a <see cref="Color"/> to an array of doubles, in RGBA order.
        /// </summary>
        /// <param name="colour">The colour to convert.</param>
        /// <returns>A double array, with values set in RGBA order.</returns>
        public static IEnumerable<double> ToRgbaDoubleArray(this Color colour)
        {
            return new double[]
            {
                colour.R,
                colour.G,
                colour.B,
                colour.A
            };
        }

        /// <summary>
        ///      Converts a <see cref="Color"/> to an array of doubles, in ARGB order.
        /// </summary>
        /// <param name="colour">The colour to convert.</param>
        /// <returns>A double array, with values set in ARGB order.</returns>
        public static IEnumerable<double> ToArgbDoubleArray(this Color colour)
        {
            return new double[]
            {
                colour.A,
                colour.R,
                colour.G,
                colour.B
            };
        }

        /// <summary>
        ///     Normalises the specified colour. That being, it converts each channel value into a <see cref="double"/>, between 0.0 and 1.0, by dividing each value by 255.0.
        /// </summary>
        /// <param name="colour">The colour to normalise.</param>
        /// <returns>A double array, with normalised values set in RGBA order.</returns>
        public static IEnumerable<double> ToNormalisedRgba(this Color colour)
        {
            return new[]
            {
                colour.R / 255d,
                colour.G / 255d,
                colour.B / 255d,
                colour.A / 255d
            };
        }

        /// <summary>
        ///     Normalises the specified colour. That being, it converts each channel value into a <see cref="double"/>, between 0.0 and 1.0, by dividing each value by 255.0.
        /// </summary>
        /// <param name="colour">The colour to normalise.</param>
        /// <returns>A double array, with normalised values set in ARGB order.</returns>
        public static IEnumerable<double> ToNormalisedArgb(this Color colour)
        {
            return new[]
            {
                colour.A / 255d,
                colour.R / 255d,
                colour.G / 255d,
                colour.B / 255d
            };
        }

        /// <summary>
        ///     Normalises the specified colour. That being, it converts each channel value into a <see cref="double"/>, between 0.0 and 1.0, by dividing each value by 255.0.
        /// </summary>
        /// <param name="colour">The colour to normalise.</param>
        /// <returns>A double array, with normalised values set in RGBA order.</returns>
        public static IEnumerable<double> ToNormalisedRgba(this IEnumerable<double> colour)
        {
            var c = colour.ToArray();
            return new[]
            {
                c[0] / 255d,
                c[1] / 255d,
                c[2] / 255d,
                c[3] / 255d
            };
        }

        /// <summary>
        ///     Normalises the specified colour. That being, it converts each channel value into a <see cref="double"/>, between 0.0 and 1.0, by dividing each value by 255.0.
        /// </summary>
        /// <param name="colour">The colour to normalise.</param>
        /// <returns>A double array, with normalised values set in ARGB order.</returns>
        public static IEnumerable<double> ToNormalisedArgb(this IEnumerable<double> colour)
        {
            var c = colour.ToArray();
            return new[]
            {
                c[0] / 255d,
                c[1] / 255d,
                c[2] / 255d,
                c[3] / 255d
            };
        }

        /// <summary>
        ///     Converts a <see cref="Color"/> to an RGB Hexadecimal string.
        /// </summary>
        /// <param name="c">The colour to convert.</param>
        /// <returns>A hex string, in the format #RRGGBB.</returns>
        public static string ToRgbHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        /// <summary>
        ///     Converts a <see cref="Color"/> to an ARGB Hexadecimal string.
        /// </summary>
        /// <param name="c">The colour to convert.</param>
        /// <returns>A hex string, in the format #AARRGGBB.</returns>
        public static string ToArgbHexString(this Color c) => $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}";

        /// <summary>
        ///     Converts a <see cref="Color"/> to an RGBA Hexadecimal string.
        /// </summary>
        /// <param name="c">The colour to convert.</param>
        /// <returns>A hex string, in the format #RRGGBBAA.</returns>
        public static string ToRgbaHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}{c.A:X2}";

        /// <summary>
        ///     Converts a <see cref="Color"/> to an RGB() string.
        /// </summary>
        /// <param name="c">The colour to convert.</param>
        /// <returns>A string, in the format RGB(0-255, 0-255, 0-255).</returns>
        public static string ToRgbString(this Color c) => $"RGB({c.R}, {c.G}, {c.B})";
    }
}