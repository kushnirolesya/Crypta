using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cryptology.Caesar.Algorithm;

namespace Cryptology.UI
{
    public sealed class AnalyzingDetailsModel
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnalyzingDetailsModel(CaesarFrequencyAnalyzer analyzer)
        {
            this.TextLettersCount = analyzer.TextLettersFrequency.Select(kvp => new LetterCountModel { Letter = kvp.Key, Count = kvp.Value }).OrderByDescending(m => m.Count).ToList();
            this.CryptoLettersCount = analyzer.CryptoTextLettersFrequency.Select(kvp => new LetterCountModel { Letter = kvp.Key, Count = kvp.Value }).OrderByDescending(m => m.Count).ToList();
        }

        public List<LetterCountModel> TextLettersCount { get; set; }

        public List<LetterCountModel> CryptoLettersCount { get; set; }
    }
}
