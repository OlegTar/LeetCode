/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        var left = 0;
        var right = n;
        var mid = 0;
        while (left <= right)
        {
            mid = left + (right - left) / 2;
            var result = guess(mid);
            if (result == 0)
            {                
                return mid;
            }
            else if (result == -1)
            {
                right = mid - 1;
            }
            else if (result == 1)
            {
                left = mid + 1;
            }
        }
        return mid;
    }
}
