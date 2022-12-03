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

public partial class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var letters = new char[26];
        for (int i = 0; i < s.Length; i++)
            letters[s[i] - 'a']++;

        for (int i = 0; i < t.Length; i++)
            letters[t[i] - 'a']--;

        for (int i = 0; i < letters.Length; i++)
            if (letters[i] != 0) return false;
        return true;
    }
}