using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.Benchmark
{
    public class BenchmarkMain
    {
        public const int WarmUp = 2, NumberOfRuns = 10;

        private static long MillisecondsTakenFor(Action myJob)
        {
            var start = DateTime.Now.Ticks;
            myJob();
            var end = DateTime.Now.Ticks;
            return (end - start) / 10000;
        }

        public static long AverageMillisecondsTakenForMultipleRuns(Action job, string jobDescription)
        {
            var start = DateTime.Now.Ticks;
            for (int i = 1; i <= NumberOfRuns; ++i)
                Console.WriteLine("{0} run of {1} took {2} milliseconds", i, jobDescription, MillisecondsTakenFor(job));
            var end = DateTime.Now.Ticks;
            return (end - start) / (10000 * NumberOfRuns);
        }


        public static void Main1()
        {
            var mc = new ManualCopy();
            mc.ManualCopyWarmup();
            mc.ManualCopyTask();

            var sh = new Shallow();
            sh.ShallowCopyWarmup();
            sh.CloningCopyTask();

            var dc = new DeepCopy();
            dc.DeepCopyWarmup();
            dc.DeepCopyTask();
        }
    }
}
