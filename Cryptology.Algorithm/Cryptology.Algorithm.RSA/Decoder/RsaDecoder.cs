using System.Runtime.CompilerServices;
using Cryptology.Core.Decoder;

namespace Cryptology.Rsa.Decoder
{
    public class RsaDecoder : IDecoder
    {
        #region Constructors
        public RsaDecoder()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region IDecoder
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
