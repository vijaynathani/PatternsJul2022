using System;

namespace OOAD.Puzzle
{
    internal class Main1
    {
        public static void MainPuzzle()
        {
            Console.WriteLine("Enter the characters: ");
            var chars = Console.ReadLine();
            foreach (var word in (new CharCombinations(chars)).Combinations())
                Console.WriteLine(word);
        }
    }
}