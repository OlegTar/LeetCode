/*
Given a triangle array, return the minimum path sum from top to bottom.

For each step, you may move to an adjacent number of the row below. More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.

 

Example 1:

Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
Output: 11
Explanation: The triangle looks like:
   2
  3 4
 6 5 7
4 1 8 3
The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).
Example 2:

Input: triangle = [[-10]]
Output: -10
 

Constraints:

1 <= triangle.length <= 200
triangle[0].length == 1
triangle[i].length == triangle[i - 1].length + 1
-104 <= triangle[i][j] <= 104
 

Follow up: Could you do this using only O(n) extra space, where n is the total number of rows in the triangle?
*/
func minimumTotal(triangle [][]int) int {
    if (len(triangle) == 1) {
        return triangle[0][0]
    }

    dp := make([][]int, 2)
    for i := 0; i < len(dp); i++ {
        dp[i] = make([]int, len(triangle[len(triangle) - 1]))
    }
    dp[0][0] = triangle[0][0]
    row, prevRow := 1, 0
    for i := 1; i < len(triangle); i++ {
        row = i % 2
        prevRow = 1 - row
        dp[row][0] = dp[prevRow][0] + triangle[i][0]
        
        for j := 1; j < i; j++ {
            dp[row][j] = min(dp[prevRow][j - 1], dp[prevRow][j]) + triangle[i][j]
        }

        dp[row][i] = dp[prevRow][i - 1] + triangle[i][len(triangle[i]) - 1]
    }

    result := dp[row][0]
    for i := 1; i < len(dp[row]); i++ {
        result = min(result, dp[row][i])
    }
    return result
}
