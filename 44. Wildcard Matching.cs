/*
Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).
The matching should cover the entire input string (not partial).

 

Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input: s = "aa", p = "*"
Output: true
Explanation: '*' matches any sequence.
Example 3:

Input: s = "cb", p = "?a"
Output: false
Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.
 

Constraints:

0 <= s.length, p.length <= 2000
s contains only lowercase English letters.
p contains only lowercase English letters, '?' or '*'.
*/
public class Solution {
    private class PatternPart
    {
        public bool StrictlyBegin {get;set;}
        public string Part {get; set;}
        public bool StrictlyEnd {get;set;}
    }

    public bool IsMatch(string s, string p) {
        if (p.Length == 0 && s.Length == 0)
        {
            return true;
        }
        
        if (p.Length == 0 && s.Length != 0)
        {
            return false;
        }

        p = NormalizePattern(p);
        if (p == "*")
        {
            return true;
        }

        var parts = p.Split('*').ToList();
        var strictlyBegin = parts[0].Length > 0;
        var strictlyEnd = parts[^1].Length > 0;
        var patternParts = parts
            .Where(p => p.Length > 0)
            .Select(part => new PatternPart()
            {
                Part = part
            }).ToList();
        patternParts[0].StrictlyBegin = strictlyBegin;
        patternParts[^1].StrictlyEnd = strictlyEnd;

        int start = 0;
        foreach (var patternPart in patternParts)
        {
            var result = IsMatch(patternPart.StrictlyBegin, patternPart.StrictlyEnd, patternPart.Part, ref start, s);
            if (!result)
            {
                return false;
            }
        }
        return true;
    }

    public string NormalizePattern(string pattern)
    {
        var newPattern = new StringBuilder();
        var lastChar = pattern[0];
        newPattern.Append(lastChar);
        for (var i = 1; i < pattern.Length; i++)
        {
            if (pattern[i] == '*' && lastChar == '*')
            {
                continue;
            }
            newPattern.Append(pattern[i]);
            lastChar = pattern[i];
        }
        return newPattern.ToString();
    }

    public bool IsMatch(bool strictlyBegin, bool strictlyEnd, string pattern, ref int start, string s)
    {
        if (pattern.Length + start > s.Length)
        {
            return false;
        }

        if (strictlyBegin && strictlyEnd)
        {
            return s.Length == pattern.Length && CheckPattern(0, pattern, s);
        }

        if (strictlyBegin)
        {
            var result = CheckPattern(0, pattern, s);
            if (result)
            {
                start = pattern.Length;
            }
            return result;
        }

        if (strictlyEnd) 
        {
            var st = s.Length - pattern.Length;
            var result = CheckPattern(s.Length - pattern.Length, pattern, s);
            if (result)
            {
                start = s.Length;
            }
            return result;
        }

        var end = s.Length - pattern.Length;
        var i = start;
        for (; i <= end; i++)
        {
            if (CheckPattern(i, pattern, s)) 
            {
                start = i + pattern.Length;
                return true;
            }
        }
        return false;
    }

    public bool CheckPattern(int start, string pattern, string s)
    {
        for (var i = 0; i < pattern.Length; i++)
        {
            if (pattern[i] == '?')
            {
                continue;
            }

            if (pattern[i] != s[start + i])
            {
                return false;
            }
        }

        return true;
    }
}
