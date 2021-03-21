using System.Runtime.CompilerServices;
using Criptology.Affine.Decoder;
using Criptology.Affine.Encoder;
using Cryptology.Core.Algorithm;
using Cryptology.Core.Utils;

namespace Criptology.Afine.Algorithm
{
    public class AffineAlgorithm : IAlgorithm
    {
        #region Constructors
        public AffineAlgorithm(uint alpha, uint betta)
        {
            ExeptionHelper.ThrowIf(alpha == 0, $"The parameter {nameof(alpha)} can't be equal to 0");
            ExeptionHelper.ThrowIf(betta == 0, $"The parameter {nameof(betta)} can't be equal to 0");

            M = (uint)Utils.LetterNumbers.Count;
            Alpha = alpha;
            Betta = betta;
            ExeptionHelper.ThrowIf(!AreMutuallyPrime(Alpha, M), $"The values must be mutually prime: alpha={alpha} and m={M}");
            Decoder = new AffineDecoder(Alpha, Betta);
            Encoder = new AffineEncoder(Alpha, Betta);
        }
        #endregion

        #region Properties
        public uint Alpha { get; private set; }

        public uint Betta { get; private set; }

        public uint M { get; private set; }

        public AffineDecoder Decoder { get; private set; }

        public AffineEncoder Encoder { get; private set; }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code) => Decoder.Decode(code);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Encode(string text) => Encoder.Encode(text);

        #region Overrides
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #region Private Methods
        

        #endregion

        #region Largest Common Divisor
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint LargestCommonDivisor(uint a, uint b)
        {
            uint t;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool AreMutuallyPrime(uint a, uint b)
        {
            return LargestCommonDivisor(a, b) == 1;
        }
        #endregion
    }
}
