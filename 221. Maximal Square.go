/*Given an m x n binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.

 

Example 1:


Input: matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
Output: 4
Example 2:


Input: matrix = [["0","1"],["1","0"]]
Output: 1
Example 3:

Input: matrix = [["0"]]
Output: 0
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 300
matrix[i][j] is '0' or '1'.*/
func maximalSquare(matrix [][]byte) int {
    m, n := len(matrix), len(matrix[0])
    dp := make([][]int, m)

    for i := 0; i < m; i++ {
        dp[i] = make([]int, n)
    }

    result := 0
    for i := 0; i < m; i++ {
        if (matrix[i][0] == '1') {
            dp[i][0] = 1
            result = 1
        }
    }

    for j := 0; j < n; j++ {
        if (matrix[0][j] == '1') {
            dp[0][j] = 1
            result = 1
        }
    }

    for i := 1; i < m; i++ {
        for j := 1; j < n; j++ {
            if (matrix[i][j] == '0') {
                continue;
            }

            size := int(min(dp[i - 1][j], dp[i][j - 1], dp[i - 1][j - 1]))
            dp[i][j] = size + 1
            result = max(result, dp[i][j] * dp[i][j])
        }
    }

    return result;
}
