public partial class Solution
{
    public int OrangesRotting(int[][] mat)
    {
        var neigbourPos = new int[] { 0, 1, 0, -1, 0 };
        var rottedOranges = new List<(int, int)>();
        var rottedHashOranges = new HashSet<(int, int)>();
        var normalOranges = new HashSet<(int, int)>();
        for (int i = 0; i < mat.Length; ++i)
        {
            for (int j = 0; j < mat[0].Length; ++j)
            {
                if (mat[i][j] == 2)
                {
                    rottedOranges.Add((i, j));
                    rottedHashOranges.Add((i, j));
                }
                else if (mat[i][j] == 1)
                    normalOranges.Add((i, j));
            }
        }
        var offset = 0;
        var counter = 0;
        while (true)
        {
            var currentRottedOrangesAmount = rottedOranges.Count;
            for (int i = offset; i < currentRottedOrangesAmount; ++i)
            {
                var rottedOrange = rottedOranges[i];
                for (int j = 0; j < neigbourPos.Length - 1; ++j)
                {
                    var supposedPoint = (rottedOrange.Item1 + neigbourPos[j], rottedOrange.Item2 + neigbourPos[j + 1]);
                    if (normalOranges.Remove(supposedPoint))
                    {
                        if (rottedHashOranges.Add(supposedPoint))
                            rottedOranges.Add(supposedPoint);
                    }
                }
            }
            offset = currentRottedOrangesAmount;
            if (offset < rottedOranges.Count) ++counter;
            else break;
        }

        return normalOranges.Any() ? -1 : counter;
    }
}

public partial class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        var result = new int[mat.Length][];
        var maxValue = int.MaxValue - 100000;

        for (int i = 0; i < mat.Length; ++i)
        {
            result[i] = new int[mat[0].Length];
            for (int j = 0; j < mat[0].Length; ++j)
            {
                result[i][j] = maxValue;
            }
        }

        for (int i = 0; i < mat.Length; ++i)
        {
            for (int j = 0; j < mat[0].Length; ++j)
            {
                if (mat[i][j] == 0)
                    result[i][j] = 0;
                else
                {
                    if (i > 0)
                        result[i][j] = Math.Min(result[i - 1][j] + 1, result[i][j]);
                    if (j > 0)
                        result[i][j] = Math.Min(result[i][j - 1] + 1, result[i][j]);
                }
            }
        }

        for (int i = mat.Length - 1; i >= 0; --i)
        {
            for (int j = mat[0].Length - 1; j >= 0; --j)
            {
                if (i < mat.Length - 1)
                    result[i][j] = Math.Min(result[i + 1][j] + 1, result[i][j]);
                if (j < mat[0].Length - 1)
                    result[i][j] = Math.Min(result[i][j + 1] + 1, result[i][j]);
            }
        }
        return result;
    }
}