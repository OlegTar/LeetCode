/*You are given the root of a binary tree with n nodes, where each node is uniquely assigned a value from 1 to n. You are also given a sequence of n values voyage, which is the desired pre-order traversal of the binary tree.

Any node in the binary tree can be flipped by swapping its left and right subtrees. For example, flipping node 1 will have the following effect:


Flip the smallest number of nodes so that the pre-order traversal of the tree matches voyage.

Return a list of the values of all flipped nodes. You may return the answer in any order. If it is impossible to flip the nodes in the tree to make the pre-order traversal match voyage, return the list [-1].

 

Example 1:


Input: root = [1,2], voyage = [2,1]
Output: [-1]
Explanation: It is impossible to flip the nodes such that the pre-order traversal matches voyage.
Example 2:


Input: root = [1,2,3], voyage = [1,3,2]
Output: [1]
Explanation: Flipping node 1 swaps nodes 2 and 3, so the pre-order traversal matches voyage.
Example 3:


Input: root = [1,2,3], voyage = [1,2,3]
Output: []
Explanation: The tree's pre-order traversal already matches voyage, so no nodes need to be flipped.
 

Constraints:

The number of nodes in the tree is n.
n == voyage.length
1 <= n <= 100
1 <= Node.val, voyage[i] <= n
All the values in the tree are unique.
All the values in voyage are unique.*/
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
    public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage) {
        int i = 0;
        var result = new List<int>();
        Solve(root, voyage, ref i, result);

        return result;
    }

    public void Solve(TreeNode node, int[] voyage, ref int i, List<int> result)
    {
        if (i == voyage.Length || node == null || result.Count == 1 && result[0] == -1)
        {
            return;
        }

        if (node.val != voyage[i])
        {
            result.Clear();
            result.Add(-1);
            return;
        }

        i++;

        if (i == voyage.Length)
        {
            return;
        }

        if (node.left == null)
        {
            Solve(node.right, voyage, ref i, result);
        }
        else if (node.left.val == voyage[i])
        {
            Solve(node.left, voyage, ref i, result);
            Solve(node.right, voyage, ref i, result);
        }
        else if (node.left != null || node.right != null)
        {            
            result.Add(node.val);
            Solve(node.right, voyage, ref i, result);
            Solve(node.left, voyage, ref i, result);
        }
    }
}
