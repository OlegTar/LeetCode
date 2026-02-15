/*Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

 

Example 1:

Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]
Example 2:

Input: n = 1
Output: ["()"]
 

Constraints:

1 <= n <= 8*/
public class Solution
{
    public IList<string> GenerateParenthesis(int n) 
    {
        var results = new List<string>();
        Solve(n, 0, 0, new StringBuilder(), results);
        return results;
    }

    public void Solve(int n, int open, int close, StringBuilder combination, List<string> results)
    {
        if (open == n && close == n)
        {
            results.Add(combination.ToString());
            return;
        }

        if (open < n)
        {
            combination.Append('(');
            Solve(n, open + 1, close, combination, results);
            combination.Length--;
        }

        if (close < open)
        {
            combination.Append(')');
            Solve(n, open, close + 1, combination, results);
            combination.Length--;
        }
    }
}
