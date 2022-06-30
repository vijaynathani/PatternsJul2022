using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnCS.ooad
{
    internal class NumberClassifier
    {
        public static bool IsFactor(int number, int potentialFactor)
        {
            return (number%potentialFactor) == 0;
        }
        public static ISet<int> Factors(int number)
        {
            var factors = new HashSet<int> {1};
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (IsFactor(number, i))
                {
                    factors.Add(i);
                    factors.Add(number/i);
                }
            return factors;
        }
        private static int Sum(int number)
        {
            return Factors(number).Sum();
        }

        public static bool IsPerfect(int number)
        {
            return Sum(number) == number;
        }

        public static bool IsAbundant(int number)
        {
            return Sum(number) > number;
        }

        public static bool IsDeficient(int number)
        {
            return Sum(number) < number;
        }
    }
} 