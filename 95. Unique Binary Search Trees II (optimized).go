/*Given an integer n, return all the structurally unique BST's (binary search trees), which has exactly n nodes of unique values from 1 to n. Return the answer in any order.

 

Example 1:


Input: n = 3
Output: [[1,null,2,null,3],[1,null,3,2],[2,1,3],[3,1,null,null,2],[3,2,null,1]]
Example 2:

Input: n = 1
Output: [[1]]
 

Constraints:

1 <= n <= 8*/
/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
func generateTrees(n int) []*TreeNode {
    return generateTree(1, n);
}

func generateTree(left, right int) []*TreeNode {
    if (left > right) {
        return []*TreeNode{ nil }
    }
    result := []*TreeNode{}
    for i := left; i <= right; i++ {    
        leftSubTrees := generateTree(left, i - 1)
        rightSubTrees := generateTree(i + 1, right)
        for _, leftChild := range(leftSubTrees) {
            for _, rightChild := range(rightSubTrees) {
                node := TreeNode{
                    Val: i,
                    Left: leftChild,
                    Right: rightChild,
                }
                result = append(result, &node)
            }
        }
    }
    return result
}
