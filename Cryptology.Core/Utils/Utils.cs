using System.Collections.Generic;

namespace Cryptology.Core.Utils
{
    public class Utils
    {
        #region Constructor
        static Utils()
        {
            LetterNumbers = new Dictionary<char, uint>();
            for (uint i = 'a', j = 0; i <= 'z'; i++, j++)
            {
                LetterNumbers[(char)i] = j;
            }
        }
        #endregion

        public static Checker Check => new Checker();

        public static Dictionary<char, uint> LetterNumbers;
    }
}
