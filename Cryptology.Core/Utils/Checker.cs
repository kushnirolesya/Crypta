using System.Runtime.CompilerServices;

namespace Cryptology.Core.Utils
{
    public class Checker
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ThrowIfNull<T>(T obj, string message = null)
        {
            if (obj is null)
            {
                throw new System.ArgumentNullException("obj", message);
            }
        }

    }
}
