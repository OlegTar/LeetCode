public class Solution {
    char[] chars = ['1','2','3','4','5','6','7','8','9'];
    Dictionary<char, int> bits = new Dictionary<char, int>() {
        { '1', 1 },
        { '2', 2 },
        { '3', 4 },
        { '4', 8 },
        { '5', 16 },
        { '6', 32 },
        { '7', 64 },
        { '8', 128 },
        { '9', 256 }
    };

    int[] initRows = new int[9];
    int[] initCols = new int[9];
    int[] initBoxes = new int[9];
    int[] rows = new int[9];
    List<(int, int)> freeCells = new List<(int, int)>(81);
        
    public void SolveSudoku(char[][] board) {
        for (var i = 0; i < 9; i++)
        {
            var boxStartRow = (i / 3) * 3;
            var boxStartColumn = (i * 3) % 9;

            for (var j = 0; j < 9; j++)
            {                
                if (board[i][j] != '.')
                {              
                    initRows[i] |= bits[board[i][j]];
                    rows[i] |= 1 << j;                                    
                }
                else 
                {
                    freeCells.Add((i, j));
                }

                if (board[j][i] != '.')
                {
                    initCols[i] |= bits[board[j][i]];
                }                

                var boxRow = boxStartRow + (j / 3);
                var boxCol = boxStartColumn + (j % 3);

                if (board[boxRow][boxCol] != '.')
                {
                    initBoxes[i] |= bits[board[boxRow][boxCol]];
                }
            }
        }    

        Solve(0);              

        bool Solve(int index)
        {        
            if (index >= freeCells.Count)
            {
                return true;
            }

            var (row, col) = freeCells[index];

            if ((rows[row] & (1 << col)) != 0)
            {
                return Solve(index + 1);
            }

            var ocChars = 0;        

            ocChars |= initRows[row];
            ocChars |= initCols[col];
            var boxN = ((row / 3) * 3) + (col / 3);
            ocChars |= initBoxes[boxN];

            if (ocChars == 511)
            {                
                return false;
            }

            for (var i = 0; i < 9; i++)
            {
                var idx = 1 << i;
                if ((ocChars & idx) > 0)
                {
                    continue;
                }

                board[row][col] = chars[i];

                initRows[row] |= idx;
                initCols[col] |= idx;
                initBoxes[boxN] |= idx;
                rows[row] |= (1 << col);
                            
                var resultNext = Solve(index + 1);
                if (resultNext) 
                {
                    return true;
                }
                else 
                {
                    initRows[row] ^= idx;
                    initCols[col] ^= idx;
                    initBoxes[boxN] ^= idx;
                    rows[row] ^= (1 << col);
                }
            }

            return false;                
        }     
    }   
}
