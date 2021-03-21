using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Cryptology.Core.Encoder;
using Cryptology.Core.Utils;

namespace Criptology.Affine.Encoder
{
    public class AffineEncoder : IEncoder
    {
        #region Constructors
        public AffineEncoder(uint alpha, uint betta)
        {
            Alpha = alpha;
            Betta = betta;
            M = (uint)Utils.LetterNumbers.Count;
        }


        #endregion

        #region Properties
        public uint Alpha { get; }

        public uint Betta { get; }

        public uint M { get; }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Encode(string str)
        {
            var encodedData = new StringBuilder();
            char encryptedLetter;
            uint charCode;
            foreach (var c in str)
            {
                if (char.IsLetter(c))
                {
                    var lc = char.ToLower(c);
                    charCode = Utils.LetterNumbers[lc];
                    encryptedLetter = Utils.LetterNumbers.First(x => x.Value == E(charCode)).Key;
                    encodedData.Append(encryptedLetter.ToString());
                }
                else
                {
                    encodedData.Append(c);
                }
            }
            return encodedData.ToString();
        }

        #region Overrides
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #region Private Methods
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint E(uint x)
        {
            return ((Alpha * x) + Betta) % M;
        }
        #endregion
    }
}
