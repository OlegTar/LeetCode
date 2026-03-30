/*Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).

 

Example 1:


Input: root = [1,2,2,3,4,4,3]
Output: true
Example 2:


Input: root = [1,2,2,null,3,null,3]
Output: false
 

Constraints:

The number of nodes in the tree is in the range [1, 1000].
-100 <= Node.val <= 100
 

Follow up: Could you solve it both recursively and iteratively*/
/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
func isSymmetric(root *TreeNode) bool {
    if (root == nil) {
        return true;
    }

    return treeEquals(root.Left, root.Right);
}

func treeEquals(root1 *TreeNode, root2 *TreeNode) bool {
    if (root1 == nil && root2 == nil) {
        return true;
    }

    if (root1 == nil && root2 != nil) {
        return false;
    }

    if (root2 == nil && root1 != nil) {
        return false;
    }

    if (root1.Val != root2.Val) {
        return false;
    }

    return treeEquals(root1.Left, root2.Right) &&
    treeEquals(root1.Right, root2.Left);
}
