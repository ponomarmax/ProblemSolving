public partial class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int firstInRange = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                (nums[i], nums[firstInRange]) = (nums[firstInRange], nums[i]);
                firstInRange++;
            }
        }
    }
}