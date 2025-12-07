/*Given an input string s, reverse the order of the words.

A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.

Return a string of the words in reverse order concatenated by a single space.

Note that s may contain leading or trailing spaces or multiple spaces between two words. The returned string should only have a single space separating the words. Do not include any extra spaces.

 

Example 1:

Input: s = "the sky is blue"
Output: "blue is sky the"
Example 2:

Input: s = "  hello world  "
Output: "world hello"
Explanation: Your reversed string should not contain leading or trailing spaces.
Example 3:

Input: s = "a good   example"
Output: "example good a"
Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.
 

Constraints:

1 <= s.length <= 104
s contains English letters (upper-case and lower-case), digits, and spaces ' '.
There is at least one word in s.
 

Follow-up: If the string data type is mutable in your language, can you solve it in-place with O(1) extra space?*/
public class Solution {
    public string ReverseWords(string s) {
        List<string> words = new();
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                continue;
            }
            else 
            {
                var sb = new StringBuilder();                
                for (; i < s.Length && s[i] != ' '; i++)
                {
                    sb.Append(s[i]);
                }
                words.Add(sb.ToString());
            }
        }
        words.Reverse();
        return string.Join(" ", words);
    }
}
