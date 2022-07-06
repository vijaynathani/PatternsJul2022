using System;
using System.IO;
using System.Linq;

namespace OOADandPatterns.Patterns.chainOfResponsibility
{
// Count the type of program lines
    public class SFormatLines
    {
        private static readonly LineType[] AllLineTypes = LineType.All;

        public static void Main1()
        {
            Console.WriteLine(string.Join("\n", 
                File.ReadAllLines("..\\..\\MainProgram.cs")
                    .Select(s => s.Trim())
                    .Select(line => AllLineTypes.First(s => s.IsItMe(line)))
                    .GroupBy(s => s).ToDictionary(s => s.Key, s => s.Count())));
        }
    }
    //Problem located in DesignPatternsParticipants.chainOfResponsibility.QFormatLines
}