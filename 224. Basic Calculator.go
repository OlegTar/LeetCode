/*Given a string s representing a valid expression, implement a basic calculator to evaluate it, and return the result of the evaluation.

Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().

 

Example 1:

Input: s = "1 + 1"
Output: 2
Example 2:

Input: s = " 2-1 + 2 "
Output: 3
Example 3:

Input: s = "(1+(4+5+2)-3)+(6+8)"
Output: 23
 

Constraints:

1 <= s.length <= 3 * 105
s consists of digits, '+', '-', '(', ')', and ' '.
s represents a valid expression.
'+' is not used as a unary operation (i.e., "+1" and "+(2 + 3)" is invalid).
'-' could be used as a unary operation (i.e., "-1" and "-(2 + 3)" is valid).
There will be no two consecutive operators in the input.
Every number and running calculation will fit in a signed 32-bit integer.*/
import (
    "strings"
    "strconv"
)
func calculate(s string) int {
    var levels [][]string;    
    levels = append(levels, []string{})
    lastLevel := 0
    var result int = 0
    for _, letter := range(s) {
        if (isDigit(letter)) {
            if (len(levels[lastLevel]) == 0) {
                levels[lastLevel] = append(levels[lastLevel], string(letter))
            } else {
                lastIndex := len(levels[lastLevel]) - 1
                levels[lastLevel][lastIndex] += string(letter)
            }
        } else if (letter == '(') {
            levels = append(levels, []string{})
            lastLevel++
        } else if (letter == '+' || letter == '-') {
            levels[lastLevel] = append(levels[lastLevel], string(letter))
        } else if (letter == ')') {           
            var minus bool = false
            var subResult int = 0
            for _, str := range(levels[lastLevel]) {                                
                if (str == "-") {
                    minus = true
                } else if (str != "+") {
                    operand, _ := strconv.Atoi(str)
                    if (minus) {
                        operand = -operand
                        minus = false
                    }
                    subResult += int(operand)
                }
            }
            levels = levels[:lastLevel]
            lastLevel--
            levels[lastLevel] = append(levels[lastLevel], strconv.Itoa(subResult))
        }
    }

    var minus bool = false
    for _, str := range(levels[lastLevel]) {        
        if (str == "-") {
            minus = true
        } else if (str != "+") {
            operand, _ := strconv.ParseInt(str, 10, 64)
            if (minus) {
                operand = -operand
                minus = false
            }
            result += int(operand)
        }
    }

    return result;
}


func isDigit(digit rune) bool {
    return digit >= '0' && digit <= '9';
}
