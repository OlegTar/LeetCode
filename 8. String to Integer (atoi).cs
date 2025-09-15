public class Solution {
    public int MyAtoi(string s) {
        var i = 0;
        while (i < s.Length && s[i] == ' ')
        {
            i++;
        }

        if (i >= s.Length)
        {
            return 0;
        }

        var minus = s[i] == '-';
        if (s[i] == '-' || s[i] == '+')
        {
            i++;
        }

        while (i < s.Length && s[i] == '0')
        {
            i++;        
        }
        
        var j = i;
        while (j < s.Length && (s[j] >= '0' && s[j] <= '9'))
        {
            j++;
        }
        
        s = s[i..j];
        if (s.Length == 0)
        {
            return 0;
        }

        long intBeforeOverflow = minus ? ((long)(int.MinValue) * -1L) : int.MaxValue;        
        long answer = 0;

        for (i = 0; i < s.Length; i++)
        {
            answer *= 10;
            answer += s[i] - '0';
            if (answer > intBeforeOverflow)
            {
                return (int)intBeforeOverflow;
            }
        }

        if (minus)
        {
            answer = -answer;
        }

        return (int)answer;
    }
}
