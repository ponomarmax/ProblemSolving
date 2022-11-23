public class SolutionWithHash
{
    public int[] TwoSum(int[] nums, int target)
    {
        var hasTable = new HashSet<int>(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (hasTable.TryGetValue(target - nums[i], out int res))
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == res)
                    {
                        return new int[] { i, j };
                    }
                }
            }
        }
        return new int[] { -1, -1 };
    }
}