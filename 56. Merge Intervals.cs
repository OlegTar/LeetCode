/*
Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

Example 1:

Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
Example 2:

Input: intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.
Example 3:

Input: intervals = [[4,7],[1,4]]
Output: [[1,7]]
Explanation: Intervals [1,4] and [4,7] are considered overlapping.
 

Constraints:

1 <= intervals.length <= 104
intervals[i].length == 2
0 <= starti <= endi <= 104
*/
public class Solution {
    public int[][] Merge(int[][] intervals) {
        var result = new List<int[]>();
        Array.Sort(intervals, Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));
        result.Add(intervals[0]);
        for (var i = 1; i < intervals.Length; i++)
        {
            var lastInterval = result[^1];
            var currentInterval = intervals[i];
            if (
                (currentInterval[0] >= lastInterval[0] && currentInterval[0] <= lastInterval[1]) ||
                (currentInterval[1] >= lastInterval[0] && currentInterval[1] <= lastInterval[1])
            )
            {
                lastInterval[0] = Math.Min(lastInterval[0], currentInterval[0]);
                lastInterval[1] = Math.Max(lastInterval[1], currentInterval[1]);
            }
            else 
            {
                result.Add(currentInterval);
            }
        }

        return result.ToArray();
    }
}
