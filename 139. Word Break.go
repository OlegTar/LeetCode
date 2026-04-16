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
import "strings"
func wordBreak(s string, wordDict []string) bool {
    cache := map[string]bool{}
    for _, word := range(wordDict) {
        cache[word] = true
    }
    return solve(s, wordDict, cache)
}

func solve(s string, wordDict []string, cache map[string]bool) bool {
    if len(s) == 0 {
        return true
    }

    if _, ok := cache[s]; ok {
        return cache[s]
    }

    result := false
    for _, word := range(wordDict) {
        if (strings.HasPrefix(s, word)) {
            secondString := s[len(word):]
            result = solve(secondString, wordDict, cache)
            if (result) {
                break;
            }
        }
    }

    cache[s] = result
    return result   
}
