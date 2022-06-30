using System;
using System.Collections.Generic;

namespace LearnCS.ooad
{
    public class Game
    {
        public const int Size = 3, Empty = 0, Cross = 1, Circle = 2;
        private readonly IDictionary<int, IDictionary<int, int>> _board = new Dictionary<int, IDictionary<int, int>>();

        public Game()
        {
            for (int r = 0; r < Size; ++r)
            {
                _board.Add(r, new Dictionary<int, int>());
                for (int c = 0; c < Size; ++c)
                    _board[r].Add(c, Empty);
            }
        }

        public void PutX(int r, int c)
        {
            _board[r][c] = Cross;
        }

        public void PutO(int r, int c)
        {
            _board[r][c] = Circle;
        }

        public bool IsEmpty(int r, int c)
        {
            return _board[r][c] == Empty;
        }

        public bool IsOver()
        {
            /* The game is over, if any of the following condition is true
		   - The board is filled
		   - Any row is filled with same element
		   - Any column is filled with same element
		   - The left or right diagonal is filled with same element.
		   */
           throw new Exception("To be done");
        }
    }

//Complete the function isOver using functional programming techniques.
}