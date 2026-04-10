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
    if (head == nil) {
        return nil;
    }
    n := 1;
    node := head;
    for node.Next != nil {
        n++;
        node = node.Next;
    }

    dummy := &ListNode{
        Next: head,
    }

    return sort(dummy, nil, head, 0, n);
}

func sort(prev, end, head *ListNode, left, right int) *ListNode {
    if (right - left <= 1) {
        return head;
    }

    if (right - left == 2) {
        if (head.Val > head.Next.Val) {
            nextNode := head.Next;
            prev.Next = nextNode;
            head.Next = nextNode.Next;
            nextNode.Next = head;
        }
        return prev.Next;
    }

    mid := left + (right - left) / 2
    rightHalf := head;
    for i := left; i < mid; i++ {
        rightHalf = rightHalf.Next
    }

    head = sort(prev, rightHalf, head, left, mid)    
    
    prevRightHalf := head;
    rightHalf = head;
    for i := left; i < mid; i++ {
        prevRightHalf = rightHalf
        rightHalf = rightHalf.Next
    }

    rightHalf = sort(prevRightHalf, end, rightHalf, mid, right)
    pointer1 := head;    
    pointer2 := rightHalf
    i := left;
    j := mid
    last := prev;
    for i < mid && j < right {
        if (pointer1.Val <= pointer2.Val) {
            last.Next = pointer1;
            pointer1 = pointer1.Next;
            i++
        } else {            
            last.Next = pointer2;
            pointer2 = pointer2.Next;
            j++
        }
        last = last.Next;
    }
    
    if (j == right) {
        for i < mid {
            last.Next = pointer1;
            pointer1 = pointer1.Next;
            last = last.Next
            i++
        }
    } else if (i == mid) {
        for j < right {
            last.Next = pointer2;
            pointer2 = pointer2.Next
            last = last.Next
            j++
        }
    }
    last.Next = end

    return prev.Next;
}
