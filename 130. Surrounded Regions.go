/*You are given an m x n matrix board containing letters 'X' and 'O', capture regions that are surrounded:

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
board[i][j] is 'X' or 'O'.*/
import "fmt";

type Point = struct{
    x int;
    y int;
}

func solve(board [][]byte)  {
    visited := map[Point]struct{}{}
    rows, cols := len(board), len(board[0])
    rows--;
    cols--;

    for i := 0; i < rows; i++ {
        for j := 0; j < cols; j++ {
            if (board[i][j] == 'O') {
                clear(visited);
                if (isSurrounded(board, i, j, visited)) {
                    capture(board, i, j);
                }
            }
        }
    }
}

func isSurrounded(board [][]byte, i, j int, visited map[Point]struct{}) bool {
    if (i == 0 || j == 0 || i == len(board) - 1 || j == len(board[0]) - 1) {  
        return false;
    }

    visited[Point{
        x: j,
        y: i,
    }] = struct{}{}

    if (board[i - 1][j] == 'O' && !contains(visited, i - 1, j) && !isSurrounded(board, i - 1, j, visited)) {
        return false;
    }

    if (board[i + 1][j] == 'O' && !contains(visited, i + 1, j) && !isSurrounded(board, i + 1, j, visited)) {
        return false;
    }

    if (board[i][j - 1] == 'O' && !contains(visited, i, j - 1) && !isSurrounded(board, i, j - 1, visited)) {
        return false;
    }

    if (board[i][j + 1] == 'O' && !contains(visited, i, j + 1) && !isSurrounded(board, i, j + 1, visited)) {
        return false;
    }

    return true;
}

func capture(board [][]byte, i, j int) {
    if (i == 0 || j == 0 || i == len(board) - 1 || j == len((board)[0]) - 1) {  
        return;
    }

    (board)[i][j] = 'X';
    if ((board)[i - 1][j] == 'O') {
        capture(board, i - 1, j);
    }

    if ((board)[i + 1][j] == 'O') {
        capture(board, i + 1, j);
    }

    if ((board)[i][j - 1] == 'O') {
        capture(board, i, j - 1);
    }

    if ((board)[i][j + 1] == 'O') {
        capture(board, i, j + 1);
    }
}

func contains(visited map[Point]struct{}, i, j int) bool {
    point := Point{
        x: j,
        y: i,
    }

    _, ok := (visited)[point];
    return ok;
}
