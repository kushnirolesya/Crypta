using System;

namespace Cryptology.Core
{
    public class GlobalConstants
    {
        public static readonly string TextFilePath = $"{Environment.CurrentDirectory}/text.txt";

        public class Algorithms
        {
            public const string Affine = nameof(Affine);
            public const string Caesar = nameof(Caesar);
            public const string Cardano = nameof(Cardano);
            public const string Rail = nameof(Rail);
            public const string Rsa = nameof(Rsa);
            public const string Vijender = nameof(Vijender);
        }
    }
}
