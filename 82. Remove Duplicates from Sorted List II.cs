/*A permutation perm of n + 1 integers of all the integers in the range [0, n] can be represented as a string s of length n where:

s[i] == 'I' if perm[i] < perm[i + 1], and
s[i] == 'D' if perm[i] > perm[i + 1].
Given a string s, reconstruct the permutation perm and return it. If there are multiple valid permutations perm, return any of them.

 

Example 1:

Input: s = "IDID"
Output: [0,4,1,3,2]
Example 2:

Input: s = "III"
Output: [0,1,2,3]
Example 3:

Input: s = "DDI"
Output: [3,2,0,1]
 

Constraints:

1 <= s.length <= 105
s[i] is either 'I' or 'D'.*/
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
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) 
    {
        if (head == null) return null;
        
        ListNode dummy = new ListNode();
        dummy.next = head;
        ListNode tail = dummy;
        int? prev = head.val;
        
        ListNode current = head;
        while (current != null) 
        {
            if (current.next?.val == prev)
            {
                current = current.next;
                while (current?.val == prev)
                {
                    current = current.next;
                }

                tail.next = current;
                prev = current?.val;
            }
            else 
            {
                tail = current;
                prev = current.next?.val;
                current = current.next;
            }            
        }

        return dummy.next;
    }
}
