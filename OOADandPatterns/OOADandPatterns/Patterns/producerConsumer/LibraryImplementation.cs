using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Patterns.producerConsumer
{
    internal class Common1
    {
        public const int Tokens = 1000000;
        public const int Size = 100;
        private readonly BlockingCollection<int> _numbers = new BlockingCollection<int>(Size);

        public void AddNumber(int n)
        {
            _numbers.Add(n);
        }

        public int RetrieveNumber()
        {
            return _numbers.Take();
        }
    }

    internal class Consumer1
    {
        private readonly Common1 _c;

        public Consumer1(Common1 c)
        {
            _c = c;
        }

        public int Odds { get; private set; }
        public int Evens { get; private set; }

        public void Go()
        {
            int value;
            for (int i = 0; i < Common.Tokens; ++i)
                value = (_c.RetrieveNumber()%2 == 0) ? ++Evens : ++Odds;
        }
    }

    internal class Producer1
    {
        private readonly Common1 _c;

        public Producer1(Common1 c)
        {
            _c = c;
        }

        public void Go()
        {
            var r = new Random();
            for (int i = 0; i < Common.Tokens; ++i)
                _c.AddNumber(r.Next());
        }
    }

    internal class LibraryImplementation
    {
        public static void Main1()
        {
            var c = new Common1();
            var pr = new Producer1(c);
            var co = new Consumer1(c);
            new Thread(pr.Go).Start();
            co.Go();
            Console.WriteLine("Odds = {0} Evens={1}", co.Odds, co.Evens);
        }
    }
}