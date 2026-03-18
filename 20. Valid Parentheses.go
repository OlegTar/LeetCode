/*Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 

Example 1:

Input: s = "()"

Output: true

Example 2:

Input: s = "()[]{}"

Output: true

Example 3:

Input: s = "(]"

Output: false

Example 4:

Input: s = "([])"

Output: true

Example 5:

Input: s = "([)]"

Output: false

 

Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'.*/
func isValid(s string) bool {
    bracketsMap := map[rune]rune{}
    bracketsMap['}'] = '{'
    bracketsMap[')'] = '('
    bracketsMap[']'] = '['

    var stack []rune
    for _, char := range(s) {
        if (char == ')' || char == '}' || char == ']') {
            if len(stack) == 0 || stack[len(stack) - 1] != bracketsMap[char] {
                return false
            }
            stack = stack[:len(stack) - 1]
        } else {
            stack = append(stack, char)
        }
    }

    return len(stack) == 0
}
