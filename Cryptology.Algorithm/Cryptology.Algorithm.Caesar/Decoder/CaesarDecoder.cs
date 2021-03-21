using System.Runtime.CompilerServices;
using System.Text;
using Cryptology.Core.Decoder;
using Cryptology.Core.Extensions;

namespace Cryptology.Caesar.Decoder
{
    public class CaesarDecoder : IDecoder
    {
        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CaesarDecoder()
        {
            Shift = default;
            Encoding = Encoding.UTF8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CaesarDecoder(int shift, Encoding encoding)
        {
            Shift = shift;
            Encoding = encoding;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CaesarDecoder(int shift) : this(shift, Encoding.UTF8)
        {
        }
        #endregion

        #region Properties
        public int Shift { get; set; }

        public Encoding Encoding { get; set; }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code)
        {
            var sb = new StringBuilder();
            foreach (var letter in code)
            {
                if (char.IsLetter(letter))
                {
                    sb.Append(letter.Shift(-Shift));
                }
                else
                {
                    sb.Append(letter);
                }
            }
            return sb.ToString();
        }
    }
}
