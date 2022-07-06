using System;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal abstract class State
    {
        protected GumballMachine g;

        protected State(GumballMachine g)
        {
            this.g = g;
        }

        public virtual void CoinInserted()
        {
        }

        public virtual void LeverTurned()
        {
        }

        public virtual void EjectPressed()
        {
        }

        protected virtual void RefundCoin()
        {
            Console.WriteLine("Coin refunded");
        }
    }

    internal class SoldOutState : State
    {
        public SoldOutState(GumballMachine g) : base(g)
        {
        }

        public override void CoinInserted()
        {
            RefundCoin();
        }
    }

    internal class NoQuarterState : State
    {
        public NoQuarterState(GumballMachine g) : base(g)
        {
        }

        public override void CoinInserted()
        {
            g.GotoHasQuarter();
        }
    }

    internal class HasQuarterState : State
    {
        public HasQuarterState(GumballMachine g) : base(g)
        {
        }

        public override void CoinInserted()
        {
            RefundCoin();
        }

        public override void EjectPressed()
        {
            RefundCoin();
            g.GotoNoQuarter();
        }

        public override void LeverTurned()
        {
            g.DispenseGumball();
        }
    }

    internal class GumballMachine
    {
        private int _remainingGumballs;
        private State s;

        public GumballMachine(int gumballs)
        {
            _remainingGumballs = gumballs;
            s = new NoQuarterState(this);
        }

        public void DispenseGumball()
        {
            Console.WriteLine("Gumball dispensed");
            if (--_remainingGumballs > 0) s = new NoQuarterState(this);
            else s = new SoldOutState(this);
        }

        public void GotoHasQuarter()
        {
            s = new HasQuarterState(this);
        }

        public void GotoNoQuarter()
        {
            s = new NoQuarterState(this);
        }

        public void CoinInserted()
        {
            s.CoinInserted();
        }

        public void LeverTurned()
        {
            s.LeverTurned();
        }

        public void EjectPressed()
        {
            s.EjectPressed();
        }
    }

    public class StateDP
    {
        public static void Main1(string[] args)
        {
            var g = new GumballMachine(2);
            g.CoinInserted();
            g.LeverTurned();
            g.CoinInserted();
            g.LeverTurned();
            g.LeverTurned();
        }
    }
}