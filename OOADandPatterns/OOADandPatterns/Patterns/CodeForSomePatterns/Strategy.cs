using System;

namespace OOADandPatterns.Patterns.strategy
{
    internal interface IFlyable
    {
        void Fly();
    }

    internal class FlyWithWings : IFlyable
    {
        public void Fly() => Console.WriteLine("Duck flying");
    }

    internal class FlyNo : IFlyable
    {
        public void Fly() => Console.WriteLine("Duck stationary");
    }

    internal interface IQuackable
    {
        void speak();
    }

    internal class QuackNormal : IQuackable
    {
        public void speak() => Console.WriteLine("Duck quacking");
    }

    internal class QuackSqueak : IQuackable
    {
        public void speak() => Console.WriteLine("Duck squeaking");
    }

    internal class QuackNone : IQuackable
    {
        public void speak() => Console.WriteLine("Duck silent");
    }

    internal abstract class Duck
    {
        private readonly IFlyable _flyingBehaviour;
        private readonly IQuackable _quackingBehaviour;

        public Duck(IFlyable flyingBehaviour, IQuackable quackingBehaviour)
        {
            _flyingBehaviour = flyingBehaviour;
            _quackingBehaviour = quackingBehaviour;
        }

        public void Swim()
        {
            Console.WriteLine("Duck swimming");
        }

        public void Display()
        {
            Console.WriteLine("Duck painted");
        }

        public void Fly()
        {
            _flyingBehaviour.Fly();
        }

        public void MakeNoise()
        {
            _quackingBehaviour.speak();
        }
    }

    internal class DecoyDuck : Duck
    {
        public DecoyDuck() : base(new FlyNo(), new QuackNone())
        {
        }
    }

    internal class RedHeadDuck : Duck
    {
        public RedHeadDuck() : base(new FlyWithWings(), new QuackNormal())
        {
        }
    }

    internal class WhiteSmallDuck : Duck
    {
        public WhiteSmallDuck() : base(new FlyNo(), new QuackNormal())
        {
        }
    }

    internal class RubberDuck : Duck
    {
        public RubberDuck() : base(new FlyNo(), new QuackSqueak())
        {
        }
    }

    public class Strategy
    {
        private static void Process(Duck d)
        {
            d.Swim();
            d.Display();
            d.Fly();
            d.MakeNoise();
        }

        public static void Main1() => Process(new DecoyDuck());
    }
}