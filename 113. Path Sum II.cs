/*
Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values in the path equals targetSum. Each path should be returned as a list of the node values, not node references.

A root-to-leaf path is a path starting from the root and ending at any leaf node. A leaf is a node with no children.

 

Example 1:


Input: root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
Output: [[5,4,11,2],[5,8,4,5]]
Explanation: There are two paths whose sum equals targetSum:
5 + 4 + 11 + 2 = 22
5 + 8 + 4 + 5 = 22
Example 2:


Input: root = [1,2,3], targetSum = 5
Output: []
Example 3:

Input: root = [1,2], targetSum = 0
Output: []
 

Constraints:

The number of nodes in the tree is in the range [0, 5000].
-1000 <= Node.val <= 1000
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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        List<IList<int>> result = new List<IList<int>>();
        Solve(root, targetSum, new List<int>(), result);
        return result;
    }

    public void Solve(TreeNode node, int targetSum, List<int> path, List<IList<int>> result)
    {
        if (node == null)
        {
            return;
        }

        if (node.left == null && node.right == null)
        {
            path.Add(node.val);
            if (targetSum - node.val == 0)
            {
                var copyPath = new List<int>(path.Count);
                foreach (var val in path)
                {
                    copyPath.Add(val);
                }
                result.Add(copyPath);
            }
            path.RemoveAt(path.Count - 1);
            return;
        }

        path.Add(node.val);
        Solve(node.left, targetSum - node.val, path, result);
        Solve(node.right, targetSum - node.val, path, result);
        path.RemoveAt(path.Count - 1);
    }
}
