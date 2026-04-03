/*Given the root of a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.

 

Example 1:

Input: root = [1,2,3,null,5,null,4]

Output: [1,3,4]

Explanation:



Example 2:

Input: root = [1,2,3,4,null,null,null,5]

Output: [1,3,4,5]

Explanation:



Example 3:

Input: root = [1,null,3]

Output: [1,3]

Example 4:

Input: root = []

Output: []

 

Constraints:

The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100*/
/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
func rightSideView(root *TreeNode) []int {
    result := []int{}
    stack := []*TreeNode{}
    if (root != nil) {
        stack = append(stack, root)
    }
    
    for len(stack) > 0 {
        val := stack[len(stack) - 1].Val;
        result = append(result, val);
        n := len(stack);
        for i := 0; i < n; i++ {
            node := stack[i]
            if (node.Left != nil) {
                stack = append(stack, node.Left)
            }
            if (node.Right != nil) {
                stack = append(stack, node.Right)
            }
        }
        stack = stack[n:]
    }

    return result;
}
