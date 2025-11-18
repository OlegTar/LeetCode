/*
The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.

Given an integer n, return the number of distinct solutions to the n-queens puzzle.

 

Example 1:


Input: n = 4
Output: 2
Explanation: There are two distinct solutions to the 4-queens puzzle as shown.
Example 2:

Input: n = 1
Output: 1
 

Constraints:

1 <= n <= 9
*/
public class Solution {
    public int TotalNQueens(int n) {
        int result = 0;
        Solve(n, n, new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), ref result);
        return result;
    }

    public void Solve(int row, int n, HashSet<int> cols, HashSet<int> diag1, HashSet<int> diag2, ref int result)
    {
        if (row == 0)
        {
            result++;
            return;
        }

        for (var col = 0; col < n; col++)
        {
            int d1 = row - col;
            int d2 = row + col;

            if (cols.Contains(col) || diag1.Contains(d1) || diag2.Contains(d2)) continue;

            cols.Add(col);
            diag1.Add(d1);
            diag2.Add(d2);

            Solve(row - 1, n, cols, diag1, diag2, ref result);
            
            cols.Remove(col);
            diag1.Remove(d1);
            diag2.Remove(d2);
        }
    }
}
