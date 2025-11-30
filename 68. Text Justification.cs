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
        var wordLengths = new List<int>();
        wordLengths.Add(words[0].Length);
        var wordCounts = new List<int>();
        wordCounts.Add(1);

        for (var i = 1; i < words.Length; i++)
        {
            var currentLength = wordLengths[^1];
            var countOfWords = wordCounts[^1];
            if (currentLength + words[i].Length + countOfWords <= maxWidth)
            {
                currentLength += words[i].Length;
                wordLengths[^1] = currentLength;
                wordCounts[^1]++;
            }
            else
            {
                wordLengths.Add(words[i].Length);
                wordCounts.Add(1);
            }
        }

        var spaces = new List<int[]>();
        for (var i = 0; i < wordCounts.Count - 1; i++)
        {
            var countGaps = wordCounts[i] == 1 ? 1 : wordCounts[i] - 1;
            spaces.Add(new int[countGaps]);
            var spaceCount = maxWidth - wordLengths[i];
            var gapSize = spaceCount / countGaps;
            for (var j = 0; j < countGaps; j++)
            {
                spaces[^1][j] = gapSize;
            }
            var reminder = spaceCount % countGaps;
            var k = 0;
            while (reminder > 0)
            {
                spaces[^1][k]++;
                reminder--;
                k++;
            }
        }

        var pointer = 0;
        for (var i = 0; i < wordCounts.Count - 1; i++)
        {
            var sb = new StringBuilder();
            var pointerSpace = 0;
            for (var j = 0; j < wordCounts[i]; j++)
            {
                sb.Append(words[pointer++]);
                if (pointerSpace < spaces[i].Length)
                {
                    sb.Append(new string(' ', spaces[i][pointerSpace++]));
                }
            }
            result.Add(sb.ToString());
        }
        var lastSb = new StringBuilder();
        for (; pointer < words.Length; pointer++)
        {
            lastSb.Append(words[pointer]);
            lastSb.Append(" ");
        }
        if (lastSb.Length > maxWidth)
        {
            lastSb.Length--;
        }
        else 
        {
            lastSb.Append(new string(' ', Math.Abs(maxWidth - lastSb.Length)));
        }
        result.Add(lastSb.ToString());        
        return result;
    }
}
