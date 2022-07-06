using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace OOADandPatterns.Patterns.GameOfLife
{
    internal class GameBoard
    {
        public const char Live = 'X', Dead = ' ';

        public GameBoard(ImmutableHashSet<Cell> live)
        {
            LiveCells = live;
        }

        public ImmutableHashSet<Cell> LiveCells { get; }

        private string PrintRow(int row, int minCol, int maxCol)
        {
            var sb = new StringBuilder();
            for (var j = minCol; j <= maxCol; ++j)
                sb.Append(LiveCells.Contains(new Cell(row, j)) ? Live : Dead);
            sb.Append('\n');
            return sb.ToString();
        }

        public override string ToString()
        {
            var r = new StringBuilder("GameBoard:\n");
            var minCol = BoardSize.GetMinCol(LiveCells);
            var maxCol = BoardSize.GetMaxCol(LiveCells);
            var maxRow = BoardSize.GetMaxRow(LiveCells);
            for (var i = BoardSize.GetMinRow(LiveCells); i <= maxRow; ++i)
                r.Append(PrintRow(i, minCol, maxCol));
            return r.ToString();
        }
    }
}