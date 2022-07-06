using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.demo
{
    public class C1
    {
        private C1()
        {
        }

        private static readonly C1 Ins = new C1();

        public static C1 Instance
        {
            get { return Ins; }
        }
    }
}
