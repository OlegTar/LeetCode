/*Given an m x n matrix, return all elements of the matrix in spiral order.

 

Example 1:


Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]
Example 2:


Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 10
-100 <= matrix[i][j] <= 100*/
func spiralOrder(matrix [][]int) []int {
    var result []int
    var rows []bool
    var cols []bool

    for i := 0; i < len(matrix); i++ {
        rows = append(rows, false)
    }

    for i := 0; i < len(matrix[0]); i++ {
        cols = append(cols, false)
    }

    type Direction int
    const (
        right Direction = iota
        down
        left
        up
    )

    direction := right
    n := len(matrix) * len(matrix[0])
    var row, col int = 0, 0;

    for i := 0; i < n; {
        if (direction == right) {
            rows[row] = true
            for col < len(matrix[0]) {
                if cols[col] {
                    break
                }
                result = append(result, matrix[row][col])
                col++
                i++
            }

            col--
            row++
            direction = down
        } else if (direction == down) {
            cols[col] = true
            for row < len(matrix) {
                if rows[row] {
                    break
                }
                result = append(result, matrix[row][col])
                row++
                i++
            }

            row--
            col--
            direction = left
        } else if (direction == left) {
            rows[row] = true
            for col >= 0 {
                if cols[col] {
                    break
                }
                result = append(result, matrix[row][col])
                col--
                i++
            }

            col++
            row--
            direction = up
        } else {
            cols[col] = true
            for row >= 0 {
                if rows[row] {
                    break
                }
                result = append(result, matrix[row][col])
                row--
                i++
            }

            row++
            col++
            direction = right
        }
    }

    return result
}
