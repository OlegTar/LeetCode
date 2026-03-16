/*Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.

Each letter in magazine can only be used once in ransomNote.

 

Example 1:

Input: ransomNote = "a", magazine = "b"
Output: false
Example 2:

Input: ransomNote = "aa", magazine = "ab"
Output: false
Example 3:

Input: ransomNote = "aa", magazine = "aab"
Output: true
 

Constraints:

1 <= ransomNote.length, magazine.length <= 105
ransomNote and magazine consist of lowercase English letters.*/
func canConstruct(ransomNote string, magazine string) bool {
    ransomNoteMap := [256]int{}

    for i := 0; i < len(ransomNote); i++ {
        ransomNoteMap[ransomNote[i]]++
    }

    for i := 0; i < len(magazine); i++ {
        ransomNoteMap[magazine[i]]--
    }

    for i := 0; i < len(ransomNote); i++ {
        if (ransomNoteMap[ransomNote[i]] > 0) {
            return false;
        }
    }

    return true
}
