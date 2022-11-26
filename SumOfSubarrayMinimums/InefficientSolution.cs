public class InefficientSolution
{
    private readonly Dictionary<(int, int), int> _dictionary = new Dictionary<(int, int), int>();
    private long sum = 0;
    public int SumSubarrayMins(int[] arr)
    {
        FindMinOfIntervals(arr, 0, arr.Length - 1);
        return (int)(sum % (Math.Pow(10, 9) + 7));
    }

    private int FindMinOfIntervals(int[] arr, int l, int r)
    {
        if (_dictionary.TryGetValue((l, r), out int existingMin))
        {
            return existingMin;
        }

        if (l == r)
        {
            _dictionary.Add((l, r), arr[l]);
            sum += arr[l];
            //Display(arr, l, r, arr[l]);

            return arr[l];
        }

        var leftMin = FindMinOfIntervals(arr, l, r - 1);
        var rightMin = FindMinOfIntervals(arr, l + 1, r);
        var min = leftMin <= rightMin ? leftMin : rightMin;
        _dictionary.Add((l, r), arr[l]);
        sum += min;
        //Display(arr, l, r, min);

        return min;
    }

    private void Display(int[] arr, int l, int r, int min)
    {
        for (int i = l; i <= r; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.Write("-> " + min);
        Console.WriteLine();
    }
}