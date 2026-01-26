/*Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

 

Example 1:

Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1
Example 2:

Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
 

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 300
grid[i][j] is '0' or '1'.*/
public class Solution {
    private static int[][] movements = new int[][]
    {
        new int[] { -1, 0 },
        new int[] { 0, 1 },
        new int[] { 1, 0 },
        new int[] { 0, -1 }
    };

    public int NumIslands(char[][] grid) {
        bool[][] visited = new bool[grid.Length][];
        for (int i = 0; i < visited.Length; i++)
        {
            visited[i] = new bool[grid[0].Length];
        }

        int regions = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (!visited[i][j] && grid[i][j] == '1')
                {
                    dfs(i, j, grid, visited);
                    regions++;
                }
            }
        }

        return regions;
    }

    public void dfs(int i, int j, char[][] grid, bool[][] visited)
    {
        Stack<(int, int)> stack = new();
        stack.Push((i, j));

        while (stack.Count > 0)
        {
            (int row, int column) = stack.Pop();
            visited[row][column] = true;
            foreach (int[] move in movements)
            {
                int newRow = row + move[0];
                int newColumn = column + move[1];

                if (newRow < 0 || newColumn < 0 || newRow >= grid.Length
                    || newColumn >= grid[0].Length)
                {
                    continue;
                }

                if (visited[newRow][newColumn] || grid[newRow][newColumn] == '0')
                {
                    continue;
                }

                stack.Push((newRow, newColumn));
            }
        }
    }
}
