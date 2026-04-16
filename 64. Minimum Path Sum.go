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
func minPathSum(grid [][]int) int {
    n, m := len(grid), len(grid[0])
    dp := make([][]int, 2)
    for i := 0; i < len(dp); i++ {
        dp[i] = make([]int, m)
    }

    dp[0][0] = grid[0][0]
    for i := 1; i < m; i++ {
        dp[0][i] = dp[0][i - 1] + grid[0][i]
    }

    prevRow, row := 0, 0
    for i := 1; i < n; i++ {
        row = i % 2
        prevRow = 1 - row
        dp[row][0] = dp[prevRow][0] + grid[i][0]
        for j := 1; j < m; j++ {
            dp[row][j] = min(dp[row][j - 1], dp[prevRow][j]) + grid[i][j]
        }
    }

    return dp[row][m - 1];
}
