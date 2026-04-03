/*Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

 

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: [[3],[9,20],[15,7]]
Example 2:

Input: root = [1]
Output: [[1]]
Example 3:

Input: root = []
Output: []
 

Constraints:

The number of nodes in the tree is in the range [0, 2000].
-1000 <= Node.val <= 1000*/
/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
func levelOrder(root *TreeNode) [][]int {
    result := [][]int{}
    stack := []*TreeNode{}
    if (root != nil) {
        stack = append(stack, root)
    }

    for len(stack) > 0 {
        level := []int{}
        n := len(stack)
        for i := 0; i < n; i++ {
            node := stack[i];
            level = append(level, node.Val)
            
            if (node.Left != nil) {
                stack = append(stack, node.Left)
            }

            if (node.Right != nil) {
                stack = append(stack, node.Right)
            }
        }
        stack = stack[n:]
        result = append(result, level)
    }

    return result;
}
