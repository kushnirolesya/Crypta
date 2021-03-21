using System.Runtime.CompilerServices;
using System.Text;
using Cryptology.Core.Decoder;

namespace Cryptology.Rail.Decoder
{
    public class RailDecoder : IDecoder
    {
        private const char flag = '1';
        #region Constructors
        public RailDecoder(uint key, bool fromTop = false)
        {
            Key = key;
            FromTop = fromTop;
        }

        #endregion

        #region Properties

        public uint Key { get; }

        public bool FromTop { get; private set; }

        #endregion

        #region IDecoder

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code)
        {
            var text = new StringBuilder();
            var matrix = new char[Key, code.Length];
            var i = 0;

            for (var j = 0; j < code.Length; j++)
            {
                matrix[i, j] = flag;
                i += FromTop ? -1 : 1;
                if (i + 1 == Key || i == 0)
                {
                    FromTop ^= true;
                }
            }

            var ind = 0;
            for (var k = (int)Key - 1; k >= 0; k--)
            {
                for (var m = 0; m < code.Length; m++)
                {
                    if (matrix[k, m] == flag)
                    {
                        matrix[k, m] = code[ind++];
                    }
                }
            }

            i = 0;
            FromTop = false;
            for (var j = 0; j < code.Length; j++)
            {
                matrix[i, j] = flag;
                i += FromTop ? -1 : 1;

                if (i + 1 == Key || i == 0)
                {
                    FromTop ^= true;
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
