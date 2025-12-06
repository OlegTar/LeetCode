/*For two strings s and t, we say "t divides s" if and only if s = t + t + t + ... + t + t (i.e., t is concatenated with itself one or more times).

Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.

 

Example 1:

Input: str1 = "ABCABC", str2 = "ABC"
Output: "ABC"
Example 2:

Input: str1 = "ABABAB", str2 = "ABAB"
Output: "AB"
Example 3:

Input: str1 = "LEET", str2 = "CODE"
Output: ""
 

Constraints:

1 <= str1.length, str2.length <= 1000
str1 and str2 consist of English uppercase letters.*/
public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var sb = new StringBuilder();        
        var i = 0;
        var j = 0;

        while (i < word1.Length || j < word2.Length)
        {
            if (i < word1.Length)
            {
                sb.Append(word1[i++]);
            }

            if (j < word2.Length)
            {
                sb.Append(word2[j++]);
            }
        }

        return sb.ToString();
    }
}
