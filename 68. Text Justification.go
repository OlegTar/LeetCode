/*
Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.

You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.

Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.

For the last line of text, it should be left-justified, and no extra space is inserted between words.

Note:

A word is defined as a character sequence consisting of non-space characters only.
Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
The input array words contains at least one word.
 

Example 1:

Input: words = ["This", "is", "an", "example", "of", "text", "justification."], maxWidth = 16
Output:
[
   "This    is    an",
   "example  of text",
   "justification.  "
]
Example 2:

Input: words = ["What","must","be","acknowledgment","shall","be"], maxWidth = 16
Output:
[
  "What   must   be",
  "acknowledgment  ",
  "shall be        "
]
Explanation: Note that the last line is "shall be    " instead of "shall     be", because the last line must be left-justified instead of fully-justified.
Note that the second line is also left-justified because it contains only one word.
Example 3:

Input: words = ["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"], maxWidth = 20
Output:
[
  "Science  is  what we",
  "understand      well",
  "enough to explain to",
  "a  computer.  Art is",
  "everything  else  we",
  "do                  "
]
 

Constraints:

1 <= words.length <= 300
1 <= words[i].length <= 20
words[i] consists of only English letters and symbols.
1 <= maxWidth <= 100
words[i].length <= maxWidth
*/
import "strings"
func fullJustify(words []string, maxWidth int) []string {
    var result []string
    var sb strings.Builder
    var lineLength = len(words[0])
    currentLineWords := []string {words[0]}
    for i := 1; i < len(words); i++ {
        if (lineLength + len(words[i]) + 1) > maxWidth {
            var gapSize int = 0
            if len(currentLineWords) == 1 {
                gapSize = maxWidth - len(currentLineWords[0]);
                sb.WriteString(currentLineWords[0])
                sb.WriteString(strings.Repeat(" ", gapSize))
            } else {
                sumOfWordLengths := 0
                for j := 0; j < len(currentLineWords); j++ {
                    sumOfWordLengths += len(currentLineWords[j])
                }
                sumOfSpaces := maxWidth - sumOfWordLengths
                countOfGaps := len(currentLineWords) - 1
                gapSize = sumOfSpaces / countOfGaps
                additionalGapSize := sumOfSpaces % countOfGaps
                
                sb.WriteString(currentLineWords[0])
                for j := 1; j < len(currentLineWords); j++ {
                    sb.WriteString(strings.Repeat(" ", gapSize))
                    if (additionalGapSize > 0) {
                        sb.WriteString(" ")
                        additionalGapSize--
                    }
                    sb.WriteString(currentLineWords[j])
                }
            }
            result = append(result, sb.String())
            sb.Reset()
            currentLineWords = []string{words[i]}
            lineLength = len(words[i])
        } else {
            currentLineWords = append(currentLineWords, words[i])
            lineLength += len(words[i]) + 1
        }
    }

    if (len(currentLineWords) > 0) {
        sb.WriteString(currentLineWords[0])
        for i := 1; i < len(currentLineWords); i++ {
            sb.WriteString(" ")
            sb.WriteString(currentLineWords[i])
        }
        gapSize := maxWidth - sb.Len()
        if (gapSize < 0) {
            gapSize = 0
        } 
        sb.WriteString(strings.Repeat(" ", gapSize))
        result = append(result, sb.String())
    }

    return result
}
