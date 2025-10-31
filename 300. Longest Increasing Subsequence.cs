/*Given an integer array nums, return the length of the longest strictly increasing subsequence.

 

Example 1:

Input: nums = [10,9,2,5,3,7,101,18]
Output: 4
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
Example 2:

Input: nums = [0,1,0,3,2,3]
Output: 4
Example 3:

Input: nums = [7,7,7,7,7,7,7]
Output: 1*/
public class Solution 
{
    public int LengthOfLIS(int[] nums) {
        var lengths = new List<int>(nums.Length);
        lengths.Add(nums[0]);

        for (var i = 1; i < nums.Length; i++)
        {
            var left = 0;
            var right = lengths.Count - 1;            

            while (left <= right)
            {                
                var mid = left + (right - left) / 2;

                if (lengths[mid] < nums[i]) 
                {
                    left = mid + 1;
                }
                else 
                {
                    right = mid - 1;
                }
            }

            if (left < lengths.Count) 
            {
                lengths[left] = nums[i];
            }
            else 
            {
                lengths.Add(nums[i]);
            }
        }

        return lengths.Count;
    }
}
