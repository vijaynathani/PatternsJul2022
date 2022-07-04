using System;
using System.Collections.Concurrent;
using System.Threading;

namespace OOADandPatterns.Patterns
{
    class Reusable
    {
        readonly int _value;
        public Reusable(int value) => this._value = value;
        public override string ToString() => $"Reusable [value={_value}]";
    }
    class ReusablePool
    {
        public static readonly ReusablePool Instance = new ReusablePool();
        const int Count = 10;
        readonly ConcurrentBag<Reusable> _items = new ConcurrentBag<Reusable>();
        readonly SemaphoreSlim _pool = new SemaphoreSlim(Count);
        private ReusablePool()
        {
            for (var i = 1; i <= Count; ++i)
                _items.Add(new Reusable(i));
        }

        public Reusable Acquire()
        {
            _pool.Wait();
            _items.TryTake(out var r);
            return r;
        }

        public void Release(Reusable r)
        {
            _items.Add(r);
            _pool.Release();
        }
    }

    public class SingletonObjectPool
    {
        public static void Main1()
        {
            for (var i = 0; i < 20; ++i)
              new Thread(Run).Start();
        }
    private static void Run()
        {
            while (true)
            {
                WaitRandomTime();
                Console.WriteLine("acquiring");
                var r = ReusablePool.Instance.Acquire();
                Console.WriteLine("Thread {0} Acquired {1}%n", Thread.CurrentThread.ManagedThreadId, r);
                WaitRandomTime();
                Console.WriteLine("Thread %d Releasing %s%n", Thread.CurrentThread.ManagedThreadId, r);
                ReusablePool.Instance.Release(r);
            }
        }

        private static readonly Random Rnd = new Random();
        private static void WaitRandomTime() => Thread.Sleep(Rnd.Next(7000) + 1000);
    }

}
