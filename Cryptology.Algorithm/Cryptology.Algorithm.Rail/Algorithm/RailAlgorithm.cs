using System.Runtime.CompilerServices;
using Cryptology.Core.Algorithm;
using Cryptology.Rail.Decoder;
using Cryptology.Rail.Encoder;

namespace Cryptology.Rail.Algorithm
{
    public class RailAlgorithm : IAlgorithm
    {
        #region Constructors
        public RailAlgorithm(uint key, bool fromTop = false)
        {
            Key = key;
            FromTop = fromTop;
            Encoder = new RailEncoder(Key, FromTop);
            Decoder = new RailDecoder(Key, FromTop);
        }

        #endregion

        #region Properties
        public uint Key { get; }

        public bool FromTop { get; }

        public RailEncoder Encoder { get; private set; }

        public RailDecoder Decoder { get; private set; }
        #endregion

        #region IAlgorithm
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code) => Decoder.Decode(code);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Encode(string text) => Encoder.Encode(text);
        #endregion
    }
}
