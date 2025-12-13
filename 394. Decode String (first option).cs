/*Given an encoded string, return its decoded string.

The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

You may assume that the input string is always valid; there are no extra white spaces, square brackets are well-formed, etc. Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there will not be input like 3a or 2[4].

The test cases are generated so that the length of the output will never exceed 105.

 

Example 1:

Input: s = "3[a]2[bc]"
Output: "aaabcbc"
Example 2:

Input: s = "3[a2[c]]"
Output: "accaccacc"
Example 3:

Input: s = "2[abc]3[cd]ef"
Output: "abcabccdcdcdef"
 

Constraints:

1 <= s.length <= 30
s consists of lowercase English letters, digits, and square brackets '[]'.
s is guaranteed to be a valid input.
All the integers in s are in the range [1, 300].*/

public class Solution {
    public string DecodeString(string s) {
        var encodedString = new StringBuilder();
        var expression = new StringBuilder();
        
        var iks = new Stack<int>();
        var ks = new Stack<int>() ;
        var expressions = new Stack<string>();
        var offsets = new Stack<int>();
        
        iks.Push(0);
        ks.Push(1);
        expressions.Push(s);
        offsets.Push(0);

        while (ks.Count() > 0)
        {
            var currentK = ks.Pop();
            var currentExpression = expressions.Pop();
            var offset = offsets.Pop();
            var iKStart = iks.Pop();
        
            var exit = false;
            for (var iK = iKStart; iK < currentK && !exit; iK++)
            {
                for (var i = offset; i < currentExpression.Length && !exit; i++)
                {
                    var chr = currentExpression[i];
                    if (IsDigit(chr))
                    {
                        var k = chr - '0';
                        var j = i + 1;
                        for (; j < currentExpression.Length; j++)
                        {
                            if (IsDigit(currentExpression[j]))
                            {
                                k *= 10;
                                k += (currentExpression[j] - '0');
                            }
                            else
                            {
                                break;
                            }
                        }

                        var brackets = 0;
                        expression.Clear();
                        for (; j < currentExpression.Length; j++)
                        {
                            if (currentExpression[j] == '[') 
                            {   
                                brackets++;
                                if (brackets != 1) 
                                {
                                    expression.Append(currentExpression[j]);
                                }
                            } 
                            else if (currentExpression[j] == ']')
                            {
                                brackets--;
                                if (brackets == 0)
                                {
                                    break;
                                }
                                expression.Append(currentExpression[j]);   
                            }
                            else 
                            {
                                expression.Append(currentExpression[j]);
                            }
                        }
                        
                        ks.Push(currentK);
                        expressions.Push(currentExpression);
                        offsets.Push(j + 1);
                        iks.Push(iK);
                        
                        ks.Push(k);
                        expressions.Push(expression.ToString());
                        offsets.Push(0);
                        iks.Push(0);
                        exit = true;
                    }
                    else 
                    {
                        encodedString.Append(chr);
                    }
                }
                offset = 0;
            }
        }

        return encodedString.ToString();
    }

    public bool IsDigit(char chr)
    {
        return '0' <= chr && chr <= '9';
    }
}
