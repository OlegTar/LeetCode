/*Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

You must do it in place.

 

Example 1:


Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
Output: [[1,0,1],[0,0,0],[1,0,1]]
Example 2:


Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]
 

Constraints:

m == matrix.length
n == matrix[0].length
1 <= m, n <= 200
-231 <= matrix[i][j] <= 231 - 1
 

Follow up:

A straightforward solution using O(mn) space is probably a bad idea.
A simple improvement uses O(m + n) space, but still not the best solution.
Could you devise a constant space solution?*/
func setZeroes(matrix [][]int)  {
    m := len(matrix)
    n := len(matrix[0])
    
    firstRowHasZero := false
    firstColHasZero := false

    for i := 0; i < n; i++ {
        if matrix[0][i] == 0 {
            firstRowHasZero = true
            break
        }
    }

    for i := 0; i < m; i++ {
        if matrix[i][0] == 0 {
            firstColHasZero = true
            break
        }
    }

    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if matrix[i][j] == 0 {
                matrix[i][0] = 0
                matrix[0][j] = 0
            }
        }
    }

    for i := 1; i < m; i++ {
        if matrix[i][0] != 0 {
            continue;
        }
        for j := 0; j < n; j++ {
            matrix[i][j] = 0
        }
    }

    for i := 1; i < n; i++ {
        if matrix[0][i] != 0 {
            continue;
        }
        for j := 0; j < m; j++ {
            matrix[j][i] = 0
        }
    }

    if (firstRowHasZero) {
        for i := 0; i < n; i++ {
            matrix[0][i] = 0
        }
    }

    if (firstColHasZero) {
        for i := 0; i < m; i++ {
            matrix[i][0] = 0
        }
    }
}
