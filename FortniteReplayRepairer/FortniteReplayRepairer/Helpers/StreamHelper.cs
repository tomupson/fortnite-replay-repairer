using System.IO;
using System.Threading.Tasks;

namespace FortniteReplayRepairer.Helpers
{
    public static class StreamHelper
    {
        public static async Task<byte[]> ReadBytesAsync(string path, int offset, int count)
        {
            byte[] outputBytes = new byte[count];
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                stream.Seek(offset, SeekOrigin.Begin);
                await stream.ReadAsync(outputBytes, 0, count);
            }

            return outputBytes;
        }

        public static async Task WriteBytesAsync(string path, byte[] buffer, int offset)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                stream.Seek(offset, SeekOrigin.Begin);
                await stream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}