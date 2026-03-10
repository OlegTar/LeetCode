/*
Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

 

Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
Example 2:

Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
 

Constraints:

1 <= haystack.length, needle.length <= 104
haystack and needle consist of only lowercase English characters.
*/
func strStr(haystack string, needle string) int {
    if len(needle) > len(haystack) {
        return -1
    }

    for i := 0; i < len(haystack); i++ {
        found := true;
        for j := 0; j < len(needle); j++ {
            if (i + j) >= len(haystack) || needle[j] != haystack[i + j] {
                found = false
                break
            }
        }
        if found {
            return i
        }
    }
    return -1;
}
