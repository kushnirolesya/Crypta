using System.Runtime.CompilerServices;
using Cryptology.Core.Encoder;

namespace Cryptology.Rsa.Encoder
{
    public class RsaEncoder : IEncoder
    {
        #region Constructors
        public RsaEncoder()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region IEncoder
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Encode(string text)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
