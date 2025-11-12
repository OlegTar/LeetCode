/*
Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.

Example 1:

Input: nums = [1,1,2]
Output:
[[1,1,2],
 [1,2,1],
 [2,1,1]]
Example 2:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
 

Constraints:

1 <= nums.length <= 8
-10 <= nums[i] <= 10
*/
public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        Array.Sort(nums);
        var result = new List<IList<int>>();
        Solve(nums, new HashSet<int>(), new List<int>(), result);
        return result;
    }

    public void Solve(int[] nums, HashSet<int> indices, List<int> permutation, IList<IList<int>> result)
    {
        if (permutation.Count == nums.Length)
        {
            result.Add(new List<int>(permutation));
            return;
        }

        var last = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (indices.Contains(i) || nums[i] == last)
            {
                continue;
            }

            last = nums[i];
            permutation.Add(nums[i]);
            indices.Add(i);
            Solve(nums, indices, permutation, result);
            permutation.RemoveAt(permutation.Count - 1);
            indices.Remove(i);
        }
    }
}
