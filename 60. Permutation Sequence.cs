/*The set [1, 2, 3, ..., n] contains a total of n! unique permutations.

By listing and labeling all of the permutations in order, we get the following sequence for n = 3:

"123"
"132"
"213"
"231"
"312"
"321"
Given n and k, return the kth permutation sequence.

 

Example 1:

Input: n = 3, k = 3
Output: "213"
Example 2:

Input: n = 4, k = 9
Output: "2314"
Example 3:

Input: n = 3, k = 1
Output: "123"
 

Constraints:

1 <= n <= 9
1 <= k <= n!*/

public class Solution {
    public string GetPermutation(int n, int k) {
        var result = new StringBuilder();
        var nums = new List<int>(n);
        var fact = 1;
        for (var i = 1; i <= n; i++)
        {
            nums.Add(i);
            fact *= i;
        }

        while (nums.Count > 0)
        {
            var bucketSize = fact / nums.Count;
            var index = (k - 1) / bucketSize;
            result.Append(nums[index]);
            fact /= nums.Count;
            nums.RemoveAt(index);
            k -= index * bucketSize;
        }

        return result.ToString();
    }
}
