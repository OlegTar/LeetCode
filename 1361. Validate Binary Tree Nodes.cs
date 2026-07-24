/*
You have n binary tree nodes numbered from 0 to n - 1 where node i has two children leftChild[i] and rightChild[i], return true if and only if all the given nodes form exactly one valid binary tree.

If node i has no left child then leftChild[i] will equal -1, similarly for the right child.

Note that the nodes have no values and that we only use the node numbers in this problem.

 

Example 1:


Input: n = 4, leftChild = [1,-1,3,-1], rightChild = [2,-1,-1,-1]
Output: true
Example 2:


Input: n = 4, leftChild = [1,-1,3,-1], rightChild = [2,3,-1,-1]
Output: false
Example 3:


Input: n = 2, leftChild = [1,0], rightChild = [-1,-1]
Output: false
 

Constraints:

n == leftChild.length == rightChild.length
1 <= n <= 104
-1 <= leftChild[i], rightChild[i] <= n - 1
*/
public class Solution {
    public class TreeNode
    {
        public TreeNode Left { get; set;}
        public TreeNode Right { get; set;}
        public int Parents { get; set;}
    }

    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild) {
        var nodes = new TreeNode [n];
        for (var i = 0; i < n; i++)
        {
            nodes[i] = new TreeNode();
        }

        for (var i = 0; i < n; i++)
        {
            var left = leftChild[i];
            if (left != -1)
            {
                nodes[i].Left = nodes[left];
                nodes[left].Parents++;
                if (nodes[left].Parents > 1)
                {
                    return false;
                }
            }

            var right = rightChild[i];
            if (right != -1)
            {
                nodes[i].Right = nodes[right];
                nodes[right].Parents++;
                if (nodes[right].Parents > 1)
                {
                    return false;
                }
            }
        }

        if (nodes.Count(node => node.Parents == 0) != 1)
        {
            return false;
        }

        var root = nodes.Single(node => node.Parents == 0);

        var seen = new HashSet<TreeNode>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (seen.Contains(node))
            {
                return false;
            }
            seen.Add(node);
            if (node.Left != null)
            {
                stack.Push(node.Left);
            }
            if (node.Right != null)
            {
                stack.Push(node.Right);
            }
        }

        return seen.Count == n;
    }
}
