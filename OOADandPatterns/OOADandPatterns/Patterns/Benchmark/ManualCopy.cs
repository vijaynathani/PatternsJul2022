using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.Benchmark
{
    public class ManualCopy
    {
        private List<C1> obs;
        public void Initialize() => obs = C1.GetLongList();
        public List<C1> ManuallyCopyAllObjects() => obs.Select(c => new C1(c)).ToList();

        public void ManualCopyWarmup()
        {
            Console.WriteLine("Manual copy warmup");
            for (var i = 0; i < BenchmarkMain.WarmUp; ++i)
                Initialize();
            ManuallyCopyAllObjects();
            Console.WriteLine("Manual copy warmup completed");

        }
        public void ManualCopyTask()
        {
            var t = BenchmarkMain.AverageMillisecondsTakenForMultipleRuns(() => ManuallyCopyAllObjects(), "ManualCopy");
            Console.WriteLine("Average time per run by Manual copy is {0} milliseconds", t);
        }

    }
}
