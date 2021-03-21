using System.Runtime.CompilerServices;
using System.Text;
using Cryptology.Caesar.Algorithm;
using Cryptology.Core.Decoder;
using Cryptology.Core.Utils;

namespace Cryptology.Vijender.Decoder
{
    public class VijenderDecoder : IDecoder
    {
        #region Private fields

        private CaesarAlgorithm CaesarAlgorithm;

        #endregion

        #region Constructors
        public VijenderDecoder(string key)
        {
            Key = key;
            CaesarAlgorithm = new CaesarAlgorithm();
        }

        #endregion

        #region Properties

        public string Key { get; }

        #endregion

        #region IDecoder

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code)
        {
            var text = new StringBuilder();

            var j = 0;
            foreach (var letter in code)
            {
                CaesarAlgorithm.Shift = (int)Utils.LetterNumbers[Key[j++]];
                var encodedLetter = CaesarAlgorithm.Decode(letter.ToString());
                text.Append(encodedLetter);
                if (j >= Key.Length)
                {
                    j = 0;
                }
            }

            return text.ToString();
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
