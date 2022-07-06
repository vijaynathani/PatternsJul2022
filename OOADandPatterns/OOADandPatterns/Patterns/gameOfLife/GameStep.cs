using System.Collections.Generic;
using System.Collections.Immutable;

namespace OOADandPatterns.Patterns.GameOfLife
{
    internal class GameStep
    {
        private readonly ImmutableHashSet<Cell> _cells;
        private readonly Dictionary<Cell, int> _neighbours = new Dictionary<Cell, int>();
        private readonly HashSet<Cell> _newCells = new HashSet<Cell>();

        private GameStep(ImmutableHashSet<Cell> liveCells)
        {
            _cells = liveCells;
        }

        private void IncrementForPosition(int row, int col)
        {
            var c = new Cell(row, col);
            var newValue = _neighbours.ContainsKey(c) ? _neighbours[c] + 1 : 1;
            _neighbours[c] = newValue;
        }

        private void UpdateNeighbours(Cell c)
        {
            for (var row = -1; row <= 1; ++row)
            for (var col = -1; col <= 1; ++col)
                if (row != 0 || col != 0)
                    IncrementForPosition(c.Row + row, c.Col + col);
        }

        private void AddToNewCells(Cell c, int liveNeighbours)
        {
            if (GameRules.IsCellAlive(liveNeighbours, _cells.Contains(c)))
                _newCells.Add(c);
        }

        private GameBoard NextStep()
        {
            foreach (var c in _cells)
                UpdateNeighbours(c);
            foreach (var en in _neighbours)
                AddToNewCells(en.Key, en.Value);
            return new GameBoard(ImmutableHashSet.ToImmutableHashSet(_newCells));
        }

        public static GameBoard Next(GameBoard g)
        {
            return new GameStep(g.LiveCells).NextStep();
        }
    }
}