using System.Text;
using Cryptology.Core.Encoder;

namespace Cryptology.Rail.Encoder
{
    public class RailEncoder : IEncoder
    {
        private const char flag = '\0';
        #region Constructors
        public RailEncoder(uint key, bool fromTop = false)
        {
            Key = key;
            FromTop = fromTop;
        }

        #endregion

        #region Properties

        public uint Key { get; }

        public bool FromTop { get; private set; }

        #endregion

        #region IEncoder

        public string Encode(string text)
        {
            var code = new StringBuilder();
            var matrix = new char[(int)Key, text.Length];
            var i = 0;

            FromTop = false;

            for (var j = 0; j < text.Length; j++)
            {
                matrix[i, j] = text[j];

                i += FromTop ? -1 : 1;

                if (i + 1 == Key || i == 0)
                {
                    FromTop ^= true;
                }
            }

            for (var k = (int)Key - 1; k >= 0; k--)
            {
                for (var m = 0; m < text.Length; m++)
                {
                    if (matrix[k, m] != flag)
                    {
                        code.Append(matrix[k, m]);
                    }
                }
            }

            return code.ToString();
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
