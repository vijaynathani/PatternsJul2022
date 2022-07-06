#region

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace OOAD.Puzzle
{
    [TestFixture]
    public class CharCombinationsTest
    {
        private String _chosenString;
        private HashSet<String> _expectedSolution;
        private void BuildSolutionSet(params string[] values)
        {
            _expectedSolution = new HashSet<String>(new List<String>(values));
        }
        private void VerifyAnswer()
        {
            var answerWords = new CharCombinations(_chosenString).Combinations();
            Assert.That(answerWords.SetEquals(_expectedSolution), Is.True);
        }

        [Test]
        public void ZeroCharacterTest()
        {
            _chosenString = "";
            BuildSolutionSet();
            VerifyAnswer();
        }

        [Test]
        public void OneCharacterTest()
        {
            _chosenString = "a";
            BuildSolutionSet("a");
            VerifyAnswer();
        }

        [Test]
        public void TwoCharacterTest()
        {
            _chosenString = "ab";
            BuildSolutionSet("ab", "ba");
            VerifyAnswer();
        }

        [Test]
        public void ThreeCharacterTest()
        {
            _chosenString = "abc";
            BuildSolutionSet("abc", "acb", "bac", "bca", "cab", "cba");
            VerifyAnswer();
        }
    }
}