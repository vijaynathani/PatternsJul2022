using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOADandPatterns.Patterns.EightQueen.Board;

namespace OOADandPatterns.Patterns.EightQueen
{
    class Threatened
    {
        private static readonly HashSet<Cell> AllCells = new HashSet<Cell>();
        readonly HashSet<Cell> _currentlyFree = new HashSet<Cell>(AllCells);

        static Threatened()
        {
            for (var row = 0; row < Size; row++)
            for (var col = 0; col < Size; col++)
                AllCells.Add(new Cell(row, col));
        }

        private void RemoveCellsInDirection(int rowIncrement, int colIncrement, Cell startPosition)
        {
            if (rowIncrement == 0 && colIncrement == 0) return;
            for (int r = startPosition.Row + rowIncrement, c = startPosition.Col + colIncrement; 
                        Cell.IsValid(r) && Cell.IsValid(c); r += rowIncrement, c += colIncrement)
                _currentlyFree.Remove(new Cell(r, c));
        }

        private void RemoveThreatenedCells(Cell queen)
        {
            _currentlyFree.Remove(new Cell(queen.Row, queen.Col));
            for (var row = -1; row <= 1; row++)
                for (var col = -1; col <= 1; col++)
                    RemoveCellsInDirection(row, col, queen);
        }

        public static HashSet<Cell> FreeOfDanger(IEnumerable<Cell> queens)
        {
            var r = new Threatened();
            foreach (var q in queens)
                r.RemoveThreatenedCells(q);
            return r._currentlyFree;
        }
    }
}
