using System;
using System.Collections.Generic;
using System.Linq;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{

    internal interface Spec
    {
        bool IsSatisfiedBy(Product p);
    }

    internal class BelowPriceSpec : Spec
    {
        private readonly int _price;

        public BelowPriceSpec(int price)
        {
            this._price = price;
        }

        public bool IsSatisfiedBy(Product p)
        {
            return p.Price < _price;
        }
    }

    internal class ColorSpec : Spec
    {
        private readonly int _color;

        public ColorSpec(int color)
        {
            this._color = color;
        }

        public bool IsSatisfiedBy(Product p)
        {
            return p.Color == _color;
        }
    }

    internal class NotSpec : Spec
    {
        private readonly Spec _s;

        public NotSpec(Spec s)
        {
            this._s = s;
        }

        public bool IsSatisfiedBy(Product p)
        {
            return !_s.IsSatisfiedBy(p);
        }
    }

    internal class AndSpec : Spec
    {
        private readonly Spec _s1;
        private readonly Spec _s2;

        public AndSpec(Spec s1, Spec s2)
        {
            this._s1 = s1;
            this._s2 = s2;
        }

        public bool IsSatisfiedBy(Product p)
        {
            return _s1.IsSatisfiedBy(p) && _s2.IsSatisfiedBy(p);
        }
    }

    internal class ProductFinder2
    {
        public List<Product> AllProducts = new List<Product>();

        public List<Product> SelectBy(Spec s)
        {
            return AllProducts.Where(s.IsSatisfiedBy).ToList();
        }
    }

    public class Inter2
    {
        public static void Main1(string[] args)
        {
            var p = new ProductFinder2();
            p.AllProducts.Add(new Product(10, 255, 5000));
            p.AllProducts.Add(new Product(12, 200, 1000));
            p.AllProducts.Add(new Product(15, 255, 1000));
            var matched = p.SelectBy(
                new AndSpec(new BelowPriceSpec(2000),
                    new NotSpec(new ColorSpec(200))));
            foreach (var r in matched)
                Console.WriteLine("Product: " + r.Price + " " + r.Color + " " + r.Size);
        }
    }
}
//This code is with Interpreter design pattern.