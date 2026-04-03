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
func numIslands(grid [][]byte) int {
    rows, cols := len(grid), len(grid[0])

    counter := 0;

    for i := 0; i < rows; i++ {
        for j := 0; j < cols; j++ {
            if (grid[i][j] == '1') {
                counter++
                dfs(grid, i, j);
            }
        }
    }

    return counter;
}

func dfs(grid [][]byte, i, j int) {
    if (grid[i][j] == '2' || grid[i][j] == '0') {
        return;
    }
    grid[i][j] = '2';
    if (i > 0) {
        dfs(grid, i - 1, j);
    }

    if (i < len(grid) - 1) {
        dfs(grid, i + 1, j);
    }

    if (j > 0) {
        dfs(grid, i, j - 1);
    }

    if (j < len(grid[0]) - 1) {
        dfs(grid, i, j + 1);
    }
}
