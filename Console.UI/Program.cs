using System;
using System.Diagnostics;
using Criptology.Afine.Algorithm;
using Cryptology.Caesar.Algorithm;
using Cryptology.Cardano;
using Cryptology.Core;
using Cryptology.Core.Algorithm;
using Cryptology.Rail.Algorithm;
using Cryptology.Rsa.Algorithm;
using Cryptology.Vijender.Algorithm;
using Unity;

namespace Cryptology.ConsoleUI
{
    public class Program
    {
        private static IUnityContainer container;

        private static void ConfigureContainer()
        {
            container = new UnityContainer();
            container.RegisterFactory<IAlgorithm>(GlobalConstants.Algorithms.Affine, (c) => new AffineAlgorithm(2, 5));
            container.RegisterFactory<IAlgorithm>(GlobalConstants.Algorithms.Caesar, (c) => new CaesarAlgorithm(3));
            container.RegisterFactory<IAlgorithm>(GlobalConstants.Algorithms.Cardano, (c) => new CardanoAlgorithm("2508"));
            container.RegisterFactory<IAlgorithm>(GlobalConstants.Algorithms.Rail, (c) => new RailAlgorithm(3));
            container.RegisterFactory<IAlgorithm>(GlobalConstants.Algorithms.Rsa, (c) => new RsaAlgorithm());
            container.RegisterFactory<IAlgorithm>(GlobalConstants.Algorithms.Vijender, (c) => new VijenderAlgorithm("hello"));
        }
        
        private static void Main(string[] args)
        {
            ConfigureContainer();
            IAlgorithm alg;
            try
            {
                alg = container.Resolve<IAlgorithm>(GlobalConstants.Algorithms.Affine);
                var code = alg.Encode("hello how are you");

                Console.WriteLine(code);

                var text = alg.Decode(code);

                Console.WriteLine(text);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RailAlgorithmTimeTest()
        {
            var text = new string('a', 10000);
            var sw = Stopwatch.StartNew();
            var alg = new RailAlgorithm(3);
            Console.WriteLine("Encode");
            for (var i = 0; i < 500; i++)
            {
                alg.Encode(text);
            }
            sw.Stop();
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds / 1000f} s");
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds * 10e6f} ns");
            Console.WriteLine("Decode");
            sw = Stopwatch.StartNew();
            for (var i = 0; i < 500; i++)
            {
                alg.Decode(text);
            }
            sw.Stop();
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds / 1000f} s");
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds * 10e6f} ns");


            var h = alg.Encode("hello");
            Console.WriteLine(h);

            var hh = alg.Decode(h);

            Console.WriteLine(hh);
        }
    }
}
