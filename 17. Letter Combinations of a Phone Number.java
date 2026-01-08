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
class Solution {
    Map<Character, List<Character>> map = new HashMap<Character, List<Character>>()
    {{
        put('2', new ArrayList<Character>(Arrays.asList('a', 'b', 'c')));
        put('3', new ArrayList<Character>(Arrays.asList('d', 'e', 'f')));
        put('4', new ArrayList<Character>(Arrays.asList('g', 'h', 'i')));
        put('5', new ArrayList<Character>(Arrays.asList('j', 'k', 'l')));
        put('6', new ArrayList<Character>(Arrays.asList('m', 'n', 'o')));
        put('7', new ArrayList<Character>(Arrays.asList('p', 'q', 'r', 's')));
        put('8', new ArrayList<Character>(Arrays.asList('t', 'u', 'v')));
        put('9', new ArrayList<Character>(Arrays.asList('w', 'x', 'y', 'z')));
    }};

    public List<String> letterCombinations(String digits) {
        StringBuilder sb = new StringBuilder();
        List<String> result = new ArrayList<>();        
        solve(0, digits, sb, result);
        return result;
    }

    public void solve(int i, String digits, StringBuilder sb, List<String> result) {
        if (i == digits.length()) {
            result.add(sb.toString());
            return;
        }

        char digit = digits.charAt(i);
        for (char letter : map.get(digit)) {
            sb.append(letter);
            solve(i + 1, digits, sb, result);
            sb.setLength(sb.length() - 1);
        }
    }
}
