using System.Collections.Generic;
using Criptology.Afine.Model;
using Cryptology.Core.Extensions;

namespace Criptology.Afine.Algorithm
{
    public class AffineBruteForce
    {
        #region Constructors
        public AffineBruteForce()
        {
        }

        public AffineBruteForce(string code) : this()
        {
            Code = code;
        }

        #endregion

        #region Properties
        public string Code { get; }
        #endregion

        public virtual List<BruteForceResult> TryBrute(string code = null)
        {
            var result = new List<BruteForceResult>();
            for (var i = 1u; i <= 26; i++)
            {
                if (i % 2 != 0 && (i != 13))
                {
                    for (var j = 1u; j <= 26; j++)
                    {
                        result.Add(Brute(i, j, code));
                    }
                }
            }
            return result;
        }

        #region Overrides
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        protected virtual BruteForceResult Brute(uint a, uint b, string code = null)
        {
            return new BruteForceResult
            {
                Alpha = a,
                Betta = b,
                Code = code ?? Code,
                Text = new AffineAlgorithm(a, b).Decode((code ?? Code))
            };
        }
    }
}
