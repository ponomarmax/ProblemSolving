public partial class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var dict = new Dictionary<int, int>();
        var res = new List<int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            if (!dict.TryAdd(nums1[i], 1))
            {
                dict[nums1[i]]++;
            }
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (dict.TryGetValue(nums2[i], out _))
            {
                if (--dict[nums2[i]] >= 0)
                {
                    res.Add(nums2[i]);
                }
            }
        }
        return res.ToArray();
    }
}

public partial class Solution
{
    public int MaxProfit(int[] prices)
    {
        int lastMinElem = prices.First();
        var maxProfit = 0;
        var sum = new int[prices.Length];
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] > lastMinElem)
            {
                var profit = prices[i] - lastMinElem;
                if (profit > maxProfit)
                {
                    maxProfit = profit;
                }
            }
            else
            {
                lastMinElem = prices[i];
            }
        }
        return maxProfit;
    }
}

public partial class Solution
{
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        if (r * c != mat.Length * mat[0].Length)
            return mat;
        var res = new int[r][];
        for (int i = 0; i < r; i++)
        {
            res[i] = new int[c];
        }
        var n = r * c;
        for (int i = 0; i < n; i++)
        {
            res[i / c][i % c] = mat[i / mat[0].Length][i % mat[0].Length];
        }
        return res;
    }
}

public partial class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var res = new List<IList<int>>(numRows);
        res.Add(new int[] { 1 });
        if (numRows == 1) { return res; }
        for (int i = 1; i < numRows; i++)
        {
            res.Add(new int[i + 1]);
            res[i][0] = res[i][^1] = 1;
            for (int j = 1; j <= i - 1; j++)
            {
                res[i][j] = res[i - 1][j - 1] + res[i - 1][j];
            }
        }
        return res;
    }
}