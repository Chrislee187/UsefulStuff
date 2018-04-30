using System.Linq;

namespace UsefulStuff
{
    public static class StringExtensions
    {
        public static string Repeat(this char s, int times)
            => new string(s, times);

        public static string Repeat(this string s, int times)
            => Enumerable.Range(1, times).Aggregate("", (a, i) => a + s);

        private static readonly char[] QuoteChars = "'\"".ToCharArray();

        public static string Dequote(this string source)
        {
            if (QuoteChars.Contains(source.First())
                && QuoteChars.Contains(source.Last()))
            {
                return source.Substring(1, source.Length - 2);
            }

            return source;
        }

        public static string Wrap(this string source, string prefix = "'", string postfix = "'")
        {
            if (QuoteChars.Contains(source.First())
                && QuoteChars.Contains(source.Last()))
            {
                return source.Substring(1, source.Length - 2);
            }

            return source;

        }
    }
}