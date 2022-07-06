using System;
using System.Collections.Generic;
using System.Linq;

namespace OOADandPatterns.Patterns.EightQueen
{
    public class Board
    {
        private readonly HashSet<Cell> _queensPlaced;
        public const int Size = 8;

        public Board(IEnumerable<Cell> initialQueens) => 
            _queensPlaced = new HashSet<Cell>(initialQueens);

        public Board PlaceQueen(Cell position)
        {
            var r = new Board(_queensPlaced);
            r._queensPlaced.Add(position);
            return r;
        }

        public bool NewQueenPositionLaterThanExistingQueens(Cell position)
        {
            return _queensPlaced.All(p => IsLaterThan(position, p));
        }

        private bool IsLaterThan(Cell newPosition, Cell fixedPosition)
        {
            if (newPosition.Row > fixedPosition.Row) return true;
            if (newPosition.Row < fixedPosition.Row) return false;
            return newPosition.Col > fixedPosition.Col;
        }

        public IEnumerable<Cell> QueensPlaced() => _queensPlaced;

        protected bool Equals(Board other) => _queensPlaced.SetEquals(other._queensPlaced);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Board) obj);
        }

        public override int GetHashCode() => _queensPlaced.Select(c => c.GetHashCode()).Sum();

        public override string ToString() => string.Join(",", _queensPlaced);
    }
}
