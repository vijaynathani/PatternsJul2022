using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trng.Demo1
{
    class HasCents
    {
        int value;
        public void Add(int coinAdded)
        {
            value += coinAdded;
            if (value >= 20)
            {
                Console.WriteLine("Stamp dispensed");
                value -= 20;
                Cancel();
            }
        }
        public void Cancel()
        {
            if (value == 0) return;
            Console.WriteLine("Returned {0} coins", value);
            value = 0;
        }

    }
    internal class Stamps
    {
        HasCents hc = new HasCents();
        public void FiveCentsInserted() => hc.Add(5);
        public void TenCentsInserted() => hc.Add(10);
        public void ReturnPressed() => hc.Cancel();
    }
}
