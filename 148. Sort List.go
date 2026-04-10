/*Given the head of a linked list, return the list after sorting it in ascending order.

 

Example 1:


Input: head = [4,2,1,3]
Output: [1,2,3,4]
Example 2:


Input: head = [-1,5,3,4,0]
Output: [-1,0,3,4,5]
Example 3:

Input: head = []
Output: []
 

Constraints:

The number of nodes in the list is in the range [0, 5 * 104].
-105 <= Node.val <= 105
 

Follow up: Can you sort the linked list in O(n logn) time and O(1) memory (i.e. constant space)?*/
/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
func sortList(head *ListNode) *ListNode {
    if (head == nil || head.Next == nil) {
        return head;
    }

    middleNode := findMiddle(head)
    left := sortList(head)
    right := sortList(middleNode)
    return merge(left, right)
}

func findMiddle(head *ListNode) *ListNode {
    slow := head
    fast := head.Next

    for fast != nil && fast.Next != nil {
        slow = slow.Next
        fast = fast.Next.Next
    }

    mid := slow.Next;
    slow.Next = nil;
    return mid;
}

func merge(list1, list2 *ListNode) *ListNode {
    dummy := &ListNode{}
    last := dummy;
    for list1 != nil && list2 != nil {
        if list1.Val <= list2.Val {
            last.Next = list1
            list1 = list1.Next
        } else {
            last.Next = list2
            list2 = list2.Next
        }
        last = last.Next
    }

    if (list1 == nil) {
        last.Next = list2
    } else {
        last.Next = list1
    }

    return dummy.Next;
}
