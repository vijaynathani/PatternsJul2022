using System;
using System.Collections.Generic;

/*
 * The goal is to classify numbers. A number is perfect, if the sum of its
 * factors equals the number e.g. 6 is perfect. The factors are 1, 2, 3. 1 + 2 +
 * 3 equals 6. 
 * A number is abundant, if the sum of its factors is greater than
 * the number e.g. 12 is abundant. The factors are 1, 2, 3, 4 and 6. 1+2+3+4+6
 * is greater than 12.
 * A number is deficient, if the sum of its factors is less
 * than the number e.g. 10 is deficient. The factors are 1, 2, 5. 1+2+5 is less
 * than 10.
 */

namespace LearnCS.ooad
{
    internal class NumberClassifier
    {
        private readonly ISet<int> _factors = new HashSet<int>();
        private readonly int _number;

        public NumberClassifier(int number)
        {
            if (number < 1)
                throw new Exception("Can't classify negative numbers");
            _number = number;
            _factors.Add(1);
        }

        private bool IsFactor(int factor)
        {
            return (_number%factor) == 0;
        }

        public ISet<int> GetFactors()
        {
            return _factors;
        }

        private void CalculateFactors()
        {
            for (int i = 2; i <= Math.Sqrt(_number); i++)
                if (IsFactor(i))
                    AddFactor(i);
        }

        private void AddFactor(int factor)
        {
            _factors.Add(factor);
            _factors.Add(_number/factor);
        }

        private int SumOfFactors()
        {
            CalculateFactors();
            int sum = 0;
            foreach (int i in _factors)
                sum += i;
            return sum;
        }

        public bool IsPerfect()
        {
            return SumOfFactors() == _number;
        }

        public bool IsAbundant()
        {
            return SumOfFactors() > _number;
        }

        public bool IsDeficient()
        {
            return SumOfFactors() < _number;
        }

        public static bool IsPerfect(int number)
        {
            return new NumberClassifier(number).IsPerfect();
        }
    }
}