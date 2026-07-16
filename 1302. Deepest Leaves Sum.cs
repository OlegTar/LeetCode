/*
Given the root of a binary tree, return the sum of values of its deepest leaves.
 

Example 1:


Input: root = [1,2,3,4,5,null,6,7,null,null,null,null,8]
Output: 15
Example 2:

Input: root = [6,7,8,2,7,1,3,9,null,1,4,null,null,null,5]
Output: 19
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
1 <= Node.val <= 100
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
    public int DeepestLeavesSum(TreeNode root) {
        var maxDepth = 0;
        var sum = 0;
        Count(root, 0, ref maxDepth, ref sum);
        return sum;
    }

    public void Count(TreeNode node, int currentDepth, ref int maxDepth, ref int sum)
    {
        if (node == null)
        {
            return;
        }
        
        if (currentDepth == maxDepth)
        {
            sum += node.val;
        }
        else if (currentDepth > maxDepth)
        {
            maxDepth = currentDepth;
            sum = node.val;
        }
        
        Count(node.left, currentDepth + 1, ref maxDepth, ref sum);
        Count(node.right, currentDepth + 1, ref maxDepth, ref sum);
    }
}*/
