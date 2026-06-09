/*Given the root of a binary tree, the depth of each node is the shortest distance to the root.

Return the smallest subtree such that it contains all the deepest nodes in the original tree.

A node is called the deepest if it has the largest depth possible among any node in the entire tree.

The subtree of a node is a tree consisting of that node, plus the set of all descendants of that node.

 

Example 1:


Input: root = [3,5,1,6,2,0,8,null,null,7,4]
Output: [2,7,4]
Explanation: We return the node with value 2, colored in yellow in the diagram.
The nodes coloured in blue are the deepest nodes of the tree.
Notice that nodes 5, 3 and 2 contain the deepest nodes in the tree but node 2 is the smallest subtree among them, so we return it.
Example 2:

Input: root = [1]
Output: [1]
Explanation: The root is the deepest node in the tree.
Example 3:

Input: root = [0,1,3,null,2]
Output: [2]
Explanation: The deepest node in the tree is 2, the valid subtrees are the subtrees of nodes 2, 1 and 0 but the subtree of node 2 is the smallest.
 

Constraints:

The number of nodes in the tree will be in the range [1, 500].
0 <= Node.val <= 500
The values of the nodes in the tree are unique.
 

Note: This question is the same as 1123: https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/*/

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
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        var maxDepth = GetMaxDepth(root);
        List<TreeNode> deepestNodes = new();
        GetNodes(root, 1, maxDepth, deepestNodes);

        var parentsMap = new Dictionary<TreeNode, TreeNode>();
        CreateParentsMap(root, null, parentsMap);

        var n = deepestNodes.Count;
        if (n == 1)
        {
            return deepestNodes.First();
        }
        /*

        Console.WriteLine($"n = {n}");
        */
        var queue = new Queue<TreeNode>();
        var counts = new Dictionary<TreeNode, int>();
        foreach (var node in deepestNodes)
        {
            queue.Enqueue(node);
            counts[node] = 1;
        }

        
        var set = new HashSet<TreeNode>();
      
        while (queue.Count > 0)
        {
            set.Clear();
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var parent = parentsMap[node];

                if (!counts.ContainsKey(parent))
                {
                    counts[parent] = 0;
                }
                //Console.WriteLine($"node.val = {node.val}");
                //Console.WriteLine($"parent.val = {parent.val}");
                
                counts[parent] += counts[node];
                //Console.WriteLine($"counts[parent] = {counts[parent]}");
                if (counts[parent] == n) 
                {
                    return parent;
                }
                set.Add(parent);
            }
            
            foreach (var node in set)
            {
                queue.Enqueue(node);
            }
        }
        return null;
    }

    public int GetMaxDepth(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        return 1 + Math.Max(
            GetMaxDepth(node.left),
            GetMaxDepth(node.right)
            );
    }

    public void GetNodes(TreeNode node, int currentDepth, int maxDepth, List<TreeNode> nodes)
    {
        if (node == null)
        {
            return;
        }
        
        if (currentDepth == maxDepth)
        {
            nodes.Add(node);
            return;
        }

        GetNodes(node.left, currentDepth + 1, maxDepth, nodes);
        GetNodes(node.right, currentDepth + 1, maxDepth, nodes);
    }

    public void CreateParentsMap(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> parentsMap)
    {
        if (node == null)
        {
            return;
        }
        
        parentsMap[node] = parent;
        CreateParentsMap(node.left, node,
            parentsMap);
        CreateParentsMap(node.right, node,
            parentsMap);
    }
}
