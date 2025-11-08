/*
Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.

Note: The solution set must not contain duplicate combinations.

 

Example 1:

Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]
Example 2:

Input: candidates = [2,5,2,1,2], target = 5
Output: 
[
[1,2,2],
[5]
]
 

Constraints:

1 <= candidates.length <= 100
1 <= candidates[i] <= 50
1 <= target <= 30
*/

public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        IList<IList<int>> result = new List<IList<int>>();
        Solve(candidates, 0, target, new Stack<int>(), result);
        return result;
    }

    public void Solve(int[] candidates, int index, int target, Stack<int> combination, IList<IList<int>> result)
    {
        if (target == 0)
        {
            var combCopy = new List<int>(combination);
            result.Add(combCopy);
        }

        if (index >= candidates.Length)
        {
            return;
        }
        
        var last = 0;
        for (var i = index; i < candidates.Length; i++)
        {
            if (candidates[i] == last)
            {
                continue;
            }

            if (candidates[i] > target)
            {
                break;
            }

            last = candidates[i];
            combination.Push(candidates[i]);
            Solve(candidates, i + 1, target - candidates[i], combination, result);
            combination.Pop();
        }
    }
}
