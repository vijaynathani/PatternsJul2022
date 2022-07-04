using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOADandPatterns.OOAD
{
    public class OptionalTest
    {
        public static void Main1()
        {
            var a = Optional<string>.Of("abc");
            var b = Optional<string>.Of("abc");
            Debug.Assert(a.Equals(b));
            var c = Optional<string>.Empty();
            Debug.Assert(!a.Equals(c));
            Debug.Assert(!c.Equals(Optional<string>.Empty()));
            var d = Optional<string>.Of("xyz");
            Debug.Assert(!d.Equals(a));
            Debug.Assert(a.Get().Equals("abc"));
            Debug.Assert(a.GetHashCode() > 1);
            Debug.Assert(c.GetHashCode() == 1);
            Debug.Assert(a.IsPresent());
            Debug.Assert(!c.IsPresent());
            var n = 1;
            a.IsPresent(s => n = s.Length);
            Debug.Assert(n == 3);
            n = 0;
            c.IsPresent(s => n = 5);
            Debug.Assert(n == 0);
            Debug.Assert(Optional<string>.OfNullable(null).GetHashCode() == 1);
            Debug.Assert(a.OrElse("xyz").Equals("abc"));
            Debug.Assert(c.OrElse("xyz").Equals("xyz"));
            Debug.Assert(a.OrElseGet(() => "pqr").Equals("abc"));
            Debug.Assert(c.OrElseGet(() => "pqr").Equals("pqr"));
            a.OrElseThrow(() => new Exception());
            n = 3;
            Debug.Assert(a.Filter(s => s.Length == 3).Equals(a));
            Debug.Assert(!a.Filter(s => s.Length == 0).IsPresent());
            Debug.Assert(!c.Filter(s => true).IsPresent());
            var g = new StringBuilder("a");
            var f = Optional<StringBuilder>.Of(g);
            Debug.Assert(a.Map(s => g).Get().Equals(g));
            Debug.Assert(!c.Map(s => g).IsPresent());
            Debug.Assert(a.FlatMap(s => f).Equals(f));
           Debug.Assert(!c.FlatMap(s => f).IsPresent());
            

        }
    }
}
