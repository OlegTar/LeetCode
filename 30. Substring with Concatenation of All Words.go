/*
You are given a string s and an array of strings words. All the strings of words are of the same length.

A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated.

For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.
Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order.

 

Example 1:

Input: s = "barfoothefoobarman", words = ["foo","bar"]

Output: [0,9]

Explanation:

The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is a permutation of words.
The substring starting at 9 is "foobar". It is the concatenation of ["foo","bar"] which is a permutation of words.

Example 2:

Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]

Output: []

Explanation:

There is no concatenated substring.

Example 3:

Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]

Output: [6,9,12]

Explanation:

The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"].
The substring starting at 9 is "barthefoo". It is the concatenation of ["bar","the","foo"].
The substring starting at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"].
*/
func findSubstring(s string, words []string) []int {
	wordLen := len(words[0])
	count := len(words)
	hash := make(map[string]int)
	for _, word := range words {
		if _, ok := hash[word]; !ok {
			hash[word] = 0
		}
		hash[word]++
	}

	currentHash := make(map[string]int)
	var endForLeft int = len(s) - count*wordLen
	var result []int

	for i := 0; i < wordLen; i++ {
		var left int = i
		right := left
        currentCount := 0
		    clear(currentHash)
        
        for left <= endForLeft && currentCount < count {
            nextWord := s[right:right + wordLen]

            if _, ok := hash[nextWord]; ok {
                right += wordLen
                currentHash[nextWord]++
                currentCount++

                for currentHash[nextWord] > hash[nextWord] {
                    leftWord := s[left : left+wordLen]
                    currentHash[leftWord]--
                    currentCount--
                    left += wordLen
                }

                if currentCount == count {
                    result = append(result, left)
                    leftWord := s[left : left+wordLen]
                    currentHash[leftWord]--
                    currentCount--
                    left += wordLen
                }
            } else {
                left = right + wordLen
                currentCount = 0
                right = left
                clear(currentHash)
            }
        }
	}

	return result
}
