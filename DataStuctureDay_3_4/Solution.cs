﻿public partial class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var dict = new Dictionary<int, int>();
        var res = new List<int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            if (!dict.TryAdd(nums1[i], 1))
            {
                dict[nums1[i]] ++;
            }
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (dict.TryGetValue(nums2[i], out _))
            {
                if (--dict[nums2[i]] >= 0)
                {
                    res.Add(nums2[i]);
                }
            }
        }
        return res.ToArray();
    }
}