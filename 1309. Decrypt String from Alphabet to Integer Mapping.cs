/*You are given a string s formed by digits and '#'. We want to map s to English lowercase characters as follows:

Characters ('a' to 'i') are represented by ('1' to '9') respectively.
Characters ('j' to 'z') are represented by ('10#' to '26#') respectively.
Return the string formed after mapping.

The test cases are generated so that a unique mapping will always exist.

 

Example 1:

Input: s = "10#11#12"
Output: "jkab"
Explanation: "j" -> "10#" , "k" -> "11#" , "a" -> "1" , "b" -> "2".
Example 2:

Input: s = "1326#"
Output: "acz"
 

Constraints:

1 <= s.length <= 1000
s consists of digits and the '#' letter.
s will be a valid string such that mapping is always possible.*/
public class Solution {
    public string FreqAlphabets(string s) {
        List<char> seq = new();
        Queue<char> queue = new();
        foreach (var ch in s)
        {
            if ('0' <= ch && ch <= '9')
            {
                queue.Enqueue(ch);
            }
            else
            {
                while (queue.Count > 2)
                {
                    seq.Add((char)('a' + (queue.Dequeue() - '0') - 1));
                }

                int number = 0;
                number += (queue.Dequeue() - '0') * 10;
                number += (queue.Dequeue() - '0');

                seq.Add((char)('a' + number - 1));                
            }
        }

        while (queue.Count > 0)
        {
            seq.Add((char)('a' + (queue.Dequeue() - '0') - 1));
        }

        return new string(seq.ToArray());
    }
}
