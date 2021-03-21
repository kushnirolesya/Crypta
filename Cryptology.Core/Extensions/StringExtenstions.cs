using System.Runtime.CompilerServices;
using System.Text;

namespace Cryptology.Core.Extensions
{
    public static class StringExtenstions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this string str)
        {
            return str.ToBytes(Encoding.UTF8);
        }
    }
}
