/*
Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.

An interleaving of two strings s and t is a configuration where s and t are divided into n and m substrings respectively, such that:

s = s1 + s2 + ... + sn
t = t1 + t2 + ... + tm
|n - m| <= 1
The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...
Note: a + b is the concatenation of strings a and b.

 

Example 1:


Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
Output: true
Explanation: One way to obtain s3 is:
Split s1 into s1 = "aa" + "bc" + "c", and s2 into s2 = "dbbc" + "a".
Interleaving the two splits, we get "aa" + "dbbc" + "bc" + "a" + "c" = "aadbbcbcac".
Since s3 can be obtained by interleaving s1 and s2, we return true.
Example 2:

Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
Output: false
Explanation: Notice how it is impossible to interleave s2 with any other string to obtain s3.
Example 3:

Input: s1 = "", s2 = "", s3 = ""
Output: true
 

Constraints:

0 <= s1.length, s2.length <= 100
0 <= s3.length <= 200
s1, s2, and s3 consist of lowercase English letters.
 

Follow up: Could you solve it using only O(s2.length) additional memory space?
*/
func isInterleave(s1 string, s2 string, s3 string) bool {
    if len(s3) == 0 {
        return len(s1) == 0 && len(s2) == 0;
    }

    if len(s1) == 0 {
        return s2 == s3
    }

    if len(s2) == 0 {
        return s1 == s3
    }

    if (len(s1) + len(s2) != len(s3)) {
        return false;
    }

    dp := make([][][]bool, len(s3) + 1)
    for i := 0; i < len(dp); i++ {
        dp[i] = make([][]bool, len(s1) + 1)
        for j := 0; j < len(dp[i]); j++ {
            dp[i][j] = make([]bool, len(s2) + 1)
        }
    }

    dp[len(s3)][len(s1)][len(s2)] = true

    len_s3, len_s1, len_s2 := len(s3), len(s1), len(s2)

    for i := 0; i < len(s1); i++ {
        s3_charFromEnd := len_s3 - i - 1
        s1_charFromEnd := len_s1 - i - 1

        if (s3[s3_charFromEnd] == s1[s1_charFromEnd]) {
            dp[s3_charFromEnd][s1_charFromEnd][len_s2] = true
        } else {
            break;
        }
    }

    for i := 0; i < len(s2); i++ {
        s3_charFromEnd := len_s3 - i - 1
        s2_charFromEnd := len_s2 - i - 1

        if (s3[s3_charFromEnd] == s2[s2_charFromEnd]) {
            dp[s3_charFromEnd][len_s1][s2_charFromEnd] = true
        } else {
            break;
        }
    }

    for i := 0; i < len(s3); i++ {
        for j := 0; j < len(s1); j++ {
            for k := 0; k < len(s2); k++ {
                if s3[len_s3 - 1 - i] == s1[len_s1 - 1 - j] && dp[len_s3 - i][len_s1 - j][len_s2 - 1 - k] {
                    dp[len_s3 - 1 - i][len_s1 - 1 - j][len_s2 - 1 - k] = true
                }

                if s3[len_s3 - 1 - i] == s2[len_s2 - 1 - k] && dp[len_s3 - i][len_s1 - 1 - j][len_s2 - k] {
                    dp[len_s3 - 1 - i][len_s1 - 1 - j][len_s2 - 1 - k] = true
                }
            }
        }
    }

    return dp[0][0][0]
}
