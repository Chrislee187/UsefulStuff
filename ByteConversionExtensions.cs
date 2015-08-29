using System;
using System.Linq;
using System.Text;

namespace UsefulStuff
{
    public static class ByteConversionExtensions
    {
        public static string ToBlockCopyString(this byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        public static string ToCharCastString(this byte[] bytes)
        {
            return new string(bytes.Select(b => (char)b).ToArray());
        }

        public static string ToHex(this byte[] bytes)
        {
            return string.Join(" ", bytes.Select(b => b.ToString("X2")));
        }

        public static string ToUtf8String(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}