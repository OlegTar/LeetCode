/*
You are given an m x n matrix board containing letters 'X' and 'O', capture regions that are surrounded:

Connect: A cell is connected to adjacent cells horizontally or vertically.
Region: To form a region connect every 'O' cell.
Surround: A region is surrounded if none of the 'O' cells in that region are on the edge of the board. Such regions are completely enclosed by 'X' cells.
To capture a surrounded region, replace all 'O's with 'X's in-place within the original board. You do not need to return anything.

 

Example 1:

Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]

Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]

Explanation:


In the above diagram, the bottom region is not captured because it is on the edge of the board and cannot be surrounded.

Example 2:

Input: board = [["X"]]

Output: [["X"]]

 

Constraints:

m == board.length
n == board[i].length
1 <= m, n <= 200
board[i][j] is 'X' or 'O'.
*/
public class Solution {
    public void Solve(char[][] board) {
        (var rows, var cols) = (board.Length, board[0].Length);
        rows--;
        cols--;
        HashSet<(int i, int j)> visited = new();
        for (var i = 1; i < rows; i++)
        {
            for (var j = 1; j < cols; j++)
            {
                if (board[i][j] == 'O') {
                    visited.Clear();
                    if (isSurrounded(board, i, j, visited)) {
                        capture(board, i, j);
                    }
                }
            }
        }
    }

    public bool isSurrounded(char[][] board, int i, int j, HashSet<(int i, int j)> visited)
    {
        visited.Add((i, j));
        if (i == 0 || j == 0 || i == board.Length - 1 || j == board[0].Length - 1)
        {  
            return false;
        }

        if (board[i - 1][j] == 'O' && !visited.Contains((i - 1, j)) && !isSurrounded(board, i - 1, j, visited)) 
        {
            return false;
        }

        if (board[i + 1][j] == 'O' && !visited.Contains((i + 1, j)) && !isSurrounded(board, i + 1, j, visited)) 
        {
            return false;
        }

        if (board[i][j - 1] == 'O' && !visited.Contains((i, j - 1)) && !isSurrounded(board, i, j - 1, visited)) 
        {
            return false;
        }

        if (board[i][j + 1] == 'O' && !visited.Contains((i, j + 1)) && !isSurrounded(board, i, j + 1, visited)) 
        {
            return false;
        }

        return true;
    }

    public void capture(char[][] board, int i, int j)
    {
        if (i == 0 || j == 0 || i == board.Length - 1 || j == board[0].Length - 1)
        {  
            return;
        }
        board[i][j] = 'X';
        if (board[i - 1][j] == 'O') 
        {
            capture(board, i - 1, j);
        }

        if (board[i + 1][j] == 'O') 
        {
            capture(board, i + 1, j);
        }

        if (board[i][j - 1] == 'O') 
        {
            capture(board, i, j - 1);
        }

        if (board[i][j + 1] == 'O') 
        {
            capture(board, i, j + 1);
        }
    }
}
