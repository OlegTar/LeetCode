/*
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.


 

Example 1:

Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
Example 2:

Input: digits = "2"
Output: ["a","b","c"]
 

Constraints:

1 <= digits.length <= 4
digits[i] is a digit in the range ['2', '9'].
*/
import "strings"
func letterCombinations(digits string) []string {
    letters := map[byte][]string{}
    letters[2] = []string{"a", "b", "c"}
    letters[3] = []string{"d", "e", "f"}
    letters[4] = []string{"g", "h", "i"}
    letters[5] = []string{"j", "k", "l"}
    letters[6] = []string{"m", "n", "o"}
    letters[7] = []string{"p", "q", "r", "s"}
    letters[8] = []string{"t", "u", "v"}
    letters[9] = []string{"w", "x", "y", "z"}

    sb := strings.Builder{}
    result := []string{}

    var solve func(i int, digits string, combination *[]string, result *[]string)
    solve = func(i int, digits string, combination *[]string, result *[]string) {
        if (i == len(digits)) {
            sb.Reset()
            for _, str := range(*combination) {
                sb.WriteString(str)
            }
            *result = append(*result, sb.String())
            return
        }
        n := digits[i] - '1' + 1
        for _, letter := range(letters[n]) {
            *combination = append(*combination, letter)
            solve(i + 1, digits, combination, result)
            *combination = (*combination)[:len(*combination) - 1]
        }
    }
    solve(0, digits, &[]string{}, &result)
    return result;
}
