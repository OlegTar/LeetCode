/*
Given the head of a linked list, reverse the nodes of the list k at a time, and return the modified list.

k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.

You may not alter the values in the list's nodes, only nodes themselves may be changed.

 

Example 1:


Input: head = [1,2,3,4,5], k = 2
Output: [2,1,4,3,5]
Example 2:


Input: head = [1,2,3,4,5], k = 3
Output: [3,2,1,4,5]
 

Constraints:

The number of nodes in the list is n.
1 <= k <= n <= 5000
0 <= Node.val <= 1000
 

Follow-up: Can you solve the problem in O(1) extra memory space?
*/
/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
func reverseKGroup(head *ListNode, k int) *ListNode {
    n := 0;
    node := head;
    for node != nil {
        n++;
        node = node.Next;
    }

    groups := n / k;

    dummy := &ListNode{
        Next: head,
    }

    groupStart := dummy;
    node = head;
    for i := 0; i < groups; i++ {
        startOfNextGroup := node;
        prev := node
        node = node.Next;

        for j := 0; j < (k - 1); j++ {
            prev.Next = node.Next;
            node.Next = groupStart.Next;
            groupStart.Next = node;
            node = prev.Next;
        }

        groupStart = startOfNextGroup;
        node = groupStart.Next;
    }

    return dummy.Next;
}
