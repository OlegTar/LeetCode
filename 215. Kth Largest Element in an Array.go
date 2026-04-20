/*
Given an integer array nums and an integer k, return the kth largest element in the array.

Note that it is the kth largest element in the sorted order, not the kth distinct element.

Can you solve it without sorting?

 

Example 1:

Input: nums = [3,2,1,5,6,4], k = 2
Output: 5
Example 2:

Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4
 

Constraints:

1 <= k <= nums.length <= 105
-104 <= nums[i] <= 104
*/
type Heap struct {
    elements []int;
}

func Constructor() Heap {
    return Heap{
        elements: make([]int, 1),
    }
}

func (heap *Heap) BubbleUp() {
    index := len((*heap).elements) - 1
    for index > 1 && (*heap).elements[index] > (*heap).elements[index / 2] {
        (*heap).elements[index], (*heap).elements[index / 2] = (*heap).elements[index / 2], (*heap).elements[index]
        index = index / 2
    }
}

func (heap *Heap) SinkDown() {
    index := 1
    size := len((*heap).elements)
    for index < size {        
        left := index * 2
        right := index * 2 + 1
        largest := index;

        if (left < size && (*heap).elements[left] > (*heap).elements[largest]) {
            largest = left
        }
        if (right < size && (*heap).elements[right] > (*heap).elements[largest]) {
            largest = right
        }

        if (largest == index) {
            break;
        }        
        (*heap).elements[index], (*heap).elements[largest] = (*heap).elements[largest], (*heap).elements[index]
        index = largest;
    }
}

func (heap *Heap) Offer(element int) {
    (*heap).elements = append((*heap).elements, element)    
    heap.BubbleUp()
}

func (heap *Heap) Poll() int {    
    result := (*heap).elements[1]
    (*heap).elements[1] = (*heap).elements[len((*heap).elements) - 1]
    (*heap).elements = (*heap).elements[:(len((*heap).elements) - 1)]
    heap.SinkDown()
    return result
}


func findKthLargest(nums []int, k int) int {
    heap := Constructor();
    for _, num := range(nums) {
        heap.Offer(num)
    }

    for i := 1; i < k; i++ {
        heap.Poll()
    }
    return heap.Poll();
}
