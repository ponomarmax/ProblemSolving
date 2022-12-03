public partial class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var hash = new HashSet<char>();
        var tailPointer = 0;
        var temporalMax = 0;
        var globalMax = 0;
        int i = 0;
        while (i < s.Length)
        {
            if (hash.Add(s[i]))
            {
                temporalMax++;
                i++;
                if (temporalMax > globalMax)
                    globalMax = temporalMax;
            }
            else
            {
                hash.Remove(s[tailPointer]);
                temporalMax--;
                tailPointer++;
            }
        }
        return globalMax;
    }
}