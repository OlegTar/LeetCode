/*Given the root of a binary search tree and the lowest and highest boundaries as low and high, trim the tree so that all its elements lies in [low, high]. Trimming the tree should not change the relative structure of the elements that will remain in the tree (i.e., any node's descendant should remain a descendant). It can be proven that there is a unique answer.

Return the root of the trimmed binary search tree. Note that the root may change depending on the given bounds.

 

Example 1:


Input: root = [1,0,2], low = 1, high = 2
Output: [1,null,2]
Example 2:


Input: root = [3,0,4,null,2,null,null,1], low = 1, high = 3
Output: [3,2,null,1]
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
0 <= Node.val <= 104
The value of each node in the tree is unique.
root is guaranteed to be a valid binary search tree.
0 <= low <= high <= 104*/
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
    public TreeNode TrimBST(TreeNode root, int low, int high) {
        var node = root;
        while (node != null && node.val != low)
        {
            if (node.val < low) {
                if (node == root)
                {
                    root = node.right;
                }
                node = node.right;
            }
            else if (node.left?.val < low) 
            {
                node.left = node.left.right;
            }
            else 
            {
                node = node.left;
            }
        }
        
        
        node?.left = null;
        
       
        node = root;
        while (node != null && node.val != high)
        {
            if (node.val > high)
            {
                if (node == root)
                {
                    root = node.left;
                }
                node = node.left;
            }
            else if (node.right?.val > high) 
            {
                node.right = node.right.left;
            }
            else 
            {
                node = node.right;
            }
        }
        
        node?.right = null;

        return root;
    }
}
