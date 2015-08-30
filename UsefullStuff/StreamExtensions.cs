using System.IO;

namespace UsefulStuff
{
    public static class StreamExtensions
    {
        public static byte PeekByte(this Stream stream)
        {
            if (stream.Position == -1) throw new EndOfStreamException();

            var @byte = stream.ReadByte();

            if (stream.Position == -1)
                stream.Position = stream.Length;
            else
            {
                stream.Position -= 1;
            }

            return (byte)@byte;
        }
    }
}