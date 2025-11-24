/*
Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.

 

Example 1:


Input: n = 3
Output: [[1,2,3],[8,9,4],[7,6,5]]
Example 2:

Input: n = 1
Output: [[1]]
 

Constraints:

1 <= n <= 20
*/
public class Solution {
    enum Direction {
        Right,
        Down,
        Left,
        Up
    };
    public int[][] GenerateMatrix(int n) {
        var matrix = new int[n][];
        for (var i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        var (top, left, bottom, right) = (0, 0, n - 1, n - 1);
        var (row, col) = (0, 0);
        var count = n * n;
        var direction = Direction.Right;
        
        for (var i = 1; i <= count;)
        {
            switch (direction)
            {
                case Direction.Right:
                    for (var j = col; j <= right; j++)
                    {
                        matrix[row][j] = i++;
                    }
                    direction = Direction.Down;
                    col = right;
                    top++;
                    row++;
                    break;
                case Direction.Down:
                    for (var j = row; j <= bottom; j++)
                    {
                        matrix[j][col] = i++;
                    }
                    direction = Direction.Left;
                    row = bottom;
                    right--;
                    col--;
                    break;
                case Direction.Left:
                    for (var j = col; j >= left; j--)
                    {
                        matrix[row][j] = i++;
                    }
                    direction = Direction.Up;
                    bottom--;
                    row--;
                    col = left;
                    break;
                case Direction.Up:
                    for (var j = row; j >= top; j--)
                    {
                        matrix[j][col] = i++;
                    }
                    direction = Direction.Right;
                    left++;
                    col++;
                    row = top; 
                    break;
            }
        }

        return matrix;
    }
}
