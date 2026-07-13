/*We run a preorder depth-first search (DFS) on the root of a binary tree.

At each node in this traversal, we output D dashes (where D is the depth of this node), then we output the value of this node.  If the depth of a node is D, the depth of its immediate child is D + 1.  The depth of the root node is 0.

If a node has only one child, that child is guaranteed to be the left child.

Given the output traversal of this traversal, recover the tree and return its root.

 

Example 1:


Input: traversal = "1-2--3--4-5--6--7"
Output: [1,2,5,3,4,6,7]
Example 2:


Input: traversal = "1-2--3---4-5--6---7"
Output: [1,2,5,3,null,6,null,4,null,7]
Example 3:


Input: traversal = "1-401--349---90--88"
Output: [1,401,null,349,88,90]
 

Constraints:

The number of nodes in the original tree is in the range [1, 1000].
1 <= Node.val <= 109*/
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
    public TreeNode RecoverFromPreorder(string traversal) {
        (var root, var depth, var position) = ReadNext(traversal, 0);
        
        var stack = new Stack<(TreeNode node, int depth)>();
        stack.Push((root, depth));
        
        while (position < traversal.Length)
        {
            (var node, depth, position) = ReadNext(traversal, position);
            while (stack.Peek().depth != (depth - 1))
            {
                stack.Pop();
            }
            (var parent, var pdepth) = stack.Pop();
            if (parent.left == null)
            {
                parent.left = node;
                stack.Push((parent, pdepth));
            }
            else 
            {
                parent.right = node;
            }
            stack.Push((node, depth));
        }
          
        return root;
    }
    
    public (TreeNode node, int depth, int position) ReadNext(string traversal, int start)
    {
        (int depth, int i) = (0, start);
      
        for (; i < traversal.Length; i++)
        {
            if (traversal[i] == '-')
            {
                depth++;
            }
            else
            {
                break;
            }
        }
        
        
        string str;
        var pos = traversal.IndexOf('-', i);
        if (pos < 0)
        {
            str = traversal.Substring(i);
        }
        else 
        {
            str = traversal.Substring(i, pos - i);
        }
        
        int val = int.Parse(str);
        
        return (new TreeNode(val), depth, pos == -1 ? traversal.Length : pos);
    }
}
