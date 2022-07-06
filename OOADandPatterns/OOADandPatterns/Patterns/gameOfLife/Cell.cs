namespace OOADandPatterns.Patterns.GameOfLife
{
    internal class Cell
    {
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; }
        public int Col { get; }

        protected bool Equals(Cell other)
        {
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Cell) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Row)}: {Row}, {nameof(Col)}: {Col}";
        }
    }
}