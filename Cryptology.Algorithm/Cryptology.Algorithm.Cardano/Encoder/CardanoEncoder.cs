using System;
using System.Runtime.CompilerServices;
using System.Text;
using Cryptology.Core.Encoder;

namespace Cryptology.Cardano.Encoder
{
    public class CardanoEncoder : IEncoder
    {
        #region Private fields
        private const string symbols = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
        private char[,] grill;
        private Random random;
        private readonly int N;
        private const char holeFlag = '1';
        #endregion

        #region Constructors
        public CardanoEncoder(int n, char[,] grill)
        {
            N = n;
            this.grill = grill;
            random = new Random();
        }
        #endregion

        #region Properties

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Encode(string text)
        {
            var res = new StringBuilder();
            var ind = 0;
            var matrixForEncode = new char[N, N];

            while (ind < text.Length)
            {
                EncodeMatrix(matrixForEncode, text, ref ind);

                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (matrixForEncode[i, j] == char.MinValue)
                        {
                            matrixForEncode[i, j] = RandomChar(symbols);
                        }
                        res.Append(matrixForEncode[i, j]);
                        matrixForEncode[i, j] = char.MinValue;
                    }
                }

            }

            return res.ToString();
        }

        private void EncodeMatrix(char[,] matrix, string text, ref int index)
        {
            for (var k = 0; k < 4; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (grill[i, j] == holeFlag)
                        {
                            if (index < text.Length)
                            {
                                matrix[i, j] = text[index++];
                            }
                            else
                            {
                                matrix[i, j] = RandomChar(symbols);
                            }
                        }
                    }
                }
                grill = RotateMatrixByClockwise(grill);
            }
            grill = RotateMatrixByClockwise(grill);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private char RandomChar(string text) => text[random.Next(text.Length)];
    }
}
