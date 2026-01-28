/*A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them. A node can only appear in the sequence at most once. Note that the path does not need to pass through the root.

The path sum of a path is the sum of the node's values in the path.

Given the root of a binary tree, return the maximum path sum of any non-empty path.

 

Example 1:


Input: root = [1,2,3]
Output: 6
Explanation: The optimal path is 2 -> 1 -> 3 with a path sum of 2 + 1 + 3 = 6.
Example 2:


Input: root = [-10,9,20,null,null,15,7]
Output: 42
Explanation: The optimal path is 15 -> 20 -> 7 with a path sum of 15 + 20 + 7 = 42.
 

Constraints:

The number of nodes in the tree is in the range [1, 3 * 104].
-1000 <= Node.val <= 1000*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    Map<TreeNode, Integer> memo = new HashMap<>();
    public int maxPathSum(TreeNode root) {
        int max = Integer.MIN_VALUE;
        Stack<TreeNode> stack = new Stack<>();
        stack.push(root);
        
        while (!stack.isEmpty()) {
            TreeNode node = stack.pop();
            max = Math.max(max, calculatePathSum(node, 0));
            
            if (node.left != null) {
                stack.push(node.left);
            }
            
            if (node.right != null) {
                stack.push(node.right);
            }
        }

        return max;
    }

    public int calculatePathSum(TreeNode node, int level)
    {
        if (node == null) {
            return 0;
        }

        if (level != 0 && memo.containsKey(node))
        {
            return memo.get(node);
        }

        int candidate1 = node.val;
        int candidate2 = calculatePathSum(node.left, level + 1) + node.val;
        int candidate3 = node.val + calculatePathSum(node.right, level + 1);
        int candidate4 = level == 0 ? calculatePathSum(node.left, level + 1) + node.val + calculatePathSum(node.right, level + 1) : Integer.MIN_VALUE;

        int result = max(candidate1, candidate2, candidate3, candidate4);
        if (level != 0) {
            memo.put(node, result);
        }

        return result;
    }

    public int max(int... candidates) {
        int max = Integer.MIN_VALUE;
        for (int i = 0; i < candidates.length; i++) {
            max = Math.max(max, candidates[i]);
        }
        return max;
    }
}
