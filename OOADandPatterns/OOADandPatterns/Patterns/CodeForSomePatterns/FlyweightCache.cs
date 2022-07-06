using System;
using System.Collections.Generic;
using System.Linq;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    public class LruCache<TE> where TE : class
    {
        private readonly Dictionary<TE, long> _itemAndSequence = new Dictionary<TE, long>();
        private readonly Dictionary<long, TE> _sequenceAndItem = new Dictionary<long, TE>();
        private long _min, _max;
        private readonly int _maxEntries;

        public LruCache(int capacity) => _maxEntries = capacity;

        public TE AddIfNotPresentAndReturnFromCache(TE obj)
        {
            lock (this)
            {
                if (_itemAndSequence.ContainsKey(obj))
                    return _sequenceAndItem[_itemAndSequence[obj]];
                UpdateCache(obj);
                return obj;
            }            
        }
        private void UpdateCache(TE obj)
        {
            AddNewElementInCache(obj);
            if (_itemAndSequence.Count > _maxEntries)
                TrimCache();
        }
        private void AddNewElementInCache(TE obj)
        {
            _itemAndSequence.Add(obj, _max);
            _sequenceAndItem.Add(_max++, obj);
        }
        private void TrimCache()
        {
            _itemAndSequence.Remove(_sequenceAndItem[_min]);
            _sequenceAndItem.Remove(_min++);
        }

        public override string ToString() => string.Join(",", _itemAndSequence.Keys);
    }

    public class FlyweightCache
    {
        public static void Main1()
        {
            var myCache = new LruCache<string>(5);
            for (var i = 1; i <= 30; ++i)
                myCache.AddIfNotPresentAndReturnFromCache(i.ToString());
            Console.WriteLine(myCache);
            var a = 200.ToString();
            var b = 200.ToString();
            Console.WriteLine(ReferenceEquals(a, b));
            a = myCache.AddIfNotPresentAndReturnFromCache(a);
            b = myCache.AddIfNotPresentAndReturnFromCache(b);
            Console.WriteLine(ReferenceEquals(a, b));
        }
    }
}