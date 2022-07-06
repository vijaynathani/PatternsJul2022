using System.Collections.Generic;
using System.Linq;

namespace OOADandPatterns.Patterns.GameOfLife
{
    internal class BoardSize
    {
        public static int GetMinRow(IEnumerable<Cell> cells)
        {
            return cells.Select(c => c.Row).Min();
        }

        public static int GetMaxRow(IEnumerable<Cell> cells)
        {
            return cells.Select(c => c.Row).Max();
        }

        public static int GetMinCol(IEnumerable<Cell> cells)
        {
            return cells.Select(c => c.Col).Min();
        }

        public static int GetMaxCol(IEnumerable<Cell> cells)
        {
            return cells.Select(c => c.Col).Max();
        }
    }
}