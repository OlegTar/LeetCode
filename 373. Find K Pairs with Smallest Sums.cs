/*
You are given two integer arrays nums1 and nums2 sorted in non-decreasing order and an integer k.

Define a pair (u, v) which consists of one element from the first array and one element from the second array.

Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.

 

Example 1:

Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
Output: [[1,2],[1,4],[1,6]]
Explanation: The first 3 pairs are returned from the sequence: [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
Example 2:

Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
Output: [[1,1],[1,1]]
Explanation: The first 2 pairs are returned from the sequence: [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
 

Constraints:

1 <= nums1.length, nums2.length <= 105
-109 <= nums1[i], nums2[i] <= 109
nums1 and nums2 both are sorted in non-decreasing order.
1 <= k <= 104
k <= nums1.length * nums2.length
*/
public class Solution {
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        List<IList<int>> result = new();
        var visited = new HashSet<(int i, int j)>();
        var minHeap = new PriorityQueue<(int i, int j), int>();
        minHeap.Enqueue((0, 0), nums1[0] + nums2[0]);
        
        while (k-- > 0 && minHeap.Count > 0)
        {
            (var i, var j) = minHeap.Dequeue();
    
            result.Add(new List<int>() { nums1[i], nums2[j] });
            if (i + 1 < nums1.Length && !visited.Contains((i + 1, j)))
            {
                minHeap.Enqueue((i + 1, j), nums1[i + 1] + nums2[j]);
                visited.Add((i + 1, j));
            }

            if (j + 1 < nums2.Length && !visited.Contains((i, j + 1)))
            {
                minHeap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
                visited.Add((i, j + 1));
            }
        }

        return result;
    }
}
