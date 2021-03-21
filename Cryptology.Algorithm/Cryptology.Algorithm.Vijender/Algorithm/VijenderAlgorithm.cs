using System.Runtime.CompilerServices;
using Cryptology.Core.Algorithm;
using Cryptology.Vijender.Decoder;
using Cryptology.Vijender.Encoder;

namespace Cryptology.Vijender.Algorithm
{
    public class VijenderAlgorithm : IAlgorithm
    {
        #region Private fields
        #endregion

        #region Constructors
        public VijenderAlgorithm(string key)
        {
            Key = key.ToLower();
            Encoder = new VijenderEncoder(Key);
            Decoder = new VijenderDecoder(Key);
        }


        #endregion

        #region Properties
        public string Key { get; }

        public VijenderEncoder Encoder { get; private set; }

        public VijenderDecoder Decoder { get; private set; }
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
