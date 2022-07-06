using System;
using System.Threading;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.proxyCircuitBreakerSolution
{
    public class State
    {
        internal const int FailureThreshold = 5;
        private const int _invocationTimeoutInMilliSeconds = 10;
        internal static TimeSpan ResetTimeout = TimeSpan.FromMilliseconds(100);
        internal CircuitState Current = CircuitState.Closed;
        private int _failureCount;
        private DateTime _lastCall = DateTime.Now;

        public void MakeCall(ThreadStart remoteCaller)
        {
            MakeCircuitHalfOpenOnResetTimout();
            switch (Current)
            {
                case CircuitState.Closed:
                case CircuitState.HalfOpen:
                    CallWithTimoutCheck(remoteCaller);
                    break;
                case CircuitState.Open:
                    throw new Exception("Circuit open");
            }
        }

        private void MakeCircuitHalfOpenOnResetTimout()
        {
            DateTime oldValueOfLastCall = _lastCall;
            _lastCall = DateTime.Now;
            if (TimeSpan.Compare(_lastCall.Subtract(oldValueOfLastCall), ResetTimeout) > 0 &&
                Current == CircuitState.Open)
                Current = CircuitState.HalfOpen;
        }

        private void CallWithTimoutCheck(ThreadStart remoteCaller)
        {
            bool completed = false;
            try
            {
                Execute(remoteCaller);
                ResetCircuit();
                completed = true;
            }
            finally
            {
                if (!completed) IncrementFailureCount();
            }
        }

        private static void Execute(ThreadStart ts)
        {
            var th = new Thread(ts);
            th.Start(); //Demo. For efficiency, use Thread pool
            if (th.Join(_invocationTimeoutInMilliSeconds)) return;
            th.Abort();
            throw new TimeoutException();
        }

        private void ResetCircuit()
        {
            _failureCount = 0;
            Current = CircuitState.Closed;
        }

        private void IncrementFailureCount()
        {
            ++_failureCount;
            switch (Current)
            {
                case CircuitState.Closed:
                    if (_failureCount >= FailureThreshold)
                        Current = CircuitState.Open;
                    break;
                case CircuitState.HalfOpen:
                    Current = CircuitState.Open;
                    break;
                case CircuitState.Open: //This can never happen.
                    break;
            }
        }
    }


    internal enum CircuitState
    {
        Closed,
        Open,
        HalfOpen
    }
}