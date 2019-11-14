using System;

namespace CSharpHacks
{
    public static class ByteArrayHacks
    {
        public static string ToHex(this byte[] bytes)
        {
            return ToHex(bytes, 0, bytes.Length);
        }

        public static string ToHex(this byte[] bytes, string delimiter)
        {
            return ToHex(bytes, 0, bytes.Length, delimiter);
        }

        public static string ToHex(this byte[] bytes, int startindex)
        {
            return ToHex(bytes, startindex, bytes.Length - startindex);
        }

        public static string ToHex(this byte[] bytes, int startindex, string delimiter)
        {
            return ToHex(bytes, startindex, bytes.Length - startindex, delimiter);
        }

        public static string ToHex(this byte[] bytes, int startindex, int length)
        {
            return ToHex(bytes, startindex, length, "-");
        }

        public static string ToHex(this byte[] bytes, int startindex, int length, string delimiter)
        {
            if (string.IsNullOrEmpty(delimiter))
            {
                return BitConverter.ToString(bytes, startindex, length).Replace("-", delimiter);
            }
            else if (delimiter != "-")
            {
                return BitConverter.ToString(bytes, startindex, length).Replace("-", delimiter);
            }

            return BitConverter.ToString(bytes, startindex, length);
        }
    }
}
