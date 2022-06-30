using System.Collections.Generic;
using System.Linq;

namespace LearnCS.ooad
{
    internal class S61
    {
        public const int Size = 3, Empty = 0, Cross = 1, Circle = 2;
        private readonly IDictionary<int, IDictionary<int, int>> board = new Dictionary<int, IDictionary<int, int>>();

        public S61()
        {
            for (int r = 0; r < Size; ++r)
            {
                board.Add(r, new Dictionary<int, int>());
                for (int c = 0; c < Size; ++c)
                    board[r].Add(c, Empty);
            }
        }

        public void PutX(int r, int c)
        {
            board[r][c] = Cross;
        }

        public void PutO(int r, int c)
        {
            board[r][c] = Circle;
        }

        public bool IsEmpty(int r, int c)
        {
            return board[r][c] == Empty;
        }

        public bool IsOver()
        {
            return TableChecker.LeftDiagnalFilledWithSameElements(board)
                   || TableChecker.RightDiagonalFilledWithSameElements(board)
                   || TableChecker.AnyRowFilledWithSameElements(board)
                   || TableChecker.AnyColumnFilledWithSameElements(board)
                   || TableChecker.AllElementsNonZero(board);
        }
    }

    internal class TableChecker
    {
        private static bool EnsureOneNonZeroValuePresentInSet(HashSet<int> values)
        {
            return !values.Contains(S61.Empty) && (values.Count == 1);
        }

        public static bool LeftDiagnalFilledWithSameElements(IDictionary<int, IDictionary<int, int>> table)
        {
            var v = new HashSet<int>();
            int max = table.Keys.Max();
            for (int i = 0; i < max; ++i)
                v.Add(table[i][i]);
            return EnsureOneNonZeroValuePresentInSet(v);
        }

        public static bool RightDiagonalFilledWithSameElements(IDictionary<int, IDictionary<int, int>> table)
        {
            var v = new HashSet<int>();
            int max = table.Keys.Max();
            for (int i = 0; i < max; ++i)
                v.Add(table[i][max - i]);
            return EnsureOneNonZeroValuePresentInSet(v);
        }

        private static bool AreMapValuesEqualButNotZero(IDictionary<int, int> mv)
        {
            return EnsureOneNonZeroValuePresentInSet(new HashSet<int>(
                                                         mv.Values));
        }

        public static bool AnyRowFilledWithSameElements(IDictionary<int, IDictionary<int, int>> table)
        {
            return table.Keys.Any(r => AreMapValuesEqualButNotZero(table[r]));
        }

        private static IDictionary<int, IDictionary<int, int>> InvertTable(IDictionary<int, IDictionary<int, int>> table)
        {
            IDictionary<int, IDictionary<int, int>> inv = new Dictionary<int, IDictionary<int, int>>();
            foreach (int r in table.Keys)
                foreach (int c in table[r].Keys)
                {
                    int value = table[r][c];
                    if (!inv.ContainsKey(c)) inv.Add(c, new Dictionary<int, int>());
                    inv[c].Add(r, value);
                }
            return inv;
        }

        public static bool AnyColumnFilledWithSameElements(IDictionary<int, IDictionary<int, int>> table)
        {
            return AnyRowFilledWithSameElements(InvertTable(table));
        }

        public static bool AllElementsNonZero(IDictionary<int, IDictionary<int, int>> table)
        {
            var v = new HashSet<int>();
            foreach (int r in table.Keys)
                foreach (int c in table[r].Keys)
                    v.Add(table[r][c]);
            return !v.Contains(0);
        }
    }
	//A better design would have a class Table<int,int,int> instead of
	//IDictionary<int, IDictionary<int, int>> table
}