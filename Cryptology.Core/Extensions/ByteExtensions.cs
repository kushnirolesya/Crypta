using System.Runtime.CompilerServices;
using System.Text;

namespace Cryptology.Core.Extensions
{
    public static class ByteExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FromBytes(this byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FromBytes(this byte[] bytes)
        {
            return bytes.FromBytes(Encoding.UTF8);
        }
    }
}
