using System;
using System.Collections;
using System.Collections.Generic;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal class IntRange : IEnumerable<int>
    {
        private readonly int _lower;
        private readonly int _upper;

        public IntRange(int lower, int upper)
        {
            _lower = lower;
            _upper = upper;
        }

        #region IEnumerable<int> Members

        public IEnumerator<int> GetEnumerator()
        {
            var current = _lower;
            while (current <= _upper)
            {
                yield return current++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }

    internal class IteratorDP
    {
        public void PrintRange()
        {
            foreach (var n in new IntRange(2, 10))
                Console.WriteLine(n);
        }
    }
}