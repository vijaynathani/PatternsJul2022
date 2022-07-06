using System;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal class C1
    {
        private int _a, _b, _c, _d, _e;

        internal C1(int a, int b, int c, int d, int e)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
        }

        //...
    }

    internal class C1Builder
    {
        private int _a;
        private bool _ag;
        private int _b;
        private bool _bg;
        private int _c;
        private bool _cg;
        private int _d;
        private bool _dg;
        private int _e;
        private bool _eg;

        public C1Builder SetA(int a)
        {
            _ag = true;
            _a = a;
            return this;
        }

        public C1Builder SetB(int b)
        {
            _bg = true;
            _b = b;
            return this;
        }

        public C1Builder SetC(int c)
        {
            _cg = true;
            _c = c;
            return this;
        }

        public C1Builder SetD(int d)
        {
            _dg = true;
            _d = d;
            return this;
        }

        public C1Builder SetE(int e)
        {
            _eg = true;
            _e = e;
            return this;
        }

        public C1 GiveInstance()
        {
            if (!_ag) _a = 5;
            if (!_bg) _b = 50;
            if (!_cg) _c = 150;
            if (!_dg) _d = 250;
            if (!_eg) _e = 350;
            return new C1(_a, _b, _c, _d, _e);
        }
    }
    internal class C1BuilderForCsharp
    {
        public static C1 BuilderDemo() => new C1Builder().SetB(1).SetD(20).GiveInstance();

        public static C1 GiveInstance(int a=5, int b=50, int c= 150, int d=250, int e=350) => 
            new C1(a, b, c, d, e);
        //e.g. GiveInstance(b: 1, d: 20);
        //This method works only if default values are compile time constants.

    }
}