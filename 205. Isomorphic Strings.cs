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
public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, char> lettersMap = new();
        HashSet<char> usedLetterFromT = new();

        for (var i = 0; i < s.Length; i++)
        {
            if (!lettersMap.ContainsKey(s[i])) {
                if (usedLetterFromT.Contains(t[i])) {
                    return false;
                }
                lettersMap[s[i]] = t[i];
                usedLetterFromT.Add(t[i]);
            }
            else if (lettersMap[s[i]] != t[i])
            {
                return false;
            }
        }

        return true;
    }
}
