using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    interface IPizza
    {
        void describe();
    }
    enum PizzaType { Veggi, Cheese }
    public class VeggiPizza : IPizza
    {
        public void describe() { Console.WriteLine("Veggi pizza"); }
    }
    class SimplePizzaFactory
    {
        public static IPizza Create(PizzaType pt)
        {
            if (pt == PizzaType.Veggi) return new VeggiPizza();
            return null;
        }
    }
}
namespace Factory
{
    interface IPizza
    {
        void describe();
    }
    enum PizzaType { Veggi, Cheese }
    public class MumbaiVeggiPizza : IPizza
    {
        public void describe() { Console.WriteLine("Mumbai Veggi pizza"); }
    }
    public class MumbaiCheesePizza : IPizza
    {
        public void describe() { Console.WriteLine("Mumbai Cheese pizza"); }
    }
    public class PuneVeggiPizza : IPizza
    {
        public void describe() { Console.WriteLine("Pune Veggi pizza"); }
    }
    public class PuneCheesePizza : IPizza
    {
        public void describe() { Console.WriteLine("Pune Cheese pizza"); }
    }

    abstract class PizzaFactory
    {
        public abstract IPizza Create(PizzaType pt);
    }
    class MumbaiPizzaFactory : PizzaFactory
    {
        public override IPizza Create(PizzaType pt)
        {
            if (pt == PizzaType.Veggi) return new MumbaiVeggiPizza();
            if (pt == PizzaType.Cheese) return new MumbaiCheesePizza();
            return null;
        }
    }
    class PunePizzaFactory : PizzaFactory
    {
        public override IPizza Create(PizzaType pt)
        {
            if (pt == PizzaType.Veggi) return new PuneVeggiPizza();
            if (pt == PizzaType.Cheese) return new PuneCheesePizza();
            return null;
        }
    }
}
namespace abstractFactory
{
    interface ICrust { }
    class ThickCrust : ICrust { }
    class ThinCrust : ICrust { }
    interface ICheese { }
    class MozarellaCheese : ICheese { }
    class ReggianoCheese : ICheese { }
    interface IVeggies { }
    class JainVeggies : IVeggies { }
    class SpicyVeggies : IVeggies { }
    abstract class PizzaFactory
    {
        public abstract ICrust CreateCrust();
        public abstract ICheese CreateCheese();
        public abstract IVeggies CreateVeggies();
    }
    class MumbaiPizzaFactory : PizzaFactory
    {
        public override ICrust CreateCrust() { return new ThickCrust(); }
        public override ICheese CreateCheese() { return new MozarellaCheese(); }
        public override IVeggies CreateVeggies() { return new JainVeggies();  }
    }
    class PunePizzaFactory : PizzaFactory
    {
        public override ICrust CreateCrust() { return new ThinCrust(); }
        public override ICheese CreateCheese() { return new ReggianoCheese(); }
        public override IVeggies CreateVeggies() { return new SpicyVeggies(); }
    }

}
namespace Trng.Demo1
{
    internal class FactoryDemo
    {
    }
}
