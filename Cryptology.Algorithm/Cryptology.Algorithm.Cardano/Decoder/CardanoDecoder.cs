using System.Text;
using Cryptology.Core.Decoder;

namespace Cryptology.Cardano.Decoder
{
    public class CardanoDecoder : IDecoder
    {
        #region Private fields
        private readonly int N;
        private const char holeFlag = '1';

        private char[,] grill;

        #endregion
        #region Constructors
        public CardanoDecoder(int n, char[,] grill)
        {
            N = n;
            this.grill = grill;
        }
        #endregion

        #region IDecoder
        public string Decode(string code)
        {
            var matrixForDecripting = new char[N, N];
            var res = new StringBuilder();

            for (var index = 0; index < code.Length; index++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        matrixForDecripting[i, j] = code[index++];
                    }
                }

                res = DecodeMatrix(matrixForDecripting, res);
            }

            return res.ToString();
        }
        #endregion

        #region Helper Methods
        private StringBuilder DecodeMatrix(char[,] matrix, StringBuilder text)
        {
            for (var k = 0; k < 4; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (grill[i, j] == holeFlag)
                        {
                            text.Append(matrix[i, j]);
                        }
                    }
                }
                grill = RotateMatrixByClockwise(grill);
            }
            grill = RotateMatrixByClockwise(grill);
            return text;
        }

        private char[,] RotateMatrixByClockwise(char[,] matrix)
        {
            var result = new char[N, N];
            for (var i = 0; i < N / 2; i++)
            {
                for (var j = i; j < N - i - 1; j++)
                {
                    var temp = matrix[i, j];
                    result[i, j] = matrix[N - 1 - j, i];
                    result[N - 1 - j, i] = matrix[N - 1 - i, N - 1 - j];
                    result[N - 1 - i, N - 1 - j] = matrix[j, N - 1 - i];
                    result[j, N - 1 - i] = temp;
                }
            }

            return result;
        }
        #endregion
    }
}
