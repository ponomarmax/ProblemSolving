public class SolutionTwoSum
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var (i, j) = (0, numbers.Length - 1);
        while (true)
        {
            var sum = numbers[i] + numbers[j];
            if (sum == target)
                return new int[] { i + 1, j + 1 };
            if (sum < target)
            {
                i++;
                continue;
            }
            j--;
        }
    }
}