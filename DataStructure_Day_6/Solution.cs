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

public partial class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var countLetterInMagazine = new Dictionary<char, int>();
        for (int i = 0; i < magazine.Length; i++)
        {
            if (!countLetterInMagazine.TryAdd(magazine[i], 1))
            {
                countLetterInMagazine[magazine[i]] += 1;
            }
        }

        for (int i = 0; i < ransomNote.Length; i++)
        {
            if (countLetterInMagazine.TryGetValue(ransomNote[i], out _))
            {
                countLetterInMagazine[ransomNote[i]] -= 1;
                if (countLetterInMagazine[ransomNote[i]] < 0)
                    return false;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}