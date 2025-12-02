/*Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.

We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

You must solve this problem without using the library's sort function.

 

Example 1:

Input: nums = [2,0,2,1,1,0]
Output: [0,0,1,1,2,2]
Example 2:

Input: nums = [2,0,1]
Output: [0,1,2]
 

Constraints:

n == nums.length
1 <= n <= 300
nums[i] is either 0, 1, or 2.*/

public class Solution {
    public void SortColors(int[] nums) {
        var freq = new int[3];
        foreach (var color in nums)
        {
            freq[color]++;
        }

        var pointer = 0;
        for (var color = 0; color < freq.Length; color++)
        {
            var count = freq[color];
            for (var j = 0; j < count; j++)
            {
                nums[pointer++] = color;
            }
        }
    }
}
