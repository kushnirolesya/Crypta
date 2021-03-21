using System.Runtime.CompilerServices;
using System.Text;
using Cryptology.Caesar.Decoder;
using Cryptology.Caesar.Encoder;
using Cryptology.Core.Algorithm;

namespace Cryptology.Caesar.Algorithm
{
    public class CaesarAlgorithm : IAlgorithm
    {
        #region Private firelds
        private readonly CaesarDecoder decoder;
        private readonly CaesarEncoder encoder;
        private Encoding encoding;
        private int shift; 
        #endregion

        #region Constructors
        public CaesarAlgorithm()
        {
            decoder = new CaesarDecoder();
            encoder = new CaesarEncoder();
            Shift = default;
            Encoding = Encoding.UTF8;
        }

        public CaesarAlgorithm(int shift, Encoding encoding)
        {
            decoder = new CaesarDecoder(shift, encoding);
            encoder = new CaesarEncoder(shift, encoding);
            Shift = shift;
            Encoding = encoding;
        }

        public CaesarAlgorithm(int shift) : this(shift, Encoding.UTF8)
        {
        }
        #endregion

        #region Properties
        public int Shift
        {
            get
            {
                return shift;
            }
            set
            {
                if (value != shift)
                {
                    shift = value;
                    decoder.Shift = value;
                    encoder.Shift = value;
                }
            }
        }

        public Encoding Encoding
        {
            get
            {
                return encoding;
            }

            set
            {
                if (encoding != value)
                {
                    encoding = value;
                    encoder.Encoding = value;
                    decoder.Encoding = value;
                }
            }
        }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code) => decoder.Decode(code);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Encode(string str) => encoder.Encode(str);
    }
}
