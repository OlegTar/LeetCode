/*Given the root of a binary tree and an integer limit, delete all insufficient nodes in the tree simultaneously, and return the root of the resulting binary tree.

A node is insufficient if every root to leaf path intersecting this node has a sum strictly less than limit.

A leaf is a node with no children.

 

Example 1:


Input: root = [1,2,3,4,-99,-99,7,8,9,-99,-99,12,13,-99,14], limit = 1
Output: [1,2,3,4,null,null,7,8,9,null,14]
Example 2:


Input: root = [5,4,8,11,null,17,4,7,1,null,null,5,3], limit = 22
Output: [5,4,8,11,null,17,4,7,null,null,null,5]
Example 3:


Input: root = [1,2,-3,-5,null,4,null], limit = -1
Output: [1,null,-3,4]
 

Constraints:

The number of nodes in the tree is in the range [1, 5000].
-105 <= Node.val <= 105
-109 <= limit <= 109*/
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
    public TreeNode SufficientSubset(TreeNode root, int limit) {
        var toRemove = new Dictionary<TreeNode, TreeNode>();
        Traversal(root, null, 0, toRemove, limit);
        if (toRemove.ContainsKey(root))
        {
            return null;
        }
        
        foreach (var node in toRemove.Keys)
        {
            var parent = toRemove[node];
            if (parent.left == node)
            {
                parent.left = null;
            }
            else
            {
                parent.right = null;
            }
        }    
        
        return root;
    }
    
    public bool Traversal(TreeNode node, TreeNode parent, int sum, Dictionary<TreeNode, TreeNode> toRemove, int limit)
    {
        if (node.left == null && node.right == null)
        {
            if ((node.val + sum) < limit) {
                toRemove[node] = parent;
                return true;
            }
            return false;
        }
        
        var leftSubtree = true;
        if (node.left != null)
        {
            leftSubtree = Traversal(node.left, node, sum + node.val, toRemove, limit);
        }
        
        var rightSubtree = true;
        if (node.right != null)
        {
            rightSubtree = Traversal(node.right, node, sum + node.val, toRemove, limit);
        }
        
        if (leftSubtree && rightSubtree)
        {
            toRemove[node] = parent;
            return true;
        }
        return false;
    }
}
