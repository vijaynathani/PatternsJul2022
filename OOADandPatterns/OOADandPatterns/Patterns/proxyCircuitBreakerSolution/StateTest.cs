using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOADandPatterns.Patterns.proxyCircuitBreakerSolution
{
    [TestClass]
    public class StateTest
    {
        private const int WaitLongTime = 20000;
        private readonly State _sut = new State();
        private int _milliSecondsToSleep = 1;
        private ThreadStart _r;

        [TestInitialize]
        public void SetUp()
        {
            _r = () => RemoteCaller.SleepFor(_milliSecondsToSleep);
        }

        [TestMethod]
        public void circuit_closed_at_start_and_when_connection_working()
        {
            Assert.AreEqual(CircuitState.Closed, _sut.Current);
            _sut.MakeCall(_r);
            Assert.AreEqual(CircuitState.Closed, _sut.Current);
            _sut.MakeCall(_r);
            Assert.AreEqual(CircuitState.Closed, _sut.Current);
            _sut.MakeCall(_r);
            Assert.AreEqual(CircuitState.Closed, _sut.Current);
        }

        [TestMethod]
        [ExpectedException(typeof (TimeoutException))]
        public void timeout_thows_exception()
        {
            _milliSecondsToSleep = WaitLongTime;
            Assert.AreEqual(CircuitState.Closed, _sut.Current);
            _sut.MakeCall(_r);
            Assert.AreEqual(CircuitState.Closed, _sut.Current);
        }

        [TestMethod]
        public void multiple_timeouts_cause_circuit_to_open()
        {
            _milliSecondsToSleep = WaitLongTime;
            for (int i = 0; i < State.FailureThreshold; ++i)
            {
                Assert.AreEqual(CircuitState.Closed, _sut.Current);
                make_call_ignoring_exception_thrown();
            }
            Assert.AreEqual(CircuitState.Open, _sut.Current);
        }

        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void open_circuit_causes_failure()
        {
            _sut.Current = CircuitState.Open;
            _sut.MakeCall(_r);
        }

        [TestMethod]
        public void circuit_reset_when_success_in_half_open()
        {
            _sut.Current = CircuitState.HalfOpen;
            _sut.MakeCall(_r);
            Assert.AreEqual(CircuitState.Closed, _sut.Current);
        }

        [TestMethod]
        [ExpectedException(typeof (TimeoutException))]
        public void cirucit_goes_to_half_open_state_after_some_time()
        {
            _sut.Current = CircuitState.Open;
            _milliSecondsToSleep = WaitLongTime;

            var sleepDuration = (int) State.ResetTimeout.TotalMilliseconds;
            RemoteCaller.SleepFor(sleepDuration + 1);
            _sut.MakeCall(_r);
        }

        private void make_call_ignoring_exception_thrown()
        {
            try
            {
                _sut.MakeCall(_r);
            }
            catch (Exception ignore)
            {
                return;
            }
            Assert.Fail("Expected Exception not thrown");
        }
    }
}