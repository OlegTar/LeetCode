/*
Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

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
0 <= grid[i][j] <= 200
*/
public class Solution {
    public int MinPathSum(int[][] grid) {
        return Solve(0, 0, grid, 0, new int[grid.Length, grid[0].Length]);
    }

    public int Solve(int i, int j, int[][] grid, int currentSum, int[,] memo)
    {   
        if (memo[i, j] != 0)
        {
            return memo[i, j];
        }     

        if (i == grid.Length - 1 && j == grid[0].Length - 1)
        {
            return grid[i][j];
        }

        int sum1 = int.MaxValue;
        int sum2 = int.MaxValue;

        if (i < grid.Length - 1)
        {
            sum1 = grid[i][j] + Solve(i + 1, j, grid, currentSum, memo);
        }

        if (j < grid[0].Length - 1)
        {
            sum2 = grid[i][j] + Solve(i, j + 1, grid, currentSum, memo);
        }

        memo[i, j] = Math.Min(sum1, sum2);
        
        return memo[i, j];
    }
}
