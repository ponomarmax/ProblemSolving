public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var (l, r) = (0, matrix.Length - 1);
        while (l <= r)
        {
            var m = (l + r) / 2;
            if (matrix[m][0] <= target)
            {
                if (target <= matrix[m][^1])
                    return Array.BinarySearch(matrix[m], target) >= 0;
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }
        return false;
    }
}