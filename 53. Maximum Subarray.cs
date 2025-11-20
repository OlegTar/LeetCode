/*Given an integer array nums, find the subarray with the largest sum, and return its sum.

 

Example 1:

Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: The subarray [4,-1,2,1] has the largest sum 6.
Example 2:

Input: nums = [1]
Output: 1
Explanation: The subarray [1] has the largest sum 1.
Example 3:

Input: nums = [5,4,-1,7,8]
Output: 23
Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
 

Constraints:

1 <= nums.length <= 105
-104 <= nums[i] <= 104
*/
public class Solution {
    public int MaxSubArray(int[] nums) {
        var maxNeg = int.MinValue;
        var sumOfPositive = 0;
        var currentSum = 0;
        var result = int.MinValue;

        var state = 0;
        var allNegatives = true;
                
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= 0)
            {
                maxNeg = Math.Max(maxNeg, nums[i]);
            }

            if (state == 0)
            {
                if (nums[i] > 0) 
                {
                    allNegatives = false;
                    currentSum = nums[i];
                    sumOfPositive = nums[i];
                    state = 1;
                }
            }
            else if (state == 1)
            {
                if (nums[i] > 0)
                {
                    sumOfPositive += nums[i];
                    currentSum += nums[i];
                }
                else 
                {
                    state = 2;
                    result = Math.Max(result, sumOfPositive);
                    result = Math.Max(result, currentSum);

                    currentSum += nums[i];
                    if (currentSum <= 0)
                    {
                        currentSum = 0;
                        state = 0;
                    }
                }
            }
            else if (state == 2)
            {
                currentSum += nums[i];
                if (currentSum <= 0)
                {
                    currentSum = 0;
                    state = 0;
                }
                if (nums[i] > 0)
                {
                    state = 1;
                    sumOfPositive = nums[i];
                }
            }
        }
        
        if (allNegatives)
        {
            return maxNeg;
        }
        else 
        {
            result = Math.Max(result, sumOfPositive);
            result = Math.Max(result, currentSum);
        }
        return result;
    }
}
