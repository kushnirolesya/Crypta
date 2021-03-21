namespace Cryptology.UI
{
    public sealed class LetterCountModel
    {
        public char Letter { get; set; }

        public uint Count { get; set; }

        public override string ToString()
        {
            return $"{this.Letter} - {this.Count}";
        }
    }
}
