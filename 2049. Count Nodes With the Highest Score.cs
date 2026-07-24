/*There is a binary tree rooted at 0 consisting of n nodes. The nodes are labeled from 0 to n - 1. You are given a 0-indexed integer array parents representing the tree, where parents[i] is the parent of node i. Since node 0 is the root, parents[0] == -1.

Each node has a score. To find the score of a node, consider if the node and the edges connected to it were removed. The tree would become one or more non-empty subtrees. The size of a subtree is the number of the nodes in it. The score of the node is the product of the sizes of all those subtrees.

Return the number of nodes that have the highest score.

 

Example 1:

example-1
Input: parents = [-1,2,0,2,0]
Output: 3
Explanation:
- The score of node 0 is: 3 * 1 = 3
- The score of node 1 is: 4 = 4
- The score of node 2 is: 1 * 1 * 2 = 2
- The score of node 3 is: 4 = 4
- The score of node 4 is: 4 = 4
The highest score is 4, and three nodes (node 1, node 3, and node 4) have the highest score.
Example 2:

example-2
Input: parents = [-1,2,0]
Output: 2
Explanation:
- The score of node 0 is: 2 = 2
- The score of node 1 is: 2 = 2
- The score of node 2 is: 1 * 1 = 1
The highest score is 2, and two nodes (node 0 and node 1) have the highest score.
 

Constraints:

n == parents.length
2 <= n <= 105
parents[0] == -1
0 <= parents[i] <= n - 1 for i != 0
parents represents a valid binary tree.*/
public class Solution {
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set;}
        public int Count { get; set; }
    }
    public int CountHighestScoreNodes(int[] parents) {
        var treeNodes = parents.Select(_ => new TreeNode()).ToArray();
        var graph = new Dictionary<TreeNode, int>();
        for (var i = 1; i < parents.Length; i++)
        {
            var node = treeNodes[i];
            var parentNode = treeNodes[parents[i]];

            graph.TryAdd(node, 0);
            graph[node]++;
            graph.TryAdd(parentNode, 0);
            graph[parentNode]++;

            if (parentNode.Left == null)
            {
                parentNode.Left = node;
            }
            else
            {
                parentNode.Right = node;
            }
        }

        FillCounts(treeNodes[0]);

        long maxProduct = 0;
        var result = 0;
        var n = parents.Length;
        for (var i = 0; i < parents.Length; i++)
        {
            var node = treeNodes[i];
            long product = 1;
            if (graph[node] == 1)
            {
                product = n - 1;
            }
            else if (graph[node] == 2)
            {
                if (parents[i] == -1)//root
                {
                    product = (long)node.Left.Count * (long)node.Right.Count;
                }
                else
                {
                    product = (long)node.Left.Count * (long)(n - node.Count);
                }
            }
            else
            {
                product = (long)node.Left.Count * (long)node.Right.Count * (long)(n - node.Count);
            }

            //Console.WriteLine($"node = {i}, product = {product}");

            if (product > maxProduct)
            {
                result = 1;
                maxProduct = product;
            }
            else if (product == maxProduct)
            {
                result++;
            }
        }

        return result;
    }

    public int FillCounts(TreeNode node)
    {
        if (node == null) 
        {
            return 0;
        }

        node.Count = 1 + FillCounts(node.Left) + FillCounts(node.Right);
        return node.Count;
    }
}
