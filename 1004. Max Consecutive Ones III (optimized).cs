/*Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.

 

Example 1:

Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
Output: 6
Explanation: [1,1,1,0,0,1,1,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
Example 2:

Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
Output: 10
Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
 

Constraints:

1 <= nums.length <= 105
nums[i] is either 0 or 1.
0 <= k <= nums.length*/
public class Solution {
    public int LongestOnes(int[] nums, int k) {        
        var (maxCount, count, zeros, start) = (0, 0, 0, 0);
        for (var end = 0; end < nums.Length; end++)
        {
            if (nums[end] == 0)
            {
                zeros++;
            }
            
            while (zeros > k)
            {
                if (nums[start++] == 0)
                {
                    zeros--;
                }
            }

            maxCount = Math.Max(maxCount, end - start + 1);
        }
        return maxCount;
    }
}
