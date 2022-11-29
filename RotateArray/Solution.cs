/*
 * 977. Squares of a Sorted Array
 * https://leetcode.com/problems/squares-of-a-sorted-array
 */
public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        if (k % nums.Length == 0)
            return;
        int index = 0;
        int firstIndex = 0;
        int previousElem = nums[0];
        int nextElem;
        int nextIndex = (index + k) % nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            nextElem = nums[nextIndex];
            nums[nextIndex] = previousElem;
            index = nextIndex;
            if (nextIndex == firstIndex)
            {
                nextIndex = (index + 1 + k) % nums.Length;
                firstIndex++;
                previousElem = nums[index + 1];
            }
            else
            {
                nextIndex = (index + k) % nums.Length;
                previousElem = nextElem;
            }

        }
    }
}