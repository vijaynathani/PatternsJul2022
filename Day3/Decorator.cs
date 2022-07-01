using System;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal interface IBeverage
    {
        int Cost();
        void Dispense();
    }

    internal class Tea : IBeverage
    {
        public int Cost()
        {
            return 10;
        }
        public void Dispense()
        {
            Console.WriteLine("Tea dispensed");
        }
    }

    internal class Coffee : IBeverage
    {
        public int Cost()
        {
            return 15;
        }
        public void Dispense()
        {
            Console.WriteLine("Coffee dispensed");
        }
    }

    internal abstract class Ingredient : IBeverage
    {
        protected IBeverage B;
        protected Ingredient(IBeverage b)
        {
            this.B = b;
        }

        public abstract int Cost();
        public abstract void Dispense();
    }

    internal class Sugar : Ingredient
    {
        public Sugar(IBeverage b) : base(b)
        {
        }

        public override void Dispense()
        {
            Console.WriteLine("Sugar dispensed");
            B.Dispense();
        }

        public override int Cost()
        {
            return 1 + B.Cost();
        }
    }

    internal class Milk : Ingredient
    {
        public Milk(IBeverage b) : base(b)
        {
        }

        public override void Dispense()
        {
            B.Dispense();
            Console.WriteLine("Milk dispensed");
        }

        public override int Cost()
        {
            return 3 + B.Cost();
        }
    }

    internal class Decorator
    {
        private static void PrintCost(IBeverage b)
        {
            Console.WriteLine("Cost is " + b.Cost());
            b.Dispense();
        }

        public static void Main1(string[] args)
        {
            PrintCost(new Sugar(new Milk(new Coffee())));
        }
    }
}