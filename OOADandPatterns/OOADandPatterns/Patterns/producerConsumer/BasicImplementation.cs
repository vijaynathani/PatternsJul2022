using System;
using System.Threading;

namespace Patterns.producerConsumer
{
    internal class Common
    {
        public const int Tokens = 1000000;
        public const int Size = 100;
        private readonly int[] _numbers = new int[Size];
        private int _count, _readPointer, _writePointer;

        public void AddNumber(int n)
        {
            lock (this)
            {
                while (_count == Size)
                    Monitor.Wait(this);
                _numbers[_writePointer] = n;
                _writePointer = (_writePointer + 1)%Size;
                ++_count;
                Monitor.Pulse(this);
            }
        }

        public int RetrieveNumber()
        {
            var v = 0;
            lock (this)
            {
                while (_count == 0)
                    Monitor.Wait(this);
                v = _numbers[_readPointer];
                _readPointer = (_readPointer + 1)%Size;
                --_count;
                Monitor.Pulse(this);
            }
            return v;
        }
    }

    internal class Consumer
    {
        private readonly Common _c;

        public Consumer(Common c)
        {
            _c = c;
        }

        public int Odds { get; private set; }
        public int Evens { get; private set; }

        public void Go()
        {
            for (int i = 0; i < Common.Tokens; ++i)
                _ = (_c.RetrieveNumber()%2 == 0) ? ++Evens : ++Odds;
        }
    }

    internal class Producer
    {
        private readonly Common _c;

        public Producer(Common c)
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

    public class BasicImplementation
    {
        public static void Main1()
        {
            var c = new Common();
            var pr = new Producer(c);
            var co = new Consumer(c);
            new Thread(pr.Go).Start();
            co.Go();
            Console.WriteLine("Odds = {0} Evens={1}", co.Odds, co.Evens);
        }
    }
}