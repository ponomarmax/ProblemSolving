public partial class Solution
{
    public int FirstUniqChar(string s)
    {
        var hash = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!hash.TryAdd(s[i], i))
            {
                hash[s[i]] = s.Length;
            }
        }
        var min = hash.Min(x => x.Value);
        return min == s.Length ? -1 : min;
    }
}