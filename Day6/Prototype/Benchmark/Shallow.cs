using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.Benchmark
{
    class Shallow
    {
        private List<C1> obs;
        public void Initialize() => obs = C1.GetLongList();
        public List<C1> CloneAllObjects() => obs.Select(c => (C1)c.Clone()).ToList();

        public void ShallowCopyWarmup()
        {
            Console.WriteLine("Cloning warmup");
            for (var i = 0; i < BenchmarkMain.WarmUp; ++i)
                Initialize();
            CloneAllObjects();
            Console.WriteLine("Cloning warmup completed");

        }
        public void CloningCopyTask()
        {
            var t = BenchmarkMain.AverageMillisecondsTakenForMultipleRuns(() => CloneAllObjects(), "CloningCopy");
            Console.WriteLine("Average time per run by Cloning copy is {0} milliseconds", t);
        }

    }
}
