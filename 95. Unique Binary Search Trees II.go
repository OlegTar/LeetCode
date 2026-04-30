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
    numbers := []int{}
    for i := 1; i <= n; i++ {
        numbers = append(numbers, i)
    }

    return generateTree(numbers);
}

func generateTree(numbers []int) []*TreeNode {
    result := []*TreeNode{}
    for i := 0; i < len(numbers); i++ {
        node := TreeNode{
            Val: numbers[i],
        }

        prefix := numbers[0:i]
        suffix := numbers[i + 1:]

        leftSubTrees := generateTree(prefix)
        rightSubTrees := generateTree(suffix)
        if (len(leftSubTrees) == 0 && len(rightSubTrees) == 0) {
            result = append(result, copyTree(&node))
        } else if (len(leftSubTrees) == 0) {
            for _, rightChild := range(rightSubTrees) {
                node.Right = rightChild
                result = append(result, copyTree(&node))
            }
        } else if (len(rightSubTrees) == 0) {
            for _, leftChild := range(leftSubTrees) {
                node.Left = leftChild
                result = append(result, copyTree(&node))
            }
        } else {
            for _, leftChild := range(leftSubTrees) {
                node.Left = leftChild

                for _, rightChild := range(rightSubTrees) {
                    node.Right = rightChild

                    result = append(result, copyTree(&node))
                }
            }
        }
    }
    return result
}

func copyTree(orig *TreeNode) *TreeNode {
    if (orig == nil) {
        return nil
    }
    return &TreeNode{
        Val: orig.Val,
        Left: copyTree(orig.Left),
        Right: copyTree(orig.Right),
    }
}
