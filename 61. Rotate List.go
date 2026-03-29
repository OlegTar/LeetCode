/*Given the head of a linked list, rotate the list to the right by k places.

 

Example 1:


Input: head = [1,2,3,4,5], k = 2
Output: [4,5,1,2,3]
Example 2:


Input: head = [0,1,2], k = 4
Output: [2,0,1]
 

Constraints:

The number of nodes in the list is in the range [0, 500].
-100 <= Node.val <= 100
0 <= k <= 2 * 109*/
/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
func rotateRight(head *ListNode, k int) *ListNode {
    if (head == nil) {
        return head
    }
    
    tail := head
    count := 1
    for tail.Next != nil {
        tail = tail.Next
        count++
    }

    k = k % count
    if (k == 0) {
        return head
    }
    tail.Next = head

    k = count - k
    var prev *ListNode = tail
    node := head
    for i := 0; i < k; i++ {
        prev = node
        node = node.Next
    }

    prev.Next = nil
    return node;
}
