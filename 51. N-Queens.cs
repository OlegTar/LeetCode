/*
The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.

Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the answer in any order.

Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space, respectively.
Example 1:

Input: n = 4
Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above
Example 2:

Input: n = 1
Output: [["Q"]]

Constraints:

1 <= n <= 9
*/
public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        var chessboard = new char[n][];
        for (var i = 0; i < n; i++)
        {
            chessboard[i] = new char[n];
            Array.Fill(chessboard[i], '.');
        }
        IList<IList<string>> result = new List<IList<string>>();
        Solve(n, 0, chessboard, result);
        return result;
    }

    public void Solve(int n, int start, char[][] chessboard, IList<IList<string>> result)
    {
        if (n == 0)
        {
            var solution = new List<string>();
            for (var row = 0; row < chessboard.Length; row++)
            {
                solution.Add(new string(chessboard[row]));
            }
            result.Add(solution);
            return;
        }

        var last = chessboard.Length * chessboard.Length - n + 1;
        for (var i = start; i < last; i++)
        {
            var startRow = i / chessboard.Length;
            var startCol = i % chessboard.Length;

            var found = false;

            for (var j = 0; j < chessboard.Length; j++)
            {
                if (chessboard[startRow][j] == 'Q' || chessboard[j][startCol] == 'Q')
                {
                    found = true;
                    break;
                }
            }

            for (int j = startRow - 1, k = startCol - 1; j >= 0 && k >= 0; j--, k--)
            {
                if (chessboard[j][k] == 'Q')
                {
                    found = true;
                    break;
                }
            }

            for (int j = startRow - 1, k = startCol + 1; j >= 0 && k < chessboard.Length; j--, k++)
            {
                if (chessboard[j][k] == 'Q')
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                continue;
            }

            chessboard[startRow][startCol] = 'Q';
            Solve(n - 1, i + 1, chessboard, result);
            chessboard[startRow][startCol] = '.';
        }
    }
}
