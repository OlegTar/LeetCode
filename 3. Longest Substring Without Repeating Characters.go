/*Given a string s, find the length of the longest substring without duplicate characters.

 

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3. Note that "bca" and "cab" are also correct answers.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.*/
func lengthOfLongestSubstring(s string) int {
    runes := []rune(s)
    used := make(map[rune]struct{})

    resultLen := 0;
    left := 0;
    for right := 0; right < len(runes); right++ {
        if _, ok := used[runes[right]]; ok {
            for runes[left] != runes[right] {
                delete(used, runes[left])
                left++
            }

            left++
        } else {
            used[runes[right]] = struct{}{}
            resultLen = max(resultLen, right - left + 1)
        }
    }

    return resultLen;
}
