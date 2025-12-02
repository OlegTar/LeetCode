/*
Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".

The testcases will be generated such that the answer is unique.

 

Example 1:

Input: s = "ADOBECODEBANC", t = "ABC"
Output: "BANC"
Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
Example 2:

Input: s = "a", t = "a"
Output: "a"
Explanation: The entire string s is the minimum window.
Example 3:

Input: s = "a", t = "aa"
Output: ""
Explanation: Both 'a's from t must be included in the window.
Since the largest window of s only has one 'a', return empty string.
 

Constraints:

m == s.length
n == t.length
1 <= m, n <= 105
s and t consist of uppercase and lowercase English letters.
 

Follow up: Could you find an algorithm that runs in O(m + n) time?
*/
public class Solution {
    public string MinWindow(string s, string t) {
        if (s.Length < t.Length)
        {
            return "";
        }

        var counts = t.GroupBy(c => c).ToDictionary(gr => gr.Key, gr => gr.Count());
        var left = 0;
        var right = 0;

        var windowCount = new Dictionary<char, int>();
        while (right < s.Length && !Covered(windowCount, counts))
        {
            var chr = s[right++];
            if (!windowCount.ContainsKey(chr))
            {
                windowCount[chr] = 0;
            }
            windowCount[chr]++;            
        }
        
        if (!Covered(windowCount, counts))
        {
            return "";
        }

        right--;
        var resultLeft = left;
        var resultRight = right;

        while (left < s.Length && left <= right && right < s.Length)
        {
            var chr = s[left++];
            if (windowCount.ContainsKey(chr))
            {
                windowCount[chr]--;
            }

            if (!Covered(windowCount, counts))
            {
                if (right == s.Length - 1)
                {
                    break;
                }
                
                while (++right < s.Length && !Covered(windowCount, counts))
                {
                    chr = s[right];
                    if (!windowCount.ContainsKey(chr))
                    {
                        continue;
                    }
                    windowCount[chr]++;                    
                }

                if (!Covered(windowCount, counts))
                {
                    break;
                }
                right--;
            }
            else 
            {
                if ((right - left) < (resultRight - resultLeft))
                {
                    resultLeft = left;
                    resultRight = right;
                }
            }
        }

        return s[resultLeft..(resultRight + 1)];
    }

    public bool Covered(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
    {
        if (dict1.Keys.Count < dict2.Keys.Count)
        {
            return false;
        }
        
        foreach (var chr in dict2.Keys)
        {
            if (!dict1.ContainsKey(chr))
            {
                return false;
            }
            
            if (dict1[chr] < dict2[chr])
            {
                return false;
            }
        }

        return true;
    }
}
