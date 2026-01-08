/*Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.

Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.

Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.

Return the minimum integer k such that she can eat all the bananas within h hours.

 

Example 1:

Input: piles = [3,6,7,11], h = 8
Output: 4
Example 2:

Input: piles = [30,11,23,4,20], h = 5
Output: 30
Example 3:

Input: piles = [30,11,23,4,20], h = 6
Output: 23
 

Constraints:

1 <= piles.length <= 10^4
piles.length <= h <= 10^9
1 <= piles[i] <= 10^9
*/
class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        var low = 1;
        var high = piles.Max();
        var k = 0;

        while (low <= high)
        {
            var mid = (low + high) / 2;
            var isEnough = CheckSpeed(mid, piles, h);
            
            if (isEnough) {
                high = mid - 1;
                k = mid;
            } else {
                low = mid + 1;
            }
        }

        return k;
    }

    public bool CheckSpeed(int k, int[] piles, int hours) {
        var currentHours = 0;
        for (var i = 0; i < piles.Length; i++) 
        {
            var cal = piles[i] + k - 1;
            currentHours += cal / k; 

            if (currentHours > hours) 
            {
                return false;
            }
        }
        return true;
    }
}
