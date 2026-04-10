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
func exist(board [][]byte, word string) bool {
    end := len(board) * len(board[0])
    visited := make([][]bool, len(board))
    for i := 0; i < len(board); i++ {
        visited[i] = make([]bool, len(board[0]))
    }
    
    for i := 0; i < end; i++ {
        if (check(board, i, visited, word)) {
            return true
        }
    }
    return false
}

func check(board [][]byte, pos int, visited [][]bool, word string) bool {
    rowLength := len(board[0])
    row := pos / rowLength
    col := pos % rowLength    

    if (visited[row][col]) {
        return false;
    }

    if board[row][col] != word[0] {
        return false
    }

    if (len(word) == 1) {
        return true
    }

    visited[row][col] = true
    result := false

    if (row > 0) {
        result = check(board, pos - rowLength, visited, word[1:])
        if (result) {
            return true;
        }
    }

    if (row < len(board) - 1) {
        result = check(board, pos + rowLength, visited, word[1:])
        if (result) {
            return true;
        }
    }

    if (col > 0) {
        result = check(board, pos - 1, visited, word[1:])
        if (result) {
            return true;
        }
    }

    if (col < rowLength - 1) {
        result = check(board, pos + 1, visited, word[1:])
        if (result) {
            return true;
        }
    }
    
    visited[row][col] = false
    return false
}
