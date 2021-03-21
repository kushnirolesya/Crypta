using System;
using System.Runtime.CompilerServices;

namespace Cryptology.Core.Utils
{
    public static class ExeptionHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowIf(bool condition, string message = null)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
    }
}
