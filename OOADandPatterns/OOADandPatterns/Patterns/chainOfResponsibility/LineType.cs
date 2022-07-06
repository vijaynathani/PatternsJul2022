using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.chainOfResponsibility
{
    public class LineType
    {
        public static LineType[] All
        {
            get
            {
                return new LineType[]
                {
                    new LineType(s => s.StartsWith("//"), "Comment"), 
                    new LineType(string.IsNullOrEmpty, "Blank"), 
                    new LineType(s => s.StartsWith("using"), "Using"), 
                    new LineType(s => true, "Code")
                };
            }
        }

        public readonly Predicate<string> IsItMe;
        private readonly string _description;

        private LineType(Predicate<string> isItMe, string description)
        {
            this.IsItMe = isItMe;
            _description = description;
        }

        public override string ToString()
        {
            return string.Format(_description);
        }
    }
}
