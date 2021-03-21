namespace Cryptology.Core.Extensions
{
    public static class CharExtensions
    {
        public static char Shift(this char letter, int shift)
        {
            shift %= 26;
            letter = char.ToLowerInvariant(letter);

            if (shift == 0)
            {
                return letter;
            }

            var result = letter + shift;
            if (result > 'z')
            {
                result -= 26;
                return (char)result;
            }

            if (result < 'a')
            {
                result += 26;
                return (char)result;
            }

            return (char)result;
        }
    }
}
