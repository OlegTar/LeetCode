/*
You are given an m x n grid where each cell can have one of three values:

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
class Solution {
    public int orangesRotting(int[][] grid) {
        Queue<int[]> queue = new ArrayDeque<>();
        int countFreshOranges = 0;

        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[i].length; j++) {
                if (grid[i][j] == 2) {
                    queue.offer(new int[] { i, j });
                }

                if (grid[i][j] == 1) {
                    countFreshOranges++;
                }
            }
        }

        List<int[]> newRottenOranges = new ArrayList<>();
        int minutes = 0;
        while (!queue.isEmpty() && countFreshOranges > 0) {
            newRottenOranges.clear();
            
            while (!queue.isEmpty()) {
                int[] coords = queue.poll();
                int row = coords[0];
                int col = coords[1];

                if (row > 0 && grid[row - 1][col] == 1) {
                    grid[row - 1][col] = 2;
                    countFreshOranges--;
                    newRottenOranges.add(new int[] { row - 1, col });
                }

                if (row < (grid.length - 1) && grid[row + 1][col] == 1) {
                    grid[row + 1][col] = 2;
                    countFreshOranges--;
                    newRottenOranges.add(new int[] { row + 1, col });
                }

                if (col > 0 && grid[row][col - 1] == 1) {
                    grid[row][col - 1] = 2;
                    countFreshOranges--;
                    newRottenOranges.add(new int[] { row, col - 1 });
                }

                if (col < (grid[row].length - 1) && grid[row][col + 1] == 1) {
                    grid[row][col + 1] = 2;
                    countFreshOranges--;
                    newRottenOranges.add(new int[] { row, col + 1 });
                }
            }

            minutes++;

            for (int[] coords : newRottenOranges) {
                queue.offer(coords);
            }
        }

        return countFreshOranges == 0 ? minutes : -1;
    }
}
