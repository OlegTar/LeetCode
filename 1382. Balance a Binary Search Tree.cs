/*Given the root of a binary search tree, return a balanced binary search tree with the same node values. If there is more than one answer, return any of them.

A binary search tree is balanced if the depth of the two subtrees of every node never differs by more than 1.

 

Example 1:


Input: root = [1,null,2,null,3,null,4,null,null]
Output: [2,1,3,null,null,null,4]
Explanation: This is not the only correct answer, [3,1,4,null,2] is also correct.
Example 2:


Input: root = [2,1,3]
Output: [2,1,3]
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
1 <= Node.val <= 105*/
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
    public TreeNode BalanceBST(TreeNode root) {
        List<TreeNode> list = GetList(root);
        TreeNode newRoot = CreateBalanced(list);
        return newRoot;                
    }

    public List<TreeNode> GetList(TreeNode node)
    {
        if (node == null) return [];
        return [..GetList(node.left), node, ..GetList(node.right)];
    }

    public TreeNode CreateBalanced(List<TreeNode> list)
    {
        if (list.Count == 0) return null;
        if (list.Count == 1) 
        {
            var node = list[0];
            node.left = null;
            node.right = null;
            return node;            
        }

        int midIndex = list.Count / 2;
        var midNode = list[midIndex];
        midNode.left = CreateBalanced(list[0..midIndex]);
        midNode.right = CreateBalanced(list[(midIndex + 1)..]);
        return midNode;
    }
}
