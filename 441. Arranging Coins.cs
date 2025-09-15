public class Solution {
    public int ArrangeCoins(int n) {        
        var left = 1;
        var right = n;
        var answer = 0;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var sum = (((1L + (long)mid) * (long)mid) / 2);

            if (sum > n)
            {
                right = mid - 1;
            }
            else 
            {
                answer = mid;
                left = mid + 1;
            }
        }
        return answer;
    }
}
