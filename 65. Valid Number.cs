/*Given a string s, return whether s is a valid number.

For example, all the following are valid numbers: "2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789", while the following are not valid numbers: "abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53".

Formally, a valid number is defined using one of the following definitions:

An integer number followed by an optional exponent.
A decimal number followed by an optional exponent.
An integer number is defined with an optional sign '-' or '+' followed by digits.

A decimal number is defined with an optional sign '-' or '+' followed by one of the following definitions:

Digits followed by a dot '.'.
Digits followed by a dot '.' followed by digits.
A dot '.' followed by digits.
An exponent is defined with an exponent notation 'e' or 'E' followed by an integer number.

The digits are defined as one or more digits.

 

Example 1:

Input: s = "0"

Output: true

Example 2:

Input: s = "e"

Output: false

Example 3:

Input: s = "."

Output: false

 

Constraints:

1 <= s.length <= 20
s consists of only English letters (both uppercase and lowercase), digits (0-9), plus '+', minus '-', or dot '.'.*/
public class Solution {
    enum State {
        SignDotDigit,
        DigitDotExp,
        DigitExp,
        SignDigit,
        Digit,
    }

    public bool IsNumber(string s) {
        if (s.Length == 0)
        {
            return false;
        }
        
        var digits = true;
        var exp = true;
        var state = State.SignDotDigit;
        foreach (var ch in s)
        {            
            switch (state)
            {
                case State.SignDotDigit:
                    if (ch != '-' && ch != '+' && ch != '.' && !isDigit(ch))
                    {                        
                        return false;
                    }

                    if (ch == '+' || ch == '-')
                    {
                        digits = false;
                        state = State.DigitDotExp;
                    }
                    else if (isDigit(ch))
                    {
                        state = State.DigitDotExp;
                    }
                    else if (ch == '.')
                    {
                        digits = false;
                        state = State.DigitExp;
                    }                    
                    break;
                case State.DigitDotExp:
                    if (ch != '.' && ch != 'e' && ch != 'E' && !isDigit(ch)) 
                    {
                        return false;
                    }
                    
                    if (isDigit(ch))
                    {
                        digits = true;
                    }

                    if (ch == '.')
                    {
                        state = State.DigitExp;
                    }
                    else if (ch == 'e' || ch == 'E')
                    {
                        exp = false;
                        state = State.SignDigit;
                    }                 
                    break;
                case State.DigitExp:
                    if (ch != 'e' && ch != 'E' && !isDigit(ch)) 
                    {
                        return false;
                    }

                    if (isDigit(ch))
                    {
                        digits = true;
                    }

                    if (ch == 'e' || ch == 'E')
                    {
                        exp = false;
                        state = State.SignDigit;
                    }
                    break;
                case State.SignDigit:
                    if (ch != '+' && ch != '-' && !isDigit(ch)) 
                    {
                        return false;
                    }
                    if (ch == '+' || ch == '-')
                    {
                        state = State.Digit;
                    }
                    else if (isDigit(ch))
                    {
                        exp = true;
                        state = State.Digit;
                    }
                    break;
                case State.Digit:
                    if (!isDigit(ch)) 
                    {
                        return false;
                    }
                    exp = true;
                    break;
            }
        }
       
        return digits && exp;
    }

    public bool isDigit(char c)
    {
        var code = c - '0';
        return code >= 0 && code <= 9;
    }
}
