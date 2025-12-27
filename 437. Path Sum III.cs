/*
Given the root of a binary tree and an integer targetSum, return the number of paths where the sum of the values along the path equals targetSum.

The path does not need to start or end at the root or a leaf, but it must go downwards (i.e., traveling only from parent nodes to child nodes).

 

Example 1:


Input: root = [10,5,-3,3,2,null,11,3,-2,null,1], targetSum = 8
Output: 3
Explanation: The paths that sum to 8 are shown.
Example 2:

Input: root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
Output: 3
 

Constraints:

The number of nodes in the tree is in the range [0, 1000].
-109 <= Node.val <= 109
-1000 <= targetSum <= 1000
*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    private int count = 0;
    public int PathSum(TreeNode root, int targetSum) {
        Dictionary<long, int> prefixSumCounts = new();
        prefixSumCounts.Add(0, 1);

        Solve(root, 0L, targetSum, prefixSumCounts);
        return count;
    }

    public void Solve(TreeNode node, long preSum, int targetSum, Dictionary<long, int> prefixSumCounts)
    {
        if (node == null)
        {
            return;
        }

        long currentPreSum = preSum + node.val;
        long complement = currentPreSum - targetSum;
        
        if (prefixSumCounts.ContainsKey(complement))
        {
            count += prefixSumCounts[complement];
        }

        if (!prefixSumCounts.ContainsKey(currentPreSum))
        {
            prefixSumCounts[currentPreSum] = 0;
        }
        prefixSumCounts[currentPreSum]++;

        Solve(node.left, currentPreSum, targetSum, prefixSumCounts);
        Solve(node.right, currentPreSum, targetSum, prefixSumCounts);

        prefixSumCounts[currentPreSum]--;
    }
}
