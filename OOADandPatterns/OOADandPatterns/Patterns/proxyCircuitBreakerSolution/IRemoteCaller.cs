using System;

namespace OOADandPatterns.Patterns.proxyCircuitBreakerSolution
{
    public interface IRemoteCaller
    {
        void FastMethod();
        void SlowMethod();
        void Execute(Action r);
    }
}