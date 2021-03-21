using System;
using System.Runtime.CompilerServices;
using Cryptology.Cardano.Decoder;
using Cryptology.Cardano.Encoder;
using Cryptology.Core.Algorithm;

namespace Cryptology.Cardano
{
    public class CardanoAlgorithm : IAlgorithm
    {
        private const char zero = '0';
        private const int N = 4;

        private char[,] grill;
        private CardanoDecoder Decoder;
        private CardanoEncoder Encoder;

        public CardanoAlgorithm(string holesPattern)
        {
            grill = InitGrill(holesPattern);
            Decoder = new CardanoDecoder(N, grill);
            Encoder = new CardanoEncoder(N, grill);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Encode(string text) => Encoder.Encode(text);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Decode(string code) => Decoder.Decode(code);

        private char[,] InitGrill(string pattern)
        {
            grill = new char[N, N];
            for (var i = 0; i < N; i++)
            {
                var number = Convert.ToString(Convert.ToInt32(pattern[i].ToString()), 2).PadLeft(4, zero).ToCharArray();
                for (var j = 0; j < N; j++)
                {
                    grill[i, j] = number[j];
                }
            }

            return grill;
        }
    }
}
