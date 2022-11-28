using System.Text.RegularExpressions;

public class Solution
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var matchCounter = new Dictionary<int, int>();

        foreach (var match in matches)
        {
            matchCounter.TryAdd(match.First(), 0);

            if (!matchCounter.TryAdd(match.Last(), 1))
                matchCounter[match.Last()]++;
        }

        return new List<IList<int>>{  matchCounter.Where(x=>x.Value==0).Select(x=>x.Key).OrderBy(x=>x).ToList(),
            matchCounter.Where(x=>x.Value==1).Select(x=>x.Key).OrderBy(x=>x).ToList() };
    }
}