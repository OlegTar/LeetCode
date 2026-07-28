/*
You are given the root of a binary tree with n nodes. Each node is assigned a unique value from 1 to n. You are also given an array queries of size m.

You have to perform m independent queries on the tree where in the ith query you do the following:

Remove the subtree rooted at the node with the value queries[i] from the tree. It is guaranteed that queries[i] will not be equal to the value of the root.
Return an array answer of size m where answer[i] is the height of the tree after performing the ith query.

Note:

The queries are independent, so the tree returns to its initial state after each query.
The height of a tree is the number of edges in the longest simple path from the root to some node in the tree.
 

Example 1:


Input: root = [1,3,4,2,null,6,5,null,null,null,null,null,7], queries = [4]
Output: [2]
Explanation: The diagram above shows the tree after removing the subtree rooted at node with value 4.
The height of the tree is 2 (The path 1 -> 3 -> 2).
Example 2:


Input: root = [5,8,9,2,1,3,7,4,6], queries = [3,2,4,8]
Output: [3,2,3,2]
Explanation: We have the following queries:
- Removing the subtree rooted at node with value 3. The height of the tree becomes 3 (The path 5 -> 8 -> 2 -> 4).
- Removing the subtree rooted at node with value 2. The height of the tree becomes 2 (The path 5 -> 8 -> 1).
- Removing the subtree rooted at node with value 4. The height of the tree becomes 3 (The path 5 -> 8 -> 2 -> 6).
- Removing the subtree rooted at node with value 8. The height of the tree becomes 2 (The path 5 -> 9 -> 3).
 

Constraints:

The number of nodes in the tree is n.
2 <= n <= 105
1 <= Node.val <= n
All the values in the tree are unique.
m == queries.length
1 <= m <= min(n, 104)
1 <= queries[i] <= n
queries[i] != root.val
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
    public class TreeNodeExt : TreeNode
    {
        public TreeNodeExt parent;
        public int height;
        public new TreeNodeExt left;
        public new TreeNodeExt right;
        public TreeNodeExt(TreeNode node)
        {
            this.val = node.val;
        }
    }

    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        var dict = new Dictionary<int, TreeNodeExt>();
        var origHeights = new Dictionary<TreeNodeExt, int>();
        var rootExt = MakeTreeExt(root, null, dict);
        foreach (var node in dict.Values)
        {
            origHeights[node] = node.height;
        }
        var answer = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var node = dict[query];
            node.height = 0;
            do
            {
                var parent = node.parent;
                var origHeight = parent.height;
                parent.height = 1 + Math.Max((parent.right?.height ?? 0), (parent.left?.height ?? 0));
                if (parent.height == origHeight)
                {
                    node.height = origHeights[node];
                    break;
                }
                node.height = origHeights[node];
                node = parent;
            } while (node != rootExt);

            answer[i] = rootExt.height - 1;
            rootExt.height = origHeights[rootExt];
        }

        return answer;
    }

    public TreeNodeExt MakeTreeExt(TreeNode node, TreeNodeExt parent, Dictionary<int, TreeNodeExt> dict)
    {
        if (node == null)
        {
            return null;
        }

        var nodeExt = new TreeNodeExt(node);
        dict[nodeExt.val] = nodeExt;

        nodeExt.parent = parent;
        nodeExt.left = MakeTreeExt(node.left, nodeExt, dict);
        nodeExt.right = MakeTreeExt(node.right, nodeExt, dict);
        nodeExt.height = 1 + Math.Max(
            nodeExt.left == null ? 0 : nodeExt.left.height,
            nodeExt.right == null ? 0 : nodeExt.right.height);
        return nodeExt;
    }
}
