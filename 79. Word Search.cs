/*Given an m x n grid of characters board and a string word, return true if word exists in the grid.

The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.

 

Example 1:


Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
Output: true
Example 2:


Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
Output: true
Example 3:


Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
Output: false
 

Constraints:

m == board.length
n = board[i].length
1 <= m, n <= 6
1 <= word.length <= 15
board and word consists of only lowercase and uppercase English letters.
 

Follow up: Could you use search pruning to make your solution faster with a larger board?*/
public class Solution {
    public bool Exist(char[][] board, string word) {
        var visited = new HashSet<(int, int)>();
        var len = board.Length * board[0].Length;        
        
        for (var i = 0; i < len; i++)
        {
            var row = i / board[0].Length;
            var column = i % board[0].Length;
            
            if (Find(row, column, word, board, visited)) 
            {
                return true;
            }
            visited.Clear();
        }

        return false;
    }

    public bool Find(int i, int j, string word, char[][] board, HashSet<(int, int)> visited)
    {
        if (word.Length == 0)
        {
            return true;
        }

        if (visited.Contains((i, j)))
        {
            return false;
        }

        if (board[i][j] != word[0])
        {
            return false;
        }

        if (word.Length == 1)
        {
            return true;
        }

        bool result = false;
        visited.Add((i, j));


        if (j < (board[i].Length - 1))
        {
            result = Find(i, j + 1, word.Substring(1), board, visited);
        }
        
        if (result)
        {
            return true;
        }

        if (j > 0)
        {
            result = Find(i, j - 1, word.Substring(1), board, visited);
        }

        if (result)
        {
            return true;
        }

        if (i < (board.Length - 1))
        {
            result = Find(i + 1, j, word.Substring(1), board, visited);
        }

        if (result)
        {
            return true;
        }

        if (i > 0)
        {
            result = Find(i - 1, j, word.Substring(1), board, visited);
        }
        visited.Remove((i, j));

        return result;
    }
}
