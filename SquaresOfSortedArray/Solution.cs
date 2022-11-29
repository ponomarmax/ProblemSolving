public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        var result = new int[nums.Length];
        var (j, k) = (0, nums.Length - 1);
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (Math.Abs(nums[j]) > Math.Abs(nums[k]))
            {
                result[i] = nums[j] * nums[j];
                j++;
            }
            else
            {
                result[i] = nums[k] * nums[k];
                k--;
            }
        }

        return result;
    }
}