/*Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Example 2:

Input: nums = [0,1]
Output: [[0,1],[1,0]]
Example 3:

Input: nums = [1]
Output: [[1]]
 

Constraints:

1 <= nums.length <= 6
-10 <= nums[i] <= 10
All the integers of nums are unique.*/

public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Solve(nums, new List<int>(), result);
        return result;
    }

    public void Solve(int[] nums, List<int> combination, IList<IList<int>> result)
    {      
        if (combination.Count == nums.Length)
        {
            result.Add(new List<int>(combination));
        }

        foreach (var n in nums)
        {
            if (combination.Contains(n))
            {
                continue;
            }
            combination.Add(n);
            Solve(nums, combination, result);
            combination.RemoveAt(combination.Count - 1);
        }
    }
}
