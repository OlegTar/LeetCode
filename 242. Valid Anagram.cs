/*Given two strings s and t, return true if t is an anagram of s, and false otherwise.

 

Example 1:

Input: s = "anagram", t = "nagaram"

Output: true

Example 2:

Input: s = "rat", t = "car"

Output: false

 

Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.
 

Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?*/
public class Solution {
    public bool IsAnagram(string s, string t) {
        Span<int> lettersS = stackalloc int[26];
        Span<int> lettersT = stackalloc int[26];

        foreach (var ch in s)
        {
            lettersS[ch - 'a']++;
        }

        foreach (var ch in t)
        {
            lettersT[ch - 'a']++;
        }

        for (var i = 0; i < lettersS.Length; i++)
        {
            if (lettersS[i] != lettersT[i])
            {
                return false;
            }
        }
        
        return true;
    }
}
