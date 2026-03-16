/*
Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.

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
    ransomNoteMap := make(map[rune]int)

    for _, r := range(ransomNote) {
        ransomNoteMap[r]++
    }

    for _, r := range(magazine) {
        if _, ok := ransomNoteMap[r]; ok {
            ransomNoteMap[r]--
        }
    }

    for _, r := range(ransomNote) {
        if (ransomNoteMap[rune(r)] > 0) {
            return false;
        }
    }

    return true
}
