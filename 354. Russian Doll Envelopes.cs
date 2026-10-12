/*
You are given a 2D array of integers envelopes where envelopes[i] = [wi, hi] represents the width and the height of an envelope.

One envelope can fit into another if and only if both the width and height of one envelope are greater than the other envelope's width and height.

Return the maximum number of envelopes you can Russian doll (i.e., put one inside the other).

Note: You cannot rotate an envelope.

 

Example 1:

Input: envelopes = [[5,4],[6,4],[6,7],[2,3]]
Output: 3
Explanation: The maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]).
Example 2:

Input: envelopes = [[1,1],[1,1],[1,1]]
Output: 1
 

Constraints:

1 <= envelopes.length <= 105
envelopes[i].length == 2
1 <= wi, hi <= 105
*/
public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
        envelopes.Sort((a, b) => {
            if (a[0] != b[0])
            {
                return a[0].CompareTo(b[0]);
            }
            return -a[1].CompareTo(b[1]);
        });
        
        //Console.WriteLine("[" + string.Join(",", envelopes.Select(env => "[" + string.Join(", ", env) + "]")) + "]");
       
        var n = envelopes.Length;
        var size = 0;
        foreach (var env in envelopes)
        {
            var left = 0;
            var right = size;
            
            while (left < right)
            {
                var mid = (left + right) / 2;
                if (envelopes[mid][1] < env[1])
                {
                    left = mid + 1;
                }
                else 
                {
                    right = mid;
                }
            }
            
            envelopes[left] = env;
            if (left == size)
            { 
                size++;
            }
        }
        
        return size;
    }
}
