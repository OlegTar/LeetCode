/*Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

The left subtree of a node contains only nodes with keys strictly less than the node's key.
The right subtree of a node contains only nodes with keys strictly greater than the node's key.
Both the left and right subtrees must also be binary search trees.
 

Example 1:


Input: root = [2,1,3]
Output: true
Example 2:


Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
-231 <= Node.val <= 231 - 1*/
/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
import "math"
func isValidBST(root *TreeNode) bool {
    return valid(root, math.MinInt64, math.MaxInt64)
}

func valid(node *TreeNode, left, right int) bool {
    if !(node.Val > left && node.Val < right) {
        return false;
    }

    result := true;
    if (node.Left != nil) {
        result = valid(node.Left, left, node.Val)
    }

    if (!result) {
        return false;
    }

    if (node.Right != nil) {
        result = valid(node.Right, node.Val, right)
    }

    return result;
}
