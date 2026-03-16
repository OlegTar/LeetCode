/*Given two strings s and t, determine if they are isomorphic.

Two strings s and t are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character, but a character may map to itself.

 

Example 1:

Input: s = "egg", t = "add"

Output: true

Explanation:

The strings s and t can be made identical by:

Mapping 'e' to 'a'.
Mapping 'g' to 'd'.
Example 2:

Input: s = "f11", t = "b23"

Output: false

Explanation:

The strings s and t can not be made identical as '1' needs to be mapped to both '2' and '3'.

Example 3:

Input: s = "paper", t = "title"

Output: true

 

Constraints:

1 <= s.length <= 5 * 104
t.length == s.length
s and t consist of any valid ascii character.*/
func isIsomorphic(s string, t string) bool {
    if (len(s) != len(t)) {
        return false;
    }

    lettersMap := make(map[rune]rune)
    usedLettersFromT := make(map[rune]struct{})
    runesT := []rune(t)

    for i, r := range(s) {
        if _, ok := lettersMap[r]; !ok {
            if _, ok2 := usedLettersFromT[runesT[i]]; ok2 {
                return false
            }
            lettersMap[r] = runesT[i];
            usedLettersFromT[runesT[i]] = struct{}{}
        } else if (lettersMap[r] != runesT[i]) {
            return false
        }
    }

    return true;
}
