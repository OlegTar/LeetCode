/*You are given the root of a binary tree.

A ZigZag path for a binary tree is defined as follow:

Choose any node in the binary tree and a direction (right or left).
If the current direction is right, move to the right child of the current node; otherwise, move to the left child.
Change the direction from right to left or from left to right.
Repeat the second and third steps until you can't move in the tree.
Zigzag length is defined as the number of nodes visited - 1. (A single node has a length of 0).

Return the longest ZigZag path contained in that tree.

 

Example 1:


Input: root = [1,null,1,1,1,null,null,1,1,null,1,null,null,null,1]
Output: 3
Explanation: Longest ZigZag path in blue nodes (right -> left -> right).
Example 2:


Input: root = [1,1,1,null,1,null,null,1,1,null,1]
Output: 4
Explanation: Longest ZigZag path in blue nodes (left -> right -> left -> right).
Example 3:

Input: root = [1]
Output: 0
 

Constraints:

The number of nodes in the tree is in the range [1, 5 * 104].
1 <= Node.val <= 100*/
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
    private int length = 0;    
    public int LongestZigZag(TreeNode root) {        
        Traverse(root.left, true, 1);
        Traverse(root.right, false, 1);
        return length;
    }

    public void Traverse(TreeNode node, bool isLeft, int currentLength)
    {        
        if (node == null)
        {
            length = Math.Max(length, currentLength - 1);
            return;
        }
        
        if (isLeft)
        {
            Traverse(node.right, false, currentLength + 1);
            Traverse(node.left, true, 1);
        }
        else 
        {
            Traverse(node.left, true, currentLength + 1);
            Traverse(node.right, false, 1);
        }
    }
}
