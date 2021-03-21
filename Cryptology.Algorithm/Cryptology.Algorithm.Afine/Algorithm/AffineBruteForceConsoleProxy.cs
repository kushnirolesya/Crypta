using System;
using System.Collections.Generic;
using Criptology.Afine.Model;

namespace Criptology.Afine.Algorithm
{
    public class AffineBruteForceConsoleProxy : AffineBruteForce
    {
        public AffineBruteForceConsoleProxy()
        {
        }


        public override List<BruteForceResult> TryBrute(string code = null)
        {
            Console.WriteLine($"Starting brute");

            var result = base.TryBrute(code);

            Console.WriteLine("End");
            return result;
        }

        protected override BruteForceResult Brute(uint a, uint b, string code = null)
        {
            Console.Write($"Brute using keys ({a:00}, {b:00})| ");
            var result = base.Brute(a, b, code);

            Console.WriteLine(result.Text);
            Console.WriteLine(new string('-', 20));

            return result;
        }
    }
}
