using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UsefulStuff
{
    /// <summary>
    /// Safe string conversions
    /// </summary>
    public static class StringConversionExtensions
    {
        private static readonly char[] EndOfLineChars = { '\r', '\n' };

        public static int ToInt(this string value, int dflt = 0) 
            => Int32.TryParse(value, out var result) ? result : dflt;

        public static float ToFloat(this string value, float dflt = 0f) 
            => Single.TryParse(value, out var result) ? result : dflt;

        public static double ToDouble(this string value, double dflt = 0d) 
            => Double.TryParse(value, out var result) ? result : dflt;

        public static decimal ToDecimal(this string value, decimal dflt = 0m) 
            => Decimal.TryParse(value, out var result) ? result : dflt;

        public static bool ToBool(this string value, bool dflt = false)
        {
            if (value.Length == 0) return false;

            var c1 = value.ToLower()[0];
            return new[] { 'y', 't', '1' }.Any(c => c == c1);
        }
        public static DateTime? ToDateTime(this string value, DateTime? dflt = null) 
            => DateTime.TryParse(value, out var result) 
            ? result 
            : dflt ?? DateTime.MinValue;

        public static Guid ToGuid(this string value, Guid? dflt = null) 
            => Guid.TryParse(value, out var result)
            ? result
            : dflt ?? Guid.Empty;

        public static Stream ToStream(this string value)
        {
            var stream = new MemoryStream();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(value);
                writer.Flush();
                stream.Position = 0;
            }
            return stream;
        }

        public static StreamReader ToStreamReader(this string source) 
            => new StreamReader(source.ToStream());

        public static byte[] ToBytes(this string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }


        /// <summary>
        /// Return default value if index out of bounds
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T DefaultingIndex<T>(this T[] value, int index, T defaultValue = default(T)) =>
            index + 1 > value.Length 
                ? defaultValue 
                : value[index];

        /// <summary>
        /// Searchs for the default static TryParse(string, out T) that exists on many .NET types to
        /// dynamically convert a string to any type.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ToTypeInstance(this string value, Type type)
        {
            if (type == typeof(string)) return value;

            var tryParseParamsFilter = new[]{ typeof(string), type.MakeByRefType() };
            var tryParseMethod = type.GetMethod("TryParse", tryParseParamsFilter);

            if (tryParseMethod == null)
            {
                throw new SystemException($"No static TryParse(string, out {type.Name}) found on {type.Name}");
            }
            var parameters = new object[] {value, null};
            var result = (bool) tryParseMethod.Invoke(null, parameters);

            if (result)
            {
                return parameters[1];
            }

            throw new SystemException($"Attempt to parse '{value}' using {type}.TryParse() failed");
        }
    }
}
