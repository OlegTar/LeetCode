/*
Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
Example 1:


Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.
Example 2:

Input: height = [4,2,0,3,2,5]
Output: 9
 

Constraints:

n == height.length
1 <= n <= 2 * 104
0 <= height[i] <= 105
*/

public class Solution {
    public int Trap(int[] height) {
        int sum = 0;
        int i = 0;
        while (i < height.Length)
        {
            if (height[i] == 0)
            {
                i++;
                continue;
            }
            int j = i + 1;
            while (j < height.Length && height[j] < height[i])
            {
                j++;
            }

            if (j < height.Length)
            {
                sum += Calculate(height, i, j);
            }
            i = j;
        }

        i = height.Length - 1;
        while (i >= 0)
        {
            if (height[i] == 0)
            {
                i--;
                continue;
            }
            int j = i - 1;
            while (j >= 0 && height[j] <= height[i])
            {
                j--;
            }

            if (j >= 0)
            {
                sum += Calculate(height, j, i);
            }

            i = j;
        }

        return sum;
    }

    public int Calculate(int[] heights, int i, int j)
    {
        int minHeight = Math.Min(heights[i], heights[j]);
        int sum = 0;

        for (int k = i + 1; k < j; k++)
        {
            sum += minHeight - heights[k];
        }

        return sum;
    }
}
