/*46. Permutations
Solved
Medium
Topics
premium lock icon
Companies
Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

 

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
        return Solve(nums);
    }

    public IList<IList<int>> Solve(int[] nums, int level = 0)
    {
        if (nums.Length == 2)
        {
            return [[nums[0], nums[1]], [nums[1], nums[0]]];
        }

        if (nums.Length == 1)
        {
            return [nums];
        }

        IList<IList<int>> combinations = new List<IList<int>>();
        for (var i = 0; i < nums.Length; i++)
        {
            var lastNumber = nums[i];
            var newNums = nums.Where(number => number != lastNumber).ToArray();
            var combinationsOfNextLevel = Solve(newNums, level + 1);
            for (var j = 0; j < combinationsOfNextLevel.Count; j++)
            {
                var combination = new List<int>();
                combination.Add(lastNumber);
                combination.AddRange(combinationsOfNextLevel[j]);
                combinations.Add(combination);
            }            
        }
        return combinations;
    }
}
