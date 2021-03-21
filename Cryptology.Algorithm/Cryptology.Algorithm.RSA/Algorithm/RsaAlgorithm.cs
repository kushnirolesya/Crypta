using System.Runtime.CompilerServices;
using Cryptology.Core.Algorithm;
using Cryptology.Rsa.Decoder;
using Cryptology.Rsa.Encoder;

namespace Cryptology.Rsa.Algorithm
{
    public class RsaAlgorithm : IAlgorithm
    {
        #region Private fields
        private RsaDecoder Decoder;
        private RsaEncoder Encoder;
        #endregion

        #region Constructors
        public RsaAlgorithm()
        {
            Decoder = new RsaDecoder();
            Encoder = new RsaEncoder();
        }
        #endregion

        #region Properties

        #endregion

        #region IAlgorithm
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code) => Decoder.Decode(code);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Encode(string text) => Encoder.Encode(text);
        #endregion

        #region Overrides
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
