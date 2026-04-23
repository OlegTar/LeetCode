/*
You are given two integer arrays nums1 and nums2 sorted in non-decreasing order and an integer k.

Define a pair (u, v) which consists of one element from the first array and one element from the second array.

Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.

 

Example 1:

Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
Output: [[1,2],[1,4],[1,6]]
Explanation: The first 3 pairs are returned from the sequence: [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
Example 2:

Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
Output: [[1,1],[1,1]]
Explanation: The first 2 pairs are returned from the sequence: [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
 

Constraints:

1 <= nums1.length, nums2.length <= 105
-109 <= nums1[i], nums2[i] <= 109
nums1 and nums2 both are sorted in non-decreasing order.
1 <= k <= 104
k <= nums1.length * nums2.length
*/
type Heap struct {
    elements []int;
    pairs []Pair;
}

func Constructor() Heap {
    return Heap{
        elements: make([]int, 1),
        pairs: make([]Pair, 1),
    }
}

func (heap *Heap) BubbleUp() {
    index := len((*heap).elements) - 1
    for index > 1 && (*heap).elements[index] < (*heap).elements[index / 2] {
        (*heap).elements[index], (*heap).elements[index / 2] = (*heap).elements[index / 2], (*heap).elements[index]
        (*heap).pairs[index], (*heap).pairs[index / 2] = (*heap).pairs[index / 2], (*heap).pairs[index]
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

        if (left < size && (*heap).elements[left] < (*heap).elements[largest]) {
            largest = left
        }
        if (right < size && (*heap).elements[right] < (*heap).elements[largest]) {
            largest = right
        }

        if (largest == index) {
            break;
        }        
        (*heap).elements[index], (*heap).elements[largest] = (*heap).elements[largest], (*heap).elements[index]
        (*heap).pairs[index], (*heap).pairs[largest] = (*heap).pairs[largest], (*heap).pairs[index]
        index = largest;
    }
}

func (heap *Heap) Offer(element int, pair Pair) {
    (*heap).elements = append((*heap).elements, element)
    (*heap).pairs = append((*heap).pairs, pair)    
    heap.BubbleUp()
}

func (heap *Heap) Poll() Pair {    
    result := (*heap).pairs[1]
    (*heap).elements[1] = (*heap).elements[len((*heap).elements) - 1]
    (*heap).pairs[1] = (*heap).pairs[len((*heap).pairs) - 1]
    
    (*heap).elements = (*heap).elements[:(len((*heap).elements) - 1)]
    (*heap).pairs = (*heap).pairs[:(len((*heap).pairs) - 1)]

    heap.SinkDown()
    return result
}

func (heap *Heap) Count() int {    
    return len((*heap).elements) - 1
}

type Pair struct{
    i int;
    j int;
}


func kSmallestPairs(nums1 []int, nums2 []int, k int) [][]int {
    visited := map[Pair]struct{}{}
    result := [][]int{}
    minHeap := Constructor();
    minHeap.Offer(nums1[0] + nums2[0], Pair{
        i: 0,
        j: 0,
    })

    for (k > 0 && minHeap.Count() > 0) {
        pair := minHeap.Poll();
        i, j := pair.i, pair.j
        
        result = append(result, []int{ nums1[i], nums2[j] })
        
        pair = Pair{ i: i + 1, j: j}
        _, ok := visited[pair]
        if i + 1 < len(nums1) && !ok {
            
            minHeap.Offer(nums1[i + 1] + nums2[j], pair)
            visited[pair] = struct{}{}
        }

        pair = Pair{ i: i, j: j + 1}
        _, ok = visited[pair]
        if (j + 1 < len(nums2) && !ok) {
            minHeap.Offer(nums1[i] + nums2[j + 1], pair)
            visited[pair] = struct{}{}
        }

        k--
    }
    
    return result
}
