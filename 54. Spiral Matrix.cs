/*
Given an m x n matrix, return all elements of the matrix in spiral order.
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
-100 <= matrix[i][j] <= 100
*/

public class Solution {
    enum Direction {
        Right,
        Down,
        Left,
        Up
    }

    public IList<int> SpiralOrder(int[][] matrix) {        
        var passed = new bool[matrix.Length + 2][];
        for (var i = 0; i < passed.Length; i++)
        {
            passed[i] = new bool[matrix[0].Length + 2];
        }

        for (var i = 0; i < passed[0].Length; i++)
        {
            passed[0][i] = true;
            passed[^1][i] = true;
        }

        for (var i = 0; i < passed.Length; i++)
        {
            passed[i][0] = true;
            passed[i][^1] = true;
        }

        var count = matrix.Length * matrix[0].Length;
        var direction = Direction.Right;
        var list = new List<int>();

        var row = 0;
        var column = 0;
        var passedRow = 1;
        var passedColumn = 1;

        for (var i = 0; i < count; i++)
        {
            list.Add(matrix[row][column]);
            passed[passedRow][passedColumn] = true;

            switch (direction)
            {
                case Direction.Right:                    
                    if (passed[passedRow][passedColumn + 1]) 
                    {
                        row++;
                        passedRow++;
                        direction = Direction.Down;
                    }
                    else 
                    {
                        column++;
                        passedColumn++;
                    }
                    break;
                case Direction.Down:
                    if (passed[passedRow + 1][passedColumn]) 
                    {
                        column--;
                        passedColumn--;
                        direction = Direction.Left;
                    }
                    else 
                    {
                        row++;
                        passedRow++;
                    }
                    break;
                case Direction.Left:
                    if (passed[passedRow][passedColumn - 1]) 
                    {
                        row--;
                        passedRow--;
                        direction = Direction.Up;
                    }
                    else 
                    {
                        column--;
                        passedColumn--;
                    }
                    break;
                case Direction.Up:
                    if (passed[passedRow - 1][passedColumn]) 
                    {
                        column++;
                        passedColumn++;
                        direction = Direction.Right;
                    }
                    else 
                    {
                        row--;
                        passedRow--;
                    }
                    break;
            }
        }

        return list;
    }
}
