using System;
using System.Text;
using System.Threading;

namespace OOAD
{
    public class CircuitBreaker
    {
        private const int MillisecondsPerSecond = 1000;
        private const int TenSeconds = 10*MillisecondsPerSecond;
        private readonly StringBuilder _exclusive = new StringBuilder();
        private long _counter;
        private volatile Timer _interrupt;
        private volatile Thread _originalThread;
        private int _timeout = TenSeconds;

        public void CallAntoherProcess(Action functionToCall)
        {
            // Throws ThreadInterruptedException, 
            // if functionToCall takes more than timeout
            Interlocked.Increment(ref _counter);
            _interrupt = new Timer(TimeFinished, Interlocked.Read(ref _counter),
                                   _timeout, Timeout.Infinite);
            _originalThread = Thread.CurrentThread;
            try
            {
                functionToCall();
            }
            finally
            {
                lock (_exclusive)
                {
                    ResetTimer();
                }
            }
        }

        private void ResetTimer()
        {
            _originalThread = null;
            if (_interrupt != null) _interrupt.Dispose();
            _interrupt = null;
        }

        private void TimeFinished(Object count)
        {
            var lastCount = (long) count;
            lock (_exclusive)
            {
                if (_counter != Interlocked.Read(ref lastCount) || _originalThread == null) return;
                _originalThread.Interrupt();
                ResetTimer();
            }
        }

        public void ChangeTimeout(int valueInMilliseconds)
        {
            _timeout = valueInMilliseconds;
        }
    }

    public class CircuitBreakerCaller
    {
        public static void Main1()
        {
            var cb = new CircuitBreaker();
            cb.ChangeTimeout(3000);
            cb.CallAntoherProcess(FastFunction);
            cb.CallAntoherProcess(SlowFunction);
        }

        public static void FastFunction()
        {
            Thread.Sleep(1000);
        }

        public static void SlowFunction()
        {
            Thread.Sleep(100000);
        }
    }
}