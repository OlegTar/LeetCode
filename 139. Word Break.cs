/*Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.

Note that the same word in the dictionary may be reused multiple times in the segmentation.

 

Example 1:

Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".
Example 2:

Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
Note that you are allowed to reuse a dictionary word.
Example 3:

Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false
 

Constraints:

1 <= s.length <= 300
1 <= wordDict.length <= 1000
1 <= wordDict[i].length <= 20
s and wordDict[i] consist of only lowercase English letters.
All the strings of wordDict are unique.*/
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        bool[] dp = new bool[s.Length + 1];
        foreach (var word in wordDict)
        {
            if (word.Length <= s.Length && s[0..word.Length] == word)
            {
                dp[word.Length] = true;
            }
        }

        for (var i = 0; i < dp.Length; i++)
        {
            if (!dp[i])
            {
                continue;
            }

            foreach (var word in wordDict)
            {
                if (i + word.Length <= s.Length && s[i..(i + word.Length)] == word)
                {
                    dp[i + word.Length] = true;
                }
            }
        }

        return dp[s.Length];
    }
}
