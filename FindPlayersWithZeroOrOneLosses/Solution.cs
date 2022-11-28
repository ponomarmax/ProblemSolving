public class Solution
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var winners = new HashSet<int>();
        var losers = new Dictionary<int, int>();

        foreach (var match in matches)
        {
            if (losers.TryGetValue(match.First(), out _))
                winners.Remove(match.First());
            else
                winners.Add(match.First());

            if (losers.TryGetValue(match.Last(), out _))
                losers[match.Last()]++;
            else
                losers.Add(match.Last(), 1);

            winners.Remove(match.Last());
        }

        return new List<IList<int>>{  winners.OrderBy(x=>x).ToList(),
            losers.Where(x=>x.Value==1).Select(x=>x.Key).OrderBy(x=>x).ToList() };
    }
}