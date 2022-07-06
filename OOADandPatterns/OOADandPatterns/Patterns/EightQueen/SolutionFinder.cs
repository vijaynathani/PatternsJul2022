using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOAD.Puzzle;

namespace OOADandPatterns.Patterns.EightQueen
{
    class SolutionFinder
    {
        private readonly HashSet<Board> _answers = new HashSet<Board>();

        public void Solve(int queenToBePlaced, Board b)
        {
            if (queenToBePlaced > Board.Size)
            {
                _answers.Add(b);
                return;
            }

            foreach (var s in Threatened.FreeOfDanger(b.QueensPlaced())) 
                if (b.NewQueenPositionLaterThanExistingQueens(s))
                    Solve(queenToBePlaced + 1, b.PlaceQueen(s));
        }

        public static void Main1()
        {
            var solution = new SolutionFinder();
            solution.Solve(1, new Board(new List<Cell>()));
            Console.WriteLine($"Total solutions are {solution._answers.Count}");
            //foreach (var b in solution._answers)
            //{
            //    Console.WriteLine(b);
            //    Console.WriteLine("-------------");
            //}
         }
    }
}
