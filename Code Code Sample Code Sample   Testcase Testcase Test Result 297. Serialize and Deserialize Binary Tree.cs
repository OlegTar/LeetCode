/*Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

Clarification: The input/output format is the same as how LeetCode serializes a binary tree. You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.

 

Example 1:


Input: root = [1,2,3,null,null,4,5]
Output: [1,2,3,null,null,4,5]
Example 2:

Input: root = []
Output: []
 

Constraints:

The number of nodes in the tree is in the range [0, 104].
-1000 <= Node.val <= 1000*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        var sb = new StringBuilder();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var n = queue.Count;
            var lastLevel = true;
            for (var i = 0; i < n; i++)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    sb.Append(node.val.ToString());
                    
                    if (node.left != null || node.right != null) 
                    {
                        lastLevel = false;
                    }
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            
                sb.Append(",");
            }            
            if (lastLevel) break;            
        }
        sb.Length--;
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        int?[] arr = data.Split(",").Select(i => i == ""?(int?)null : int.Parse(i)).ToArray();
        if (arr.Length == 0) 
        {
            return null;
        }

        var root = arr[0] == null ? null : new TreeNode(arr[0].Value);        
        var parents = new Queue<TreeNode>();
        parents.Enqueue(root);
        var i = 1;
        while (i < arr.Length)
        {
            var n = parents.Count;
            for (var j = 0; j < n; j++) 
            {
                var parent = parents.Dequeue();
                parent.left = arr[i] == null ? null : new TreeNode(arr[i].Value);
                i++;
                parent.right = arr[i] == null ? null : new TreeNode(arr[i].Value);
                i++;
                
                if (parent.left != null) 
                {
                    parents.Enqueue(parent.left);
                }

                if (parent.right != null) 
                {
                    parents.Enqueue(parent.right);
                }
            }
        }

        return root;
    }
}
