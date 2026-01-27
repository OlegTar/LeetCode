/*You are given an m x n binary matrix grid.

A move consists of choosing any row or column and toggling each value in that row or column (i.e., changing all 0's to 1's, and all 1's to 0's).

Every row of the matrix is interpreted as a binary number, and the score of the matrix is the sum of these numbers.

Return the highest possible score after making any number of moves (including zero moves).

 

Example 1:


Input: grid = [[0,0,1,1],[1,0,1,0],[1,1,0,0]]
Output: 39
Explanation: 0b1111 + 0b1001 + 0b1111 = 15 + 9 + 15 = 39
Example 2:

Input: grid = [[0]]
Output: 1
 

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 20
grid[i][j] is either 0 or 1.*/
public class Solution {
    public int MatrixScore(int[][] grid) {
        for (int i = 0; i < grid.Length; i++)
        {
            if (grid[i][0] == 0)
            {
                FlipRow(grid[i]);
            }
        }

        for (int i = 1; i < grid[0].Length; i++)
        {
            int countZero = GetCountZero(grid, i);
            int countOne = grid.Length - countZero;
            if (countZero > countOne)
            {
                FlipCol(grid, i);
            }
        }

        int sum = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            sum += ConvertToDigit(grid[i]);
        }

        return sum;
    }

    public void FlipRow(int[] row)
    {
        for (int i = 0; i < row.Length; i++)
        {
            row[i] = 1 - row[i];
        }
    }

    public int GetCountZero(int[][] grid, int col)
    {
        int count = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            if (grid[i][col] == 0)
            {
                count++;
            }
        }
        return count;
    }

    public void FlipCol(int[][] grid, int col)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i][col] = 1 - grid[i][col];
        }
    }

    public int ConvertToDigit(int[] row)
    {
        int result = 0;
        int weight = 1;
        for (int i = row.Length - 1; i >= 0; i--)
        {
            result += row[i] * weight;
            weight <<= 1;
        }
        return result;
    }
}
