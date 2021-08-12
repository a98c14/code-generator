using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyGenerator
{
    class Program
    {
        private const string PossibleChars = "ACDEFGHKLMNPRTXYZ234579";

        static List<string> GeneratePossibleSeeds(string chars)
        {
            var random = new Random();
            random.Next(0, 2 ^ 64);
            var seeds = new int[2 ^ 64];
            var index = 0;
            for (int i = 0; i < chars.Length; i++)
            {

            }
            return seeds.ToList();
        }

        static List<string> GenerateSeeds(int count, List<string> possibleSeeds)
        {
            if (count >= possibleSeeds.Count)
                throw new ArgumentException("Count parameter can't be larger than seed count!");
            // TODO: selim
            var seeds = new List<string>();
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                var index = rand.Next(0, possibleSeeds.Count);
                var seed = possibleSeeds[index];
                seeds.Add(seed);
                possibleSeeds.RemoveAt(index);
            }
            return seeds;
        }

        static void Main(string[] args)
        {
            // 6 Letters Seed () - 2 Letters Checksum (46 bit)
            var possibleSeeds = GeneratePossibleSeeds(PossibleChars);
            var seeds = GenerateSeeds(10000000, possibleSeeds);



            Console.WriteLine("Hello World!");
        }
    }
}
