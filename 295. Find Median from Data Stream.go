/*The median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value, and the median is the mean of the two middle values.

For example, for arr = [2,3,4], the median is 3.
For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
Implement the MedianFinder class:

MedianFinder() initializes the MedianFinder object.
void addNum(int num) adds the integer num from the data stream to the data structure.
double findMedian() returns the median of all elements so far. Answers within 10-5 of the actual answer will be accepted.
 

Example 1:

Input
["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
[[], [1], [2], [], [3], []]
Output
[null, null, null, 1.5, null, 2.0]

Explanation
MedianFinder medianFinder = new MedianFinder();
medianFinder.addNum(1);    // arr = [1]
medianFinder.addNum(2);    // arr = [1, 2]
medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
medianFinder.addNum(3);    // arr[1, 2, 3]
medianFinder.findMedian(); // return 2.0
 

Constraints:

-105 <= num <= 105
There will be at least one element in the data structure before calling findMedian.
At most 5 * 104 calls will be made to addNum and findMedian.
 

Follow up:

If all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?
If 99% of all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?*/
type Heap struct {
    elements []int;
    comparer func(a, b int) bool;
}

func ConstructorHeap(comparer func(int, int) bool) Heap {
    return Heap{
        elements: make([]int, 1),
        comparer: comparer,
    }
}

func (heap *Heap) BubbleUp() {
    index := len((*heap).elements) - 1
    for index > 1 && (*heap).comparer((*heap).elements[index], (*heap).elements[index / 2]) {
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

        if (left < size && (*heap).comparer((*heap).elements[left], (*heap).elements[largest])) {
            largest = left
        }
        if (right < size && (*heap).comparer((*heap).elements[right], (*heap).elements[largest])) {
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

func (heap *Heap) Peek() int {    
    return (*heap).elements[1]
}

func (heap *Heap) Count() int {    
    return len((*heap).elements) - 1
}

type MedianFinder struct {
    minHeap Heap;
    maxHeap Heap;
}


func Constructor() MedianFinder {
    cmp1 := func (a, b int) bool { return a > b }
    cmp2 := func (a, b int) bool { return a < b }

    return MedianFinder{
        maxHeap: ConstructorHeap(cmp1),
        minHeap: ConstructorHeap(cmp2),
    }
}


func (this *MedianFinder) AddNum(num int)  {
    maxHeap := &(*this).maxHeap
    minHeap := &(*this).minHeap;
    if maxHeap.Count() == 0 && minHeap.Count() == 0 {
        maxHeap.Offer(num)
    } else if maxHeap.Count() == 1 && minHeap.Count() == 0 {
        if num < maxHeap.Peek() {
            max := maxHeap.Poll()
            minHeap.Offer(max)

            maxHeap.Offer(num)
        } else {
            minHeap.Offer(num)
        }
    } else if maxHeap.Count() == minHeap.Count() {
        min := minHeap.Peek()
        if (num <= min) {
            maxHeap.Offer(num)
        } else {
            minHeap.Poll();
            maxHeap.Offer(min)
            minHeap.Offer(num)
        }
    } else {
        max := maxHeap.Peek()
        if (num >= max) {
            minHeap.Offer(num)
        } else {
            maxHeap.Poll();
            minHeap.Offer(max)
            maxHeap.Offer(num)
        }
    }
}


func (this *MedianFinder) FindMedian() float64 {
    result := float64(0)
    if (*this).maxHeap.Count() == (*this).minHeap.Count() {
        result = float64((*this).maxHeap.Peek() + (*this).minHeap.Peek()) / 2;
    } else {
        result = float64((*this).maxHeap.Peek());
    }
    return result;
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * obj := Constructor();
 * obj.AddNum(num);
 * param_2 := obj.FindMedian();
 */
