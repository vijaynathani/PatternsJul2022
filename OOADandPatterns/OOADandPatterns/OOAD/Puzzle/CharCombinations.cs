#region

using System;
using System.Collections.Generic;

#endregion

namespace OOAD.Puzzle
{
    internal class CharCombinations
    {
        private const char EmptyChar = '\u0000';
        private readonly HashSet<String> _solution = new HashSet<String>();
            
        public CharCombinations(String characters)
        {
            if (characters.Length > 0)
                AddCombinations(new char[characters.Length], characters);
            
        }

        public HashSet<string> Combinations()
        {
            return _solution;
        }

        private void AddCombinations(Char[] fixedValues, String remainingValues)
        {
            if (remainingValues == "")
            {
                _solution.Add(new string(fixedValues));
                return;
            }
            for (var i = 0; i < fixedValues.Length; ++i)
                if (fixedValues[i] == EmptyChar)
                    FixOneCharacterAndFindRecurseForRemaining(fixedValues, i, remainingValues[0], remainingValues.Substring(1));
        }

        private void FixOneCharacterAndFindRecurseForRemaining(char[] fixedValues, int fixedPosition, 
            char chosenChar, string remainingChars)
        {
            fixedValues[fixedPosition] = chosenChar;
            AddCombinations(fixedValues, remainingChars);
            fixedValues[fixedPosition] = EmptyChar;
        }
    }
}