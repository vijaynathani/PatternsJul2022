using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.Benchmark
{
    [Serializable]
    public class C1 : ICloneable
    {
        int _i;
        double _j;
        long _k1, _k2, _k3, _k4, _k5;
        static readonly Random Rnd = new Random();
        public C1()
        {
            _i = Rnd.Next();
            _j = Rnd.NextDouble();
            _k1 = Rnd.Next() << 3;
            _k2 = Rnd.Next() << 5;
            _k3 = Rnd.Next() << 7;
            _k4 = Rnd.Next() << 9;
            _k5 = Rnd.Next() << 11;
        }

        public C1(C1 original)
        {
            _i = original._i;
            _j = original._j;
            _k1 = original._k1;
            _k2 = original._k2;
            _k3 = original._k3;
            _k4 = original._k4;
            _k5 = original._k5;
        }

        public object Clone() => this.MemberwiseClone();

        public static List<C1> GetLongList()
        {
            List<C1> obs = new List<C1>();
            for (var i = 0; i < 1000000; ++i)
                obs.Add(new C1());
            return obs;
        }

    }
}
