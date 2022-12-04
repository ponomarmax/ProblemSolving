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

public partial class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        var alphabet = new char[26];

        for (int i = 0; i < s1.Length; i++)
        {
            alphabet[s1[i] - 'a']++;
        }

        var temp = new char[26];


        for (int i = 0; i < s2.Length - s1.Length + 1; i++)
        {
            Array.Copy(alphabet, temp, alphabet.Length);

            for (int j = i; j < s1.Length + i; j++)
            {
                temp[s2[j] - 'a']--;
            }
            var result = true;
            for (int k = 0; k < temp.Length; k++)
            {
                if (temp[k] != 0)
                {
                    result = false;
                    break;
                }
            }
            if (result) return true;
        }
        return false;
    }
}