/*
Given an m x n board of characters and a list of strings words, return all words on the board.

Each word must be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.

 

Example 1:


Input: board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]], words = ["oath","pea","eat","rain"]
Output: ["eat","oath"]
Example 2:


Input: board = [["a","b"],["c","d"]], words = ["abcb"]
Output: []
 

Constraints:

m == board.length
n == board[i].length
1 <= m, n <= 12
board[i][j] is a lowercase English letter.
1 <= words.length <= 3 * 104
1 <= words[i].length <= 10
words[i] consists of lowercase English letters.
All the strings of words are unique.*/
import "strings"
type Trie struct{
    letters [26]*Trie
    isEnd bool
    word string
}

func (trie *Trie) AddWord(word string) {
    node := trie
    for i := 0; i < len(word); i++ {
        letter := word[i] - 'a'
        if node.letters[letter] == nil {
            node.letters[letter] = &Trie{
                letters: [26]*Trie{},
            }
        }
        node = node.letters[letter]
    }
    node.isEnd = true
    node.word = word
}

func findWords(board [][]byte, words []string) []string {
    trie := Trie{
        letters: [26]*Trie{},
    }
    for _, word := range(words) {
        trie.AddWord(word)
    }

    m, n := len(board), len(board[0])

    visited := make([][]bool, m)
    for i := 0; i < len(visited); i++ {
        visited[i] = make([]bool, n)
    }

    result := []string{}

    for row := 0; row < m; row++ {
        for column := 0; column < n; column++ {
            dfs(&trie, board, visited, row, column, &result)
        }
    }

    return result
}

func dfs(node *Trie, board [][]byte, visited [][]bool, row, column int, result *[]string) {
    if (visited[row][column]) {
        return;
    }

    letter := board[row][column]
    index := letter - 'a'
    if (node.letters[index] == nil) {
        return;
    }

    childNode := node.letters[index]

    if (childNode.isEnd) {
        *result = append(*result, childNode.word)
        childNode.isEnd = false//to avoid duplicates
    }

    visited[row][column] = true
    
    if (row > 0) {
        dfs(childNode, board, visited, row - 1, column, result)
    }

    if (row < len(board) - 1) {
        dfs(childNode, board, visited, row + 1, column, result)
    }

    if (column > 0) {
        dfs(childNode, board, visited, row, column - 1, result)
    }

    if (column < len(board[0]) - 1) {
        dfs(childNode, board, visited, row, column + 1, result)
    }

    visited[row][column] = false
}
