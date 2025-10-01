

using Snork.AsciiTable;

namespace GameCore
{
    public static class Statistics
    {
        public static void GameStatistics(Rick rick)
        {
            double stayedP = GetEstimateP(rick.rickStayedWins, rick.rickStayedRounds);
            double switchedP = GetEstimateP(rick.rickSwitchedWins, rick.rickSwitchedRounds);
            var table = new AsciiTableGenerator("GAME STATS");
            table.SetCaptions("Game Results", "Rick Switched", "Rick Stayed");
            table.Add("Rounds", rick.rickSwitchedRounds, rick.rickStayedRounds)
            .Add("Wins", rick.rickSwitchedWins, rick.rickStayedWins)
            .Add($"P (estimate)", rick.rickSwitchedRounds != 0 ? $"{switchedP:F3}" : "?", rick.rickStayedRounds != 0 ? $"{stayedP:F3}" : "?")
            .Add("P (exact)", "0.667", "0.333")
            .SetCellAlignment(0, CellAlignmentEnum.Center)
            .SetCellAlignment(1, CellAlignmentEnum.Center)
            .SetCellAlignment(2, CellAlignmentEnum.Center);
            Console.WriteLine(table.ToString());

        }
        private static double GetEstimateP(int wins, int rounds)
        {
            if (wins == 0 || rounds == 0) return 0;
            return wins / rounds;
        }


    }
}
