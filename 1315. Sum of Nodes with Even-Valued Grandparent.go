/*Given the root of a binary tree, return the sum of values of nodes with an even-valued grandparent. If there are no nodes with an even-valued grandparent, return 0.

A grandparent of a node is the parent of its parent if it exists.

 

Example 1:


Input: root = [6,7,8,2,7,1,3,9,null,1,4,null,null,null,5]
Output: 18
Explanation: The red nodes are the nodes with even-value grandparent while the blue nodes are the even-value grandparents.
Example 2:


Input: root = [1]
Output: 0
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
1 <= Node.val <= 100*/
/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
func sumEvenGrandparent(root *TreeNode) int {
    if (root == nil) {
        return 0
    }

    var sum int = 0
    if (root.Val % 2 == 0 && root.Left != nil) {
        if (root.Left.Left != nil) {
            sum += root.Left.Left.Val;
        }
        if (root.Left.Right != nil) {
            sum += root.Left.Right.Val;
        }
    }

    if (root.Val % 2 == 0 && root.Right != nil) {
        if (root.Right.Left != nil) {
            sum += root.Right.Left.Val;
        }
        if (root.Right.Right != nil) {
            sum += root.Right.Right.Val;
        }
    }

    return sum + sumEvenGrandparent(root.Left) + sumEvenGrandparent(root.Right);
}
