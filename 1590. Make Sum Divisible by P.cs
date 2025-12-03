/*
Given an integer array nums of unique elements, return all possible subsets (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
Example 2:

Input: nums = [0]
Output: [[],[0]]
 

Constraints:

1 <= nums.length <= 10
-10 <= nums[i] <= 10
All the numbers of nums are unique.
*/
public class Solution {
    public int MinSubarray(int[] nums, int p) {        
        var sum = 0;
        var sums = new int[nums.Length];        
        for (var i = 0; i < nums.Length; i++)
        {
            sum = (sum + nums[i]) % p;            
            sums[i] = sum;
        }        
        
        var reminder = sum % p;        
        if (reminder == 0)
        {
            return 0;
        }

        var prefixSum = new Dictionary<int, int>();
        prefixSum[0] = -1;

        var minLen = nums.Length;
        for (var i = 0; i < nums.Length && minLen != 1; i++)
        {
            sum = sums[i];
            var needed = (sum - reminder + p) %p;
            if (prefixSum.ContainsKey(needed))
            {
                minLen = Math.Min(minLen, i - prefixSum[needed]);
            }
            prefixSum[sum] = i;
        }

        return minLen == nums.Length ? -1 : minLen;
    }
}
