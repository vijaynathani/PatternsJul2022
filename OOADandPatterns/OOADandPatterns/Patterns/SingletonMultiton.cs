using System;
using System.Collections.Concurrent;

namespace OOADandPatterns.Patterns
{
    public class MultiTonManage
    {
        private ConcurrentDictionary<string, Reusable1> pool = new ConcurrentDictionary<string, Reusable1>();
        private static int _count = 1;
        private MultiTonManage() { }
        internal static readonly MultiTonManage Instance = new MultiTonManage();
        public Reusable1 GetFor(string key)
        {
            if (pool.TryGetValue(key, out var r)) return r;
            InsertFor(key);
            return GetFor(key);
        }
        private void InsertFor(String key)
        {
            lock (this)
            { //double locking
                if (pool.TryGetValue(key, out Reusable1 r)) return;
                pool.TryAdd(key, new Reusable1(_count++));
            }
        }
    }
    public class Reusable1
    {
        readonly int _value;
        public Reusable1(int value) => _value = value;
        public override string ToString() => "Reusable [value=" + _value + "]";
    }
}
