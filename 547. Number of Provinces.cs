/*There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b, and city b is connected directly with city c, then city a is connected indirectly with city c.

A province is a group of directly or indirectly connected cities and no other cities outside of the group.

You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly connected, and isConnected[i][j] = 0 otherwise.

Return the total number of provinces.

 

Example 1:


Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
Output: 2
Example 2:


Input: isConnected = [[1,0,0],[0,1,0],[0,0,1]]
Output: 3
 

Constraints:

1 <= n <= 200
n == isConnected.length
n == isConnected[i].length
isConnected[i][j] is 1 or 0.
isConnected[i][i] == 1
isConnected[i][j] == isConnected[j][i]*/

public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        var n = isConnected.Length;
        var count = 0;
        var seen = new bool[n];
        for (var i = 0; i < isConnected.Length; i++)
        {
            if (seen[i]) continue;
            count++;
            var stack = new Stack<int>();
            stack.Push(i);
            while (stack.Count > 0)
            {
                var province = stack.Pop();
                for (var j = 0; j < n; j++)
                {
                    if (j == province) continue;
                    if (isConnected[province][j] == 1 && !seen[j])
                    {
                        seen[j] = true;
                        stack.Push(j);
                    }
                }
            }
        }
        return count;
    }
}
