public class Solution
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        var sortedStartTime = SortMerge(endTime, 0, startTime.Length - 1);

        var d = new int[sortedStartTime.Length];
        for (int i = 0; i < sortedStartTime.Length; i++)
        {
            var realIndex = sortedStartTime[i].Key;
            d[i] = Math.Max(profit[realIndex], i - 1 >= 0 ? d[i - 1] : int.MinValue);
            for (int j = i - 1; j >= 0; j--)
            {
                var realPreviousIndex = sortedStartTime[j].Key;
                if (startTime[realIndex] >= endTime[realPreviousIndex])
                {
                    d[i] = Math.Max(d[j] + profit[realIndex], d[i]);
                    break;
                }
            }
        }

        return d.Last();
    }

    private KeyValuePair<int, int>[] SortMerge(int[] origin, int l, int r)
    {
        if (l >= r)
        {
            return new KeyValuePair<int, int>[] { new KeyValuePair<int, int>(r, origin[r]) };
        }
        int m = (l + r) / 2;
        var left = SortMerge(origin, l, m);
        var right = SortMerge(origin, m + 1, r);
        var result = new KeyValuePair<int, int>[left.Length + right.Length];
        int i, j, res;
        i = j = res = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i].Value < right[j].Value)
            {
                result[res] = left[i];
                res++;
                i++;
            }
            else
            {
                result[res] = right[j];
                res++;
                j++;
            }
        }
        while (i < left.Length)
        {
            result[res] = left[i];
            res++;
            i++;
        }
        while (j < right.Length)
        {
            result[res] = right[j];
            res++;
            j++;
        }
        return result;
    }
}