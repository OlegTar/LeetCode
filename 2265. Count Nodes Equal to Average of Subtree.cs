/*Given the root of a binary tree, return the number of nodes where the value of the node is equal to the average of the values in its subtree.

Note:

The average of n elements is the sum of the n elements divided by n and rounded down to the nearest integer.
A subtree of root is a tree consisting of root and all of its descendants.
 

Example 1:


Input: root = [4,8,5,0,1,null,6]
Output: 5
Explanation: 
For the node with value 4: The average of its subtree is (4 + 8 + 5 + 0 + 1 + 6) / 6 = 24 / 6 = 4.
For the node with value 5: The average of its subtree is (5 + 6) / 2 = 11 / 2 = 5.
For the node with value 0: The average of its subtree is 0 / 1 = 0.
For the node with value 1: The average of its subtree is 1 / 1 = 1.
For the node with value 6: The average of its subtree is 6 / 1 = 6.
Example 2:


Input: root = [1]
Output: 1
Explanation: For the node with value 1: The average of its subtree is 1 / 1 = 1.
 

Constraints:

The number of nodes in the tree is in the range [1, 1000].
0 <= Node.val <= 1000*/
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
    private Dictionary<TreeNode, (int, int)> cache = new();

    public int AverageOfSubtree(TreeNode root) 
    {
        var result = 0;
        Solve(root, ref result);
        return result;
    }

    public (int, int) Solve(TreeNode node, ref int result)
    {
        // if (cache.ContainsKey(node)) 
        // {
        //     return cache[node];
        // }

        var val = node.val;        
        var count = 1;

        if (node.left != null) 
        {
            var (leftVal, leftCount) = Solve(node.left, ref result);
            val += leftVal;
            count += leftCount;
        }

        if (node.right != null) 
        {
            var (rightVal, rightCount) = Solve(node.right, ref result);
            val += rightVal;
            count += rightCount;
        }

        if (node.val == val / count) 
        {
            result++;
        }

        //cache.Add(node, (val, count));

        return (val, count);
    }
}
