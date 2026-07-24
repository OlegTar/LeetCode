/*Given a binary tree root, return the maximum sum of all keys of any sub-tree which is also a Binary Search Tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
 

Example 1:



Input: root = [1,4,3,2,4,2,5,null,null,null,null,null,null,4,6]
Output: 20
Explanation: Maximum sum in a valid Binary search tree is obtained in root node with key equal to 3.
Example 2:



Input: root = [4,3,null,1,2]
Output: 2
Explanation: Maximum sum in a valid Binary search tree is obtained in a single root node with key equal to 2.
Example 3:

Input: root = [-4,-2,-5]
Output: 0
Explanation: All values are negatives. Return an empty BST.
 

Constraints:

The number of nodes in the tree is in the range [1, 4 * 104].
-4 * 104 <= Node.val <= 4 * 104*/
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
    public struct Bst
    {
        public bool isBst;
        public int sum;
        public int low;
        public int high;
    }
    
    public int MaxSumBST(TreeNode root) {
       int result = 0;
       Solve(root, ref result);
       return result;
    }

    public Bst Solve(TreeNode node, ref int result)
    {
        if (node.left == null && node.right == null)
        {
            Bst b = new();
            b.isBst = true;
            b.sum = node.val;
            b.low = node.val;
            b.high = node.val;
            return b;
        }
        Bst left;
        left.isBst = true;
        left.high = int.MinValue;
        left.low = node.val;
        left.sum = 0;
        if (node.left != null)
        {
            left = Solve(node.left, ref result);
        }
        Bst right;
        right.isBst = true;
        right.low = int.MaxValue;
        right.high = node.val;
        right.sum = 0;
        if (node.right != null)
        {
            right = Solve(node.right, ref result);
        }

        if (left.isBst)
        {
            result = Math.Max(result, left.sum);
        }

        if (right.isBst)
        {
            result = Math.Max(result, right.sum);
        }

        Bst bst = new();
        bst.isBst = false;

        if (left.isBst && right.isBst && node.val > left.high && node.val < right.low)
        {
            bst.isBst = true;
            bst.sum = node.val + left.sum + right.sum;
            result = Math.Max(result,  bst.sum);
            bst.low = left.low;
            bst.high = right.high;
        }

        return bst;
    }
}
