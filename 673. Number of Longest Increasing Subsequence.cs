/*
Given an integer array nums, return the number of longest increasing subsequences.

Notice that the sequence has to be strictly increasing.

 

Example 1:

Input: nums = [1,3,5,4,7]
Output: 2
Explanation: The two longest increasing subsequences are [1, 3, 4, 7] and [1, 3, 5, 7].
Example 2:

Input: nums = [2,2,2,2,2]
Output: 5
Explanation: The length of the longest increasing subsequence is 1, and there are 5 increasing subsequences of length 1, so output 5.
 

Constraints:

1 <= nums.length <= 2000
-106 <= nums[i] <= 106
The answer is guaranteed to fit inside a 32-bit integer.
*/
public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        var dp = new int[2, nums.Length];
        dp[0, 0] = 1;
        dp[1, 0] = 1;
        var max = dp[1, 0];
        var result = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            dp[1, i] = 1;
            for (var j = i - 1; j >= 0; j--)
            {
                if (nums[j] < nums[i])
                {
                    dp[1, i] = Math.Max(dp[1, i], dp[1, j] + 1);
                }
            }

            var prevLen = dp[1, i] - 1;
            for (var j = i - 1; j >= 0; j--)
            {                
                if (nums[j] < nums[i] && dp[1, j] == prevLen)
                {
                    dp[0, i] += dp[0, j];
                }
            }

            if (dp[0, i] == 0)
            {
                dp[0, i] = 1;
            }

            if (dp[1, i] > max)
            {
                max = dp[1, i];
                result = dp[0, i];
            }
            else if (dp[1, i] == max)
            {
                result += dp[0, i];
            }
        }

        return result;
    }
}
