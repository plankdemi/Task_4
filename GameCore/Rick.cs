public class Rick
{
    public int rickSwitchedWins { get; set; } = 0;
    public int rickStayedWins { get; set; } = 0;
    public int rickStayedRounds { get; set; } = 0;
    public int rickSwitchedRounds { get; set; } = 0;
    public int rounds { get; set; } = 0;
    public List<int> rickValues { get; set; } = new();

    public void switchedRickWin()
    {
        rickSwitchedWins++;

    }
    public void stayedRickWin()
    {
        rickStayedWins++;
    }
    public void switchedRickRound()
    {
        rickSwitchedRounds++;
    }
    public void stayedRickRound()
    {
        rickStayedRounds++;
    }
    public void RoundsPlayed()
    {
        rounds++;
    }

}