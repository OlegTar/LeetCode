/*
You are given the root of a binary tree with unique values, and an integer start. At minute 0, an infection starts from the node with value start.

Each minute, a node becomes infected if:

The node is currently uninfected.
The node is adjacent to an infected node.
Return the number of minutes needed for the entire tree to be infected.

 

Example 1:


Input: root = [1,5,3,null,4,10,6,9,2], start = 3
Output: 4
Explanation: The following nodes are infected during:
- Minute 0: Node 3
- Minute 1: Nodes 1, 10 and 6
- Minute 2: Node 5
- Minute 3: Node 4
- Minute 4: Nodes 9 and 2
It takes 4 minutes for the whole tree to be infected so we return 4.
Example 2:


Input: root = [1], start = 1
Output: 0
Explanation: At minute 0, the only node in the tree is infected so we return 0.
 

Constraints:

The number of nodes in the tree is in the range [1, 105].
1 <= Node.val <= 105
Each node has a unique value.
A node with a value of start exists in the tree.
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
    public int AmountOfTime(TreeNode root, int start) {
        var graph = new Dictionary<TreeNode, List<TreeNode>>();
        graph.Add(root, []);
        
        Fill(root.left, root, graph);
        Fill(root.right, root, graph);

        TreeNode startNode = Find(root, start);

        var visited = new HashSet<TreeNode>();
        var time = 0;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(startNode);
        while (queue.Count > 0)
        {
            var size = queue.Count;
            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                visited.Add(node);
                
                foreach (var neighbour in graph[node])
                {
                    if (visited.Contains(neighbour))
                {
                       continue;
                    }

                    queue.Enqueue(neighbour);
                }
            }

            time++;
        }

        return time - 1;
    }

    public void Fill(TreeNode node, TreeNode parent, Dictionary<TreeNode, List<TreeNode>> graph)
    {
        if (node == null)
        {
            return;
        }

        graph.TryAdd(parent, []);
        graph[parent].Add(node);
        graph.TryAdd(node, []);
        graph[node].Add(parent);

        Fill(node.left, node, graph);
        Fill(node.right, node, graph);
    }

    public TreeNode Find(TreeNode root, int value)
    {
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node.val == value)
            {
                return node;
            }

            if (node.left != null)
            {
                stack.Push(node.left);
            }
            if (node.right != null)
            {
                stack.Push(node.right);
            }
        }

        return null;
    }
}
