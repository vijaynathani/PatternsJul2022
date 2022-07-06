using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal class C1F
    {
        private int _a, _b, _c;

        internal C1F(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
        //...
    }

    class BuilderFluent
    {
        private int _a;
        private bool _ag;
        private int _b;
        private bool _bg;
        private int _c;
        private bool _cg;
        public BuilderFluent SetA(int a)
        {
            _ag = true;
            _a = a;
            return this;
        }

        public BuilderFluent SetB(int b)
        {
            _bg = true;
            _b = b;
            return this;
        }

        public BuilderFluent SetC(int c)
        {
            _cg = true;
            _c = c;
            return this;
        }

        public static C1F GiveInstance(Action<BuilderFluent> cb)
        {   
            var b = new BuilderFluent();
            cb.Invoke(b);
            if (!b._ag) b._a = 5;
            if (!b._bg) b._b = 50;
            if (!b._cg) b._c = 150;
            return new C1F(b._a, b._b, b._c);
        }
    }
    internal class FluentBuilderDemo
    {
        public static C1F GiveInstance() => BuilderFluent.GiveInstance(b => b.SetB(1).SetC(20));

    }

}
