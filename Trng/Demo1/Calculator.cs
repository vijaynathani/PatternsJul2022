using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trng.Demo1
{
    internal abstract class Calculator 
    {
        protected Calculator() { }
        public static Calculator CreateCalculator() {  return new SimpleCalculator(); }
        public abstract int add(int n1, int n2);
    }
    class SimpleCalculator : Calculator
    {
        public override int add(int n1, int n2) { return n1 + n2; }
    }

    class Computation
    {
        private static void Main2(Calculator c)
        {
            c.add(1, 2);

        }
        public static void Main1()
        {
            Main2(Calculator.CreateCalculator());
        }
    }
}
