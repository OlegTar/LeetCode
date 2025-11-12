/*
Given an integer numRows, return the first numRows of Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:


 

Example 1:

Input: numRows = 5
Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]
Example 2:

Input: numRows = 1
Output: [[1]]
 

Constraints:

1 <= numRows <= 30
*/
public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var result = new List<IList<int>>();
        for (var i = 0; i < numRows; i++)
        {
            var list = new List<int>(new int[i + 1]);
            list[0] = 1;
            list[^1] = 1;
            result.Add(list);
            for (var j = 1; j < i; j++)
            {
                result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
            }
        }
        return result;
    }
}
