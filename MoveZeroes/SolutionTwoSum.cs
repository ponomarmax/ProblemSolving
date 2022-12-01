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

public partial class Solution
{
    public void ReverseString(char[] s)
    {
        var (i, j) = (0, s.Length - 1);
        while (i < j)
        {
            (s[i], s[j]) = (s[j], s[i]);
            i++;
            j--;
        }
    }
}

public partial class Solution
{
    public string ReverseWords(string s)
    {
        if (s.Length < 2)
        {
            return s;
        }
        var res = new char[s.Length];
        var (i, j, k) = (0, 1, 0);
        while (j < s.Length)
        {
            if (s[j] == ' ' || j + 1 == s.Length)
            {
                k = j;
                if (s[j] == ' ')
                {
                    res[j] = ' ';
                    j--;
                }
                else
                {
                    k++;
                }

                while (i < k)
                {
                    res[i] = s[j];
                    i++;
                    j--;
                }
                i = j = ++k;
                continue;
            }
            j++;
        }
        return new string(res);
    }
}