/*You are given an m x n grid where each cell can have one of three values:

0 representing an empty cell,
1 representing a fresh orange, or
2 representing a rotten orange.
Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.

 

Example 1:


Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
Output: 4
Example 2:

Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
Output: -1
Explanation: The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.
Example 3:

Input: grid = [[0,2]]
Output: 0
Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.
 

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 10
grid[i][j] is 0, 1, or 2.*/
public class Solution {
    public int OrangesRotting(int[][] grid) {
        Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
        
        int countFreshOranges = 0; 

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 2)
                {
                    queue.Enqueue((i, j));
                }

                if (grid[i][j] == 1)
                {
                    countFreshOranges++;
                }
            }
        }

        int minutes = 0;
        var newRottenOranges = new List<(int row, int col)>();

        while (queue.Count > 0 && countFreshOranges > 0)
        {
            newRottenOranges.Clear();

            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();

                if (row > 0 && grid[row - 1][col] == 1)
                {
                    grid[row - 1][col] = 2;
                    countFreshOranges--;
                    newRottenOranges.Add((row - 1, col));
                }

                if (row < (grid.Length - 1) && grid[row + 1][col] == 1)
                {
                    grid[row + 1][col] = 2;
                    countFreshOranges--;
                    newRottenOranges.Add((row + 1, col));
                }

                if (col > 0 && grid[row][col - 1] == 1)
                {
                    grid[row][col - 1] = 2;
                    countFreshOranges--;
                    newRottenOranges.Add((row, col - 1));
                }

                if (col < (grid[row].Length - 1) && grid[row][col + 1] == 1)
                {
                    grid[row][col + 1] = 2;
                    countFreshOranges--;
                    newRottenOranges.Add((row, col + 1));
                }
            }

            minutes++;

            foreach (var newRottenCoords in newRottenOranges)
            {
                queue.Enqueue(newRottenCoords);
            }
        }

        return countFreshOranges == 0 ? minutes : -1;
    }
}
