/*Given the root of a Binary Search Tree (BST), return the minimum absolute difference between the values of any two different nodes in the tree.

 

Example 1:


Input: root = [4,2,6,1,3]
Output: 1
Example 2:


Input: root = [1,0,48,null,null,12,49]
Output: 1
 

Constraints:

The number of nodes in the tree is in the range [2, 104].
0 <= Node.val <= 105
 

Note: This question is the same as 783: https://leetcode.com/problems/minimum-distance-between-bst-nodes/*/
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
    public int GetMinimumDifference(TreeNode root) {
        var values = new List<int>();
        Traverse(root, values);
        var result = values[1] - values[0];
        var n = values.Count - 1;
        for (var i = 0; i < n; i++) {
            result = Math.Min(result, values[i + 1] - values[i]);
        }
        return result;
    }

    public void Traverse(TreeNode node, List<int> nodes) {
        if (node == null) 
        {
            return;
        }
        Traverse(node.left, nodes);
        nodes.Add(node.val);
        Traverse(node.right, nodes);
    }
}
