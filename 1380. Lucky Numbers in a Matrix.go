/*
Given an m x n matrix of distinct numbers, return all lucky numbers in the matrix in any order.

A lucky number is an element of the matrix such that it is the minimum element in its row and maximum in its column.

 

Example 1:

Input: matrix = [[3,7,8],[9,11,13],[15,16,17]]
Output: [15]
Explanation: 15 is the only lucky number since it is the minimum in its row and the maximum in its column.
Example 2:

Input: matrix = [[1,10,4,2],[9,3,8,7],[15,16,17,12]]
Output: [12]
Explanation: 12 is the only lucky number since it is the minimum in its row and the maximum in its column.
Example 3:

Input: matrix = [[7,8],[1,2]]
Output: [7]
Explanation: 7 is the only lucky number since it is the minimum in its row and the maximum in its column.
 

Constraints:

m == mat.length
n == mat[i].length
1 <= n, m <= 50
1 <= matrix[i][j] <= 105.
All elements in the matrix are distinct.
*/
func luckyNumbers(matrix [][]int) []int {
    var minInRows []int
    var maxInColumns []int

    for i := 0; i < len(matrix); i++ {
        minInRow := matrix[i][0]
        for j := 0; j < len(matrix[i]); j++ {
            minInRow = min(minInRow, matrix[i][j]) 
        }
        minInRows = append(minInRows, minInRow)
    }

    for i := 0; i < len(matrix[0]); i++ {
        maxInColumn := matrix[0][i]
        for j := 0; j < len(matrix); j++ {
            maxInColumn = max(maxInColumn, matrix[j][i]) 
        }
        maxInColumns = append(maxInColumns, maxInColumn)
    }

    var result []int

    for i := 0; i < len(matrix); i++ {
        for j := 0; j < len(matrix[i]); j++ {
            if (matrix[i][j] == minInRows[i] && 
                matrix[i][j] == maxInColumns[j]) {
                result = append(result, matrix[i][j]) 
            }
        }
    }

    return result
}
