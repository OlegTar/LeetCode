/*Given the head of a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list. Return the linked list sorted as well.

 

Example 1:


Input: head = [1,2,3,3,4,4,5]
Output: [1,2,5]
Example 2:


Input: head = [1,1,1,2,3]
Output: [2,3]
 

Constraints:

The number of nodes in the list is in the range [0, 300].
-100 <= Node.val <= 100
The list is guaranteed to be sorted in ascending order.
 */
/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
func deleteDuplicates(head *ListNode) *ListNode {
    dummy := ListNode{
        Val: -200,
        Next: head,
    }

    lastUniq := &dummy
    prev := &dummy
    node := head
    for node != nil {
        if (node.Val == prev.Val) {
            for node != nil && node.Val == prev.Val {
                node = node.Next
            }
            lastUniq.Next = node
        } else {
            lastUniq = prev
        }

        prev = node
        if (node != nil) {
            node = node.Next
        }
    }

    return dummy.Next
}
