/*Two players play a turn based game on a binary tree. We are given the root of this binary tree, and the number of nodes n in the tree. n is odd, and each node has a distinct value from 1 to n.

Initially, the first player names a value x with 1 <= x <= n, and the second player names a value y with 1 <= y <= n and y != x. The first player colors the node with value x red, and the second player colors the node with value y blue.

Then, the players take turns starting with the first player. In each turn, that player chooses a node of their color (red if player 1, blue if player 2) and colors an uncolored neighbor of the chosen node (either the left child, right child, or parent of the chosen node.)

If (and only if) a player cannot choose such a node in this way, they must pass their turn. If both players pass their turn, the game ends, and the winner is the player that colored more nodes.

You are the second player. If it is possible to choose such a y to ensure you win the game, return true. If it is not possible, return false.

 

Example 1:


Input: root = [1,2,3,4,5,6,7,8,9,10,11], n = 11, x = 3
Output: true
Explanation: The second player can choose the node with value 2.
Example 2:

Input: root = [1,2,3], n = 3, x = 1
Output: false
 

Constraints:

The number of nodes in the tree is n.
1 <= x <= n <= 100
n is odd.
1 <= Node.val <= n
All the values of the tree are unique.*/
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
    public bool BtreeGameWinningMove(TreeNode root, int n, int x) {
        Dictionary<int, (TreeNode node, List<TreeNode> neighbors)> graph = new();
        FillGraph(root, null, graph);
        var counts = GetCountsOfSubtrees(x, graph);
        var sum = counts.Sum() + 1;
        return counts.Any(cnt => cnt > (sum - cnt));
    }

    public void FillGraph(TreeNode node, TreeNode parent, Dictionary<int, (TreeNode node, List<TreeNode> neighbors)> graph)
    {
        if (node == null)
        {
            return;
        }
        graph[node.val] = (node, []);

        if (parent != null)
        {
            graph[node.val].neighbors.Add(parent);
        }

        if (node.left != null)
        {
            graph[node.val].neighbors.Add(node.left);
        }

        if (node.right != null)
        {
            graph[node.val].neighbors.Add(node.right);
        }

        FillGraph(node.left, node, graph);
        FillGraph(node.right, node, graph);
    }

    public List<int> GetCountsOfSubtrees(int x, Dictionary<int, (TreeNode node, List<TreeNode> neighbors)> graph)
    {
        var neighbors = graph[x].neighbors;
        var visitedNode = graph[x].node;
        return neighbors.Select(node => GetCountOfSubtree(node, visitedNode, graph)).ToList();
    }

    public int GetCountOfSubtree(TreeNode node, TreeNode visitedNode, Dictionary<int, (TreeNode node, List<TreeNode> neighbors)> graph)
    {
        var count = 0;
        var visited = new HashSet<TreeNode>([visitedNode]);
        var stack = new Stack<TreeNode>();
        stack.Push(node);
        while (stack.Count > 0)
        {
            node = stack.Pop();
            count++;
            visited.Add(node);
            foreach (var neighbor in graph[node.val].neighbors)
            {
                if (visited.Contains(neighbor))
                {
                    continue;
                }
                stack.Push(neighbor);
            }
        }

        return count;
    }
}
