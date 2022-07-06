using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.EightQueen
{
    public class Cell
    {

        private readonly byte _row;
        private readonly byte _col;


        public Cell(int row, int col)
        {
            this._row = (byte)row;
            this._col = (byte)col;
        }

        public override string ToString() => $"Cell(Row:{_row}, Col:{_col})";

        protected bool Equals(Cell other) => _row == other._row && _col == other._col;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cell) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_row * 17) ^ _col;
            }
        }

        public int Row => _row;

        public int Col => _col;

        public static bool IsValid(int rowCol) => rowCol >= 0 && rowCol < Board.Size;

    }
}
