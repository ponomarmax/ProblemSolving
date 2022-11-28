public class Solution
{
    public int Search(int[] nums, int target)
    {
        return BinarySearch(nums, 0, nums.Length - 1, target);
    }

    private int BinarySearch(int[] nums, int l, int r, int target)
    {
        if (l > r)
            return -1;
        var mid = (l + r) / 2;

        if (target == nums[mid])
            return mid;
        if (target < nums[mid])
            return BinarySearch(nums, l, mid - 1, target);

        return BinarySearch(nums, mid + 1, r, target);
    }
}