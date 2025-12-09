/*Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.

Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.

 

Example 1:

Input: s = "abciiidef", k = 3
Output: 3
Explanation: The substring "iii" contains 3 vowel letters.
Example 2:

Input: s = "aeiou", k = 2
Output: 2
Explanation: Any substring of length 2 contains 2 vowels.
Example 3:

Input: s = "leetcode", k = 3
Output: 2
Explanation: "lee", "eet" and "ode" contain 2 vowels.
 

Constraints:

1 <= s.length <= 105
s consists of lowercase English letters.
1 <= k <= s.length*/
public class Solution {
    public int MaxVowels(string s, int k) {
        var vowels = new HashSet<char>() {'a', 'e', 'i', 'o', 'u'};
        var count = 0;
        for (var i = 0; i < k; i++)
        {
            if (IsVowel(s[i]))
            {
                count++;
            }
        }
        var maxCount = count;

        for (var i = 1; i + k <= s.Length; i++)
        {
            if (IsVowel(s[i - 1]))
            {
                count--;
            }
            if (IsVowel(s[i + k - 1]))
            {
                count++;
            }
            maxCount = Math.Max(maxCount, count);
        }
        return maxCount;

        bool IsVowel(char c)
        {
            return vowels.Contains(c);
        }
    }
}
