/*
Given two strings s and t, return true if t is an anagram of s, and false otherwise.

 

Example 1:

Input: s = "anagram", t = "nagaram"

Output: true

Example 2:

Input: s = "rat", t = "car"

Output: false

 

Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.
 

Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
*/
func isAnagram(s string, t string) bool {
    lettersS := [26]int{}
    lettersT := [26]int{}

    for _, r := range(s) {
        lettersS[r - 'a']++
    }

    for _, r := range(t) {
        lettersT[r - 'a']++
    }

    for i := 0; i < len(lettersS); i++ {
        if lettersS[i] != lettersT[i] {
            return false;
        }
    }

    return true;
}
