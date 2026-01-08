/*Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.


 

Example 1:

Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
Example 2:

Input: digits = "2"
Output: ["a","b","c"]
 

Constraints:

1 <= digits.length <= 4
digits[i] is a digit in the range ['2', '9'].*/

public class Solution {
    public Dictionary<char, ICollection<char>> map = new Dictionary<char, ICollection<char>>() 
    {
        { '2', ['a', 'b', 'c'] },
        { '3', ['d', 'e', 'f'] },
        { '4', ['g', 'h', 'i'] },
        { '5', ['j', 'k', 'l'] },
        { '6', ['m', 'n', 'o'] },
        { '7', ['p', 'q', 'r', 's'] },
        { '8', ['t', 'u', 'v'] },
        { '9', ['w', 'x', 'y', 'z'] },
    };

    public IList<string> LetterCombinations(string digits) {
        var sb = new StringBuilder();
        var result = new List<string>();
        Solve(0, digits, sb, result);
        return result;
    }

    public void Solve(int i, string digits, StringBuilder sb, List<string> result)
    {
        if (i == digits.Length)
        {
            result.Add(sb.ToString());
            return;
        }

        foreach (var letter in map[digits[i]])
        {
            sb.Append(letter);
            Solve(i + 1, digits, sb, result);
            sb.Length--;
        }
    }
}
