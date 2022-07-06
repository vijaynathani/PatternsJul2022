using System;
using System.Threading;

namespace OOADandPatterns.Patterns.proxyCircuitBreakerSolution
{
    public class RemoteCaller : IRemoteCaller
    {
        public void FastMethod()
        {
            SleepFor(1);
        }

        public void SlowMethod()
        {
            SleepFor(20000);
        }

        public void Execute(Action r)
        {
            r();
        }

        public static void SleepFor(int milliSecondsT)
        {
            Thread.Sleep(milliSecondsT);
        }
    }
}