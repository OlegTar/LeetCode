/*Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

 

Example 1:

Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]
Example 2:

Input: n = 1
Output: ["()"]
 

Constraints:

1 <= n <= 8*/
func generateParenthesis(n int) []string {
    result := []string{}
    solve(n, 0, 0, "", &result)
    return result
}

func solve(n, open, close int, comb string, result *[]string) {
    if (open == close && open == n) {
        *result = append(*result, comb)
        return;
    }

    if (open < n) {
        comb += "("
        solve(n, open + 1, close, comb, result)
        comb = comb[:len(comb) - 1]
    }

    if (close < open) {
        comb += ")"
        solve(n, open, close + 1, comb, result)        
        comb = comb[:len(comb) - 1]
    }
}
