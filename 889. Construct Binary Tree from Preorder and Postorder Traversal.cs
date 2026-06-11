/*Given two integer arrays, preorder and postorder where preorder is the preorder traversal of a binary tree of distinct values and postorder is the postorder traversal of the same tree, reconstruct and return the binary tree.

If there exist multiple answers, you can return any of them.

 

Example 1:


Input: preorder = [1,2,4,5,3,6,7], postorder = [4,5,2,6,7,3,1]
Output: [1,2,3,4,5,6,7]
Example 2:

Input: preorder = [1], postorder = [1]
Output: [1]
 

Constraints:

1 <= preorder.length <= 30
1 <= preorder[i] <= preorder.length
All the values of preorder are unique.
postorder.length == preorder.length
1 <= postorder[i] <= postorder.length
All the values of postorder are unique.
It is guaranteed that preorder and postorder are the preorder traversal and postorder traversal of the same binary tree.*/
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
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {        
        var root = new TreeNode(preorder[0]);
        Stack<TreeNode> stack = new Stack<TreeNode>([root]);
        var j = 0;
        for (var i = 1; i < preorder.Length; i++)
        {
            var newNode = new TreeNode(preorder[i]);
            
            while (stack.Peek().left != null && stack.Peek().right != null)
            {
                stack.Pop();
            }
            
            var lastNode = stack.Peek();
            
            if (lastNode.left == null)
            {
                lastNode.left = newNode;
            }
            else
            {
                lastNode.right = newNode;
            }
            
            if (preorder[i] != postorder[j])
            {
                stack.Push(newNode);
            }
            else
            {
                while (stack.Count > 0 && stack.Peek().val == postorder[++j]) 
                {
                    stack.Pop();
                }
            }
        }
        return root;
    }
}
