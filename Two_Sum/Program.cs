internal class Program
{
    private static void Main(string[] args)
    {
        var test = new SolutionWithHash();
        var result = test.TwoSum(new int[] { 3, 2, 4 }, 6);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}
