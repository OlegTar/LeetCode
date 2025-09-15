public class Solution {
    public int MySqrt(int x) {
        var left = 0;
        var right = x;
        var answer = 0;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            //Console.WriteLine($"mid = {mid}");

            var square = (double)mid * (double)mid;
            //Console.WriteLine($"square = {square}");
            if (square == x) 
            {
                return mid;
            }
            else if (square < x)
            {
                answer = mid;
                left = mid + 1;
            }
            else 
            {
                right = mid - 1;
            }
        }
        return answer;
    }
}
