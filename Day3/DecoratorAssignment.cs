using System;
using System.Collections.Generic;
using System.Threading;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal class LineTracker
    {
        public const int LinesPerPage = 66;
        private static readonly ThreadLocal<LineTracker> Ltr = new ThreadLocal<LineTracker>(() => new LineTracker());
        private int _currentLine;
        private readonly List<Decorator1> _footers = new List<Decorator1>();
        private readonly List<Decorator1> _headers = new List<Decorator1>();

        private LineTracker()
        {
        }

        public static LineTracker GetInstance()
        {
            return Ltr.Value;
        }

        public static void AddHeaderAtStart(Decorator1 d)
        {
            GetInstance()._headers.Insert(0, d);
        }

        public static void AddFooterAtEnd(Decorator1 d)
        {
            GetInstance()._footers.Add(d);
        }

        public static bool TimeForHeader(Decorator1 d)
        {
            var ltr = GetInstance();
            return ((ltr._currentLine < ltr._headers.Count) && (ltr._headers[ltr._currentLine] == d));
        }

        public static bool TimeForFooter(Decorator1 d)
        {
            var ltr = GetInstance();
            var footerNumber = LinesPerPage - ltr._currentLine - 1;
            return (footerNumber < ltr._footers.Count) && (ltr._footers[footerNumber] == d);
        }

        public static void Reset()
        {
            Ltr.Value = new LineTracker();
            Console.WriteLine("----------End of Report---------");
        }

        public void Print(String line)
        {
            Console.WriteLine(line);
            if (++_currentLine < LinesPerPage) return;
            _currentLine = 0;
            Console.WriteLine("---New Page---");
        }
    }

    public abstract class Report
    {
        public abstract String NextLine();

        public void PrintFull()
        {
            while (true)
            {
                var s = NextLine();
                if (s == null) break;
                LineTracker.GetInstance().Print(s);
            }
            LineTracker.Reset();
        }
    }

    internal class LineNumber : Report
    {
        private int _currentLine;
        private readonly int max;

        public LineNumber(int max)
        {
            this.max = max;
        }

        public override String NextLine()
        {
            return (++_currentLine > max) ? null : _currentLine.ToString();
        }
    }

    internal class CharacterPr : Report
    {
        private char _c = 'a';
        private int _max;

        public CharacterPr(int max)
        {
            _max = max;
        }

        public override String NextLine()
        {
            var p = _c;
            if (++_c > 'z') _c = 'a';
            return (_max-- > 0) ? p.ToString() : null;
        }
    }

    internal abstract class Decorator1 : Report
    {
        protected Report R;

        internal Decorator1(Report r)
        {
            R = r;
        }
    }

    internal class Header1 : Decorator1
    {
        internal Header1(Report r) : base(r)
        {
            LineTracker.AddHeaderAtStart(this);
        }

        public override String NextLine()
        {
            return LineTracker.TimeForHeader(this) ? "header 1" : R.NextLine();
        }
    }

    internal class Header2 : Decorator1
    {
        internal Header2(Report r) : base(r)
        {
            LineTracker.AddHeaderAtStart(this);
        }

        public override String NextLine()
        {
            return LineTracker.TimeForHeader(this) ? "header 2" : R.NextLine();
        }
    }

    internal class Footer1 : Decorator1
    {
        internal Footer1(Report r) : base(r)
        {
            LineTracker.AddFooterAtEnd(this);
        }

        public override String NextLine()
        {
            return LineTracker.TimeForFooter(this) ? "footer 1" : R.NextLine();
        }
    }

    internal class Footer2 : Decorator1
    {
        internal Footer2(Report r) : base(r)
        {
            LineTracker.AddFooterAtEnd(this);
        }

        public override String NextLine()
        {
            return LineTracker.TimeForFooter(this) ? "footer 2" : R.NextLine();
        }
    }

    public class DecoratorAssignment
    {
        public static void Main1()
        {
            Report r;
            //r = new LineNumber(500);
            //r = new Header1(new LineNumber(500));
            //r = new Header2(new Header1(new LineNumber(500)));
            //r = new CharacterPr(400);
            //r = new Footer1(new CharacterPr(400));
            //r = new Footer2(new Footer1(new CharacterPr(400)));
            r = new Header1(new Header2(new Footer1(new Footer2(new CharacterPr(400)))));
            r.PrintFull();
        }
    }
}