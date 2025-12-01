/*Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.

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
]*/
public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        var result = new List<string>();
        var currentLength = 0;
        var wordLine = new List<string>();

        for (var i = 0; i < words.Length; i++)
        {
            var countOfWords = wordLine.Count;
            if (currentLength + words[i].Length + countOfWords > maxWidth)
            {
                var spaceCount = maxWidth - currentLength;
                var sb = new StringBuilder();
                if (wordLine.Count == 1) 
                {
                    sb.Append(wordLine[0]);
                    sb.Append(new string(' ', spaceCount));
                }
                else 
                {
                    var countGaps = wordLine.Count - 1;                    
                    var gapSize = spaceCount / countGaps;
                    var reminder = spaceCount % countGaps;                
                    for (var j = 0; j < wordLine.Count; j++)
                    {
                        sb.Append(wordLine[j]);
                        if (countGaps-- > 0)
                        {
                            sb.Append(new string(' ', gapSize));
                        }
                        
                        if (reminder-- > 0)
                        {   
                            sb.Append(" ");
                        }
                    }
                }
                result.Add(sb.ToString());                
                wordLine.Clear();
                currentLength = 0;
            }
            wordLine.Add(words[i]);
            currentLength += words[i].Length;
        }
        
        var lastSb = new StringBuilder();
        lastSb.Append(string.Join(" ", wordLine));                
        lastSb.Append(new string(' ', Math.Abs(maxWidth - lastSb.Length)));
        result.Add(lastSb.ToString());        
        return result;
    }
}
