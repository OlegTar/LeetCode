public class Solution {
    public int Reverse(int x) {
        if (x == 0 || x == int.MinValue)
        {
            return 0;
        }
        
        var minus = x < 0;
        var maxBeforeOf = int.MaxValue / 10;
        x = Math.Abs(x);
        var answer = 0;
        while (x > 0)
        {
            if (answer > maxBeforeOf)
            {
                return 0;
            }
            answer *= 10;
            var mod = x % 10;
            answer += mod;
            x /= 10;
        }

        if (minus)
        {
            answer = -answer;
        }
        return answer;
    }
}
