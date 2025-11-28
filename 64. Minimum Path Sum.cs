/*Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.

Example 1:
Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
Output: 7
Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.
Example 2:

Input: grid = [[1,2,3],[4,5,6]]
Output: 12

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 200
0 <= grid[i][j] <= 200*/
public class Solution {
    public int MinPathSum(int[][] grid) {
        var dp = new int[grid.Length, grid[0].Length];
        dp[0, 0] = grid[0][0];
        
        for (var i = 1; i < grid[0].Length; i++)
        {
            dp[0, i] = dp[0, i - 1] + grid[0][i];
        }

        for (var i = 1; i < grid.Length; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + grid[i][0];
        }

        for (var i = 1; i < grid.Length; i++)
        {
            for (var j = 1; j < grid[0].Length; j++)
            {
                dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
            }
        }

        return dp[grid.Length - 1, grid[0].Length - 1];
    }
}
