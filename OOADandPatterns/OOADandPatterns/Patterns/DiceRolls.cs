using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OOADandPatterns.Patterns
{
    public class DiceRolls
    {
        private const int N = 100000000, MaxDiceValue = 6;
        private readonly ThreadLocal<Random> _r = new(() => new Random());

        public static void Main1()
        {
            Console.WriteLine(string.Join("\n", new DiceRolls().Count()));
        }

        private Dictionary<int, double> Count()
        {
            var numberOfTimes = new int[MaxDiceValue*2];
            Enumerable.Range(0, N).AsParallel()
                .Select(x => TwoDiceThrows())
                .ForAll(v => Interlocked.Increment(ref numberOfTimes[v - 1]));
            return Enumerable.Range(1, numberOfTimes.Length - 1).ToDictionary(x => x + 1, d => numberOfTimes[d]*1.0/N);
        }

        private int TwoDiceThrows()
        {
            int OneDiceThrow() => _r.Value.Next(MaxDiceValue) + 1;
            return OneDiceThrow() + OneDiceThrow();
        }
    }
}