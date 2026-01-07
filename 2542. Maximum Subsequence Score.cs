/*
You are given two 0-indexed integer arrays nums1 and nums2 of equal length n and a positive integer k. You must choose a subsequence of indices from nums1 of length k.

For chosen indices i0, i1, ..., ik - 1, your score is defined as:

The sum of the selected elements from nums1 multiplied with the minimum of the selected elements from nums2.
It can defined simply as: (nums1[i0] + nums1[i1] +...+ nums1[ik - 1]) * min(nums2[i0] , nums2[i1], ... ,nums2[ik - 1]).
Return the maximum possible score.

A subsequence of indices of an array is a set that can be derived from the set {0, 1, ..., n-1} by deleting some or no elements.
*/
public class Solution {
    public long MaxScore(int[] nums1, int[] nums2, int k) {
        var list = new (int num1, int num2)[nums1.Length];
        for (var i = 0; i < nums1.Length; i++)
        {
            list[i] = (nums1[i], nums2[i]);
        }

        Array.Sort(list, (a, b) => {
            if (a.num2 == b.num2) {
                return a.num1.CompareTo(b.num1);
            } 
            return b.num2.CompareTo(a.num2);
        });

        long sum = 0;
        long min = 0;
        var pq = new PriorityQueue<int, int>();
        long result = int.MinValue;
        foreach (var el in list)
        {
            min = el.num2;
            sum += el.num1;
            pq.Enqueue(el.num1, el.num1);
            if (pq.Count > k)
            {
                sum -= pq.Dequeue();
            }

            if (pq.Count == k)
            {
                result = Math.Max(result, sum * min);
            }
        }

        return result;
    }
}
