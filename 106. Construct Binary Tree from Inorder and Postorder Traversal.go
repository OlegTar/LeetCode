/*Given two integer arrays inorder and postorder where inorder is the inorder traversal of a binary tree and postorder is the postorder traversal of the same tree, construct and return the binary tree.

 

Example 1:


Input: inorder = [9,3,15,20,7], postorder = [9,15,7,20,3]
Output: [3,9,20,null,null,15,7]
Example 2:

Input: inorder = [-1], postorder = [-1]
Output: [-1]
 

Constraints:

1 <= inorder.length <= 3000
postorder.length == inorder.length
-3000 <= inorder[i], postorder[i] <= 3000
inorder and postorder consist of unique values.
Each value of postorder also appears in inorder.
inorder is guaranteed to be the inorder traversal of the tree.
postorder is guaranteed to be the postorder traversal of the tree.*/
/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
import "slices"
func buildTree(inorder []int, postorder []int) *TreeNode {
    return build(inorder, &postorder);
}

func build(inorder []int, postorder *[]int) *TreeNode {
    if (len(inorder) == 0) {
        return nil;
    }

    val := (*postorder)[len(*postorder) - 1];
    head := &TreeNode{
        Val: val,
    }
    (*postorder) = (*postorder)[:(len(*postorder) - 1)]
    index := slices.Index(inorder, val);
    head.Right = build(inorder[(index + 1):], postorder)
    if (index >= 0) {
        head.Left = build(inorder[:index], postorder)
    }

    return head;
}
