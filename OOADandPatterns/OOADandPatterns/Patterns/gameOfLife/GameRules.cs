namespace OOADandPatterns.Patterns.GameOfLife
{
    internal class GameRules
    {
        public static bool IsCellAlive(int neighbourCount, bool oldCellLive)
        {
            return neighbourCount == 3 || neighbourCount == 2 && oldCellLive;
        }
    }
}