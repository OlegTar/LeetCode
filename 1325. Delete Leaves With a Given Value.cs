/*Given a binary tree root and an integer target, delete all the leaf nodes with value target.

Note that once you delete a leaf node with value target, if its parent node becomes a leaf node and has the value target, it should also be deleted (you need to continue doing that until you cannot).

 

Example 1:



Input: root = [1,2,3,2,null,2,4], target = 2
Output: [1,null,3,null,4]
Explanation: Leaf nodes in green with value (target = 2) are removed (Picture in left). 
After removing, new nodes become leaf nodes with value (target = 2) (Picture in center).
Example 2:



Input: root = [1,3,3,3,2], target = 3
Output: [1,3,null,null,2]
Example 3:



Input: root = [1,2,null,2,null,2], target = 2
Output: [1]
Explanation: Leaf nodes in green with value (target = 2) are removed at each step.
 

Constraints:

The number of nodes in the tree is in the range [1, 3000].
1 <= Node.val, target <= 1000*/
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
    public TreeNode RemoveLeafNodes(TreeNode root, int target) {
        var parents = new Dictionary<TreeNode, (TreeNode parent, bool isLeft)>();
        FillParents(root, null, parents, true);

        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (IsLeaf(node) && node.val == target)
            {
                (var parent, var isLeft) = parents[node];
                if (parent == null)
                {
                    return null;
                }
                else 
                {
                    if (isLeft)
                    {
                        parent.left = null;
                    }
                    else
                    {
                        parent.right = null;
                    }

                    if (IsLeaf(parent)) 
                    {
                        stack.Push(parent);
                    }
                }
            }
            else
            {   
                if (node.left != null) stack.Push(node.left);
                if (node.right != null) stack.Push(node.right);
            }
        }

        return root;
    }

    public void FillParents(TreeNode node, TreeNode parent, Dictionary<TreeNode, (TreeNode parent, bool isLeft)> parents, bool isLeft)
    {
        if (node == null) return;
        parents[node] = (parent, isLeft);
        FillParents(node.left, node, parents, true);
        FillParents(node.right, node, parents, false);
    }

    public bool IsLeaf(TreeNode node)
    {
        return node.left == null && node.right == null;
    }
}
