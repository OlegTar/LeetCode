/*You are given the root of a binary tree with n nodes. Each node is uniquely assigned a value from 1 to n. You are also given an integer startValue representing the value of the start node s, and a different integer destValue representing the value of the destination node t.

Find the shortest path starting from node s and ending at node t. Generate step-by-step directions of such path as a string consisting of only the uppercase letters 'L', 'R', and 'U'. Each letter indicates a specific direction:

'L' means to go from a node to its left child node.
'R' means to go from a node to its right child node.
'U' means to go from a node to its parent node.
Return the step-by-step directions of the shortest path from node s to node t.

 

Example 1:


Input: root = [5,1,2,3,null,6,4], startValue = 3, destValue = 6
Output: "UURL"
Explanation: The shortest path is: 3 → 1 → 5 → 2 → 6.
Example 2:


Input: root = [2,1], startValue = 2, destValue = 1
Output: "L"
Explanation: The shortest path is: 2 → 1.
 

Constraints:

The number of nodes in the tree is n.
2 <= n <= 105
1 <= Node.val <= n
All the values in the tree are unique.
1 <= startValue, destValue <= n
startValue != destValue*/
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
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        var pathToStartNode = new List<char>();
        var pathToDestNode = new List<char>();
        Find(root, pathToStartNode, startValue);
        Find(root, pathToDestNode, destValue);
        
        var i = 0 ;
        for (; i < pathToStartNode.Count && i < pathToDestNode.Count; i++)
        {
            if (pathToStartNode[i] != pathToDestNode[i])
            {
                break;
            }
        }
        var pathBeforeLCA = pathToStartNode.Count - i;
        return new string('U', pathBeforeLCA) + new string(pathToDestNode[i..].ToArray());
    }

    public bool Find(TreeNode node, List<char> path, int value)
    {
        if (node == null)
        {
            return false;
        }

        if (node.val == value)
        {
            return true;
        }

        path.Add('L');
        if (Find(node.left, path, value))
        {
            return true;
        }
        
        path[^1] = 'R';

        if (Find(node.right, path, value))
        {
            return true;
        }

        path.RemoveAt(path.Count - 1);
        return false;
    }
}
