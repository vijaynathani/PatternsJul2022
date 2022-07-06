using System;
using System.Collections.Generic;
using System.Linq;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal class Product
    {
        public int Size, Color, Price;

        public Product(int s, int c, int p)
        {
            Size = s;
            Color = c;
            Price = p;
        }
    }

    internal class ProductFinder
    {
        public List<Product> AllProducts = new List<Product>();

        public List<Product> BelowPriceAvoidingAColor(int price, int color)
        {
            return AllProducts.Where(p => p.Price < price && p.Color != color).ToList();
        }
    }

    public class Inter1
    {
        public static void Main1(string[] args)
        {
            var p = new ProductFinder();
            p.AllProducts.Add(new Product(10, 255, 5000));
            p.AllProducts.Add(new Product(12, 200, 1000));
            p.AllProducts.Add(new Product(15, 255, 1000));
            foreach (var r in p.BelowPriceAvoidingAColor(2000, 200))
                Console.WriteLine("Product: " + r.Price + " " + r.Color + " " + r.Size);
        }
    }
}
//This is code is without the Interpreter design pattern.