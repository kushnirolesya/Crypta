using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Cryptology.Core.Decoder;
using Cryptology.Core.Utils;

namespace Criptology.Affine.Decoder
{
    public class AffineDecoder : IDecoder
    {
        #region Constructors
        public AffineDecoder(uint alpha, uint betta)
        {
            Alpha = alpha;
            Betta = betta;
            M = (uint)Utils.LetterNumbers.Count;
            Reverse = CalcualteReverseKey();
        }


        #endregion

        #region Properties
        public uint Alpha { get; }

        public uint Betta { get; }

        public uint M { get; }

        public uint Reverse { get; }
        #endregion

        #region IDecoder
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code)
        {
            var outData = new StringBuilder();
            char decryptedLetter;
            uint charCode;
            foreach (var c in code)
            {
                if (char.IsLetter(c))
                {
                    charCode = Utils.LetterNumbers[c];
                    decryptedLetter = Utils.LetterNumbers.First(x => x.Value == D(charCode)).Key;
                    outData.Append(decryptedLetter);
                }
                else
                {
                    outData.Append(c);
                }
            }
            return outData.ToString();
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #region Private Methods
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint D(uint y)
        {
            return Reverse * (y + M - Betta) % M;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint CalcualteReverseKey()
        {
            var reverseKey = 1u;
            while (reverseKey * Alpha % M != 1)
            {
                reverseKey++;
            }

            return reverseKey;
        }
        #endregion
    }
}
