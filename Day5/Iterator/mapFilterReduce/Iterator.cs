using System;
using System.Collections.Generic;
using System.Linq;

namespace OOADandPatterns.Patterns.mapFilterReduce
{
    internal class Iterator
    {
        private static int SumOfUniqueSqares(IEnumerable<int> numbers)
        {
            return new HashSet<int>(numbers).Select(x => x*x).Sum();
        }

        private static String Compute(IEnumerable<string> values)
        {
            return string.Join(",", values.Select(x => x.ToUpper()).Where(x => x.Length > 2));
        }

        public static void Main1()
        {
            var n = new[] {1, 2, 3, 4};
            Console.WriteLine("For [{0}] the answer is {1}", string.Join(",", n), SumOfUniqueSqares(n));
            var v = new[] {"abc", "d", "ef", "pqr", "xyz"};
            Console.WriteLine("For [{0}] the answer is {1}", string.Join(",", v), Compute(v));
        }
    }
}