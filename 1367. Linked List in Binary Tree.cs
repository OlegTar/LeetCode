/*Given a binary tree root and a linked list with head as the first node. 

Return True if all the elements in the linked list starting from the head correspond to some downward path connected in the binary tree otherwise return False.

In this context downward path means a path that starts at some node and goes downwards.

 

Example 1:



Input: head = [4,2,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: true
Explanation: Nodes in blue form a subpath in the binary Tree.  
Example 2:



Input: head = [1,4,2,6], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: true
Example 3:

Input: head = [1,4,2,6,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: false
Explanation: There is no path in the binary tree that contains all the elements of the linked list from head.
 

Constraints:

The number of nodes in the tree will be in the range [1, 2500].
The number of nodes in the list will be in the range [1, 100].
1 <= Node.val <= 100 for each node in the linked list and binary tree.*/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
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
    
    public bool IsSubPath(ListNode head, TreeNode root) {
        Dictionary<(ListNode, TreeNode), bool> cache = new();
        return Solve(head, head, root, cache);
    }
    
    public bool Solve(ListNode node, ListNode head, TreeNode root, Dictionary<(ListNode, TreeNode), bool> cache)
    {       
        if (node == null)
        {
            return true;
        }
        if (cache.TryGetValue((node, root), out var result))
        {
            return result;
        }
        
        
        if (root == null && node != null)
        {
            return false;
        }
        
        var res = false;
        if (root.val == node.val)
        {
            res = Solve(node.next, head, root.left, cache)
            || Solve(node.next, head, root.right, cache);
        }
        
        cache[(node, root)] = res;
        
        if (res) return true;
        
        
        if (root.val == head.val)
        {
            cache[(node, root)] = Solve(head.next, head, root.left, cache)
            || Solve(head.next, head, root.right, cache);
            return cache[(node, root)];
        }
        
        cache[(node, root)] = Solve(head, head, root.left, cache)
            || Solve(head, head, root.right, cache);
        return cache[(node, root)];
           
    }         
}
