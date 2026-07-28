/*
Given the root of a binary tree, replace the value of each node in the tree with the sum of all its cousins' values.

Two nodes of a binary tree are cousins if they have the same depth with different parents.

Return the root of the modified tree.

Note that the depth of a node is the number of edges in the path from the root node to it.

 

Example 1:


Input: root = [5,4,9,1,10,null,7]
Output: [0,0,0,7,7,null,11]
Explanation: The diagram above shows the initial binary tree and the binary tree after changing the value of each node.
- Node with value 5 does not have any cousins so its sum is 0.
- Node with value 4 does not have any cousins so its sum is 0.
- Node with value 9 does not have any cousins so its sum is 0.
- Node with value 1 has a cousin with value 7 so its sum is 7.
- Node with value 10 has a cousin with value 7 so its sum is 7.
- Node with value 7 has cousins with values 1 and 10 so its sum is 11.
Example 2:


Input: root = [3,1,2]
Output: [0,0,0]
Explanation: The diagram above shows the initial binary tree and the binary tree after changing the value of each node.
- Node with value 3 does not have any cousins so its sum is 0.
- Node with value 1 does not have any cousins so its sum is 0.
- Node with value 2 does not have any cousins so its sum is 0.
 

Constraints:

The number of nodes in the tree is in the range [1, 105].
1 <= Node.val <= 104
*/
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
    public TreeNode ReplaceValueInTree(TreeNode root) {
        var queue = new Queue<(TreeNode node, TreeNode parent)>();
        var dummy = new TreeNode();
        queue.Enqueue((root, dummy));

        while (queue.Count > 0)
        {
            var size = queue.Count;
            var dict = new Dictionary<TreeNode, int>();
            var totalSum = 0;
            var levelNodes = new (TreeNode node, TreeNode parent)[size];
            for (var i = 0; i < size; i++)
            {                
                (var node, var parent) = queue.Dequeue();
                
                totalSum += node.val;
                dict.TryAdd(parent, 0);
                dict[parent] += node.val;
                levelNodes[i] = (node, parent);
                
                if (node.left != null)
                {
                    queue.Enqueue((node.left, node));
                }

                if (node.right != null)
                {
                    queue.Enqueue((node.right, node));
                }                
            }
            
            foreach ((var node, var parent) in levelNodes)
            {
                node.val = totalSum - dict[parent];
            }
        }

        return root;
    }
}
