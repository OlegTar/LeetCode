/*You are given the root of a binary tree where each node has a value in the range [0, 25] representing the letters 'a' to 'z'.

Return the lexicographically smallest string that starts at a leaf of this tree and ends at the root.

As a reminder, any shorter prefix of a string is lexicographically smaller.

For example, "ab" is lexicographically smaller than "aba".
A leaf of a node is a node that has no children.

 

Example 1:


Input: root = [0,1,2,3,4,3,4]
Output: "dba"
Example 2:


Input: root = [25,1,3,1,3,0,2]
Output: "adz"
Example 3:


Input: root = [2,2,1,null,1,0,null,0]
Output: "abc"
 

Constraints:

The number of nodes in the tree is in the range [1, 8500].
0 <= Node.val <= 25*/
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
    public string SmallestFromLeaf(TreeNode root) {
        var letters = new List<char>();
        string result = null;
        int firstLetter = int.MaxValue;
        Find(root, letters, ref result, ref firstLetter);
        return result;
    }

    public void Find(TreeNode node, List<char> list, ref string result, ref int firstLetter)
    {
        if (node == null)
        {
            return;
        }

        if (node.left == null && node.right == null)
        {
            if (node.val > firstLetter)
            {
                return;
            }
            
            firstLetter = node.val;

            list.Add((char)(node.val + 'a'));
            var strB = new StringBuilder();
            for (var i = 1; i <= list.Count; i++)
            {
                strB.Append(list[^i]);
            }
            var str = strB.ToString();
            if (result == null || str.CompareTo(result) < 0)
            {
                result = str;
            }
            list.RemoveAt(list.Count - 1);
            return;
        }
        list.Add((char)(node.val + 'a'));
        Find(node.left, list, ref result, ref firstLetter);
        Find(node.right, list, ref result, ref firstLetter);
        list.RemoveAt(list.Count - 1);
    }
}
