public class SolutionWithBinarySearch
{
    public int[] TwoSum(int[] nums, int target)
    {
        var sorted = Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            var elem = sorted[i];
            var position = BinarySearch(sorted, i + 1, nums.Length - 1, target - elem.Value);
            if (position > -1)
            {
                if (elem.Key < sorted[position].Key)
                    return new int[] { elem.Key, sorted[position].Key };
                return new int[] { sorted[position].Key, elem.Key };
            }
        }
        return new int[] { -1, -1 };
    }

    private KeyValuePair<int, int>[] Sort(int[] nums)
    {
        return SortMerge(nums, 0, nums.Length - 1);

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

    private int BinarySearch(KeyValuePair<int, int>[] nums, int l, int r, int target)
    {
        if (l > r)
        {
            return -1;
        }
        var middle = (l + r) / 2;
        if (nums[middle].Value == target)
        {
            return middle;
        }

        if (nums[middle].Value < target)
        {

            return BinarySearch(nums, middle + 1, r, target);
        }
        else
        {
            return BinarySearch(nums, l, middle - 1, target);
        }
    }
}