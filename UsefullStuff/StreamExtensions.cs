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
        public static byte[] ToArray(this Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }
    }

}