using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;

namespace OOADandPatterns.Patterns.GameOfLife
{
    internal class LifeMain
    {
        public static void Main1()
        {
            var board = new GameBoard(ImmutableHashSet.Create<Cell>()
                .Add(new Cell(1, 2)).Add(new Cell(2, 3)).Add(new Cell(3, 1)).Add(new Cell(3, 2)).Add(new Cell(3, 3)).ToImmutableHashSet());
            while (true)
            {
                Console.WriteLine(board);
                board = GameStep.Next(board);
                Thread.Sleep(1000);
            }
        }
    }
}
//Package System.Collections.immutable has been used here.