public class Solution
{
    public int SumSubarrayMins(int[] arr)
    {
        var stack = new Stack<int>();
        long[] sum = new long[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            while (stack.Count > 0 && arr[stack.Peek()] > arr[i])
            {
                stack.Pop();
            }

            var j = stack.Count > 0 ? stack.Peek() : -1;
            stack.Push(i);
            sum[i] = (j >= 0 ? sum[j] : 0) + (i - j) * arr[i];
        }
        return (int)(sum.Sum() % (Math.Pow(10, 9) + 7));
    }
}