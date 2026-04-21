/*Suppose LeetCode will start its IPO soon. In order to sell a good price of its shares to Venture Capital, LeetCode would like to work on some projects to increase its capital before the IPO. Since it has limited resources, it can only finish at most k distinct projects before the IPO. Help LeetCode design the best way to maximize its total capital after finishing at most k distinct projects.

You are given n projects where the ith project has a pure profit profits[i] and a minimum capital of capital[i] is needed to start it.

Initially, you have w capital. When you finish a project, you will obtain its pure profit and the profit will be added to your total capital.

Pick a list of at most k distinct projects from given projects to maximize your final capital, and return the final maximized capital.

The answer is guaranteed to fit in a 32-bit signed integer.

 

Example 1:

Input: k = 2, w = 0, profits = [1,2,3], capital = [0,1,1]
Output: 4
Explanation: Since your initial capital is 0, you can only start the project indexed 0.
After finishing it you will obtain profit 1 and your capital becomes 1.
With capital 1, you can either start the project indexed 1 or the project indexed 2.
Since you can choose at most 2 projects, you need to finish the project indexed 2 to get the maximum capital.
Therefore, output the final maximized capital, which is 0 + 1 + 3 = 4.
Example 2:

Input: k = 3, w = 0, profits = [1,2,3], capital = [0,1,2]
Output: 6
 

Constraints:

1 <= k <= 105
0 <= w <= 109
n == profits.length
n == capital.length
1 <= n <= 105
0 <= profits[i] <= 104
0 <= capital[i] <= 109*/
import "slices"
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

func (heap *Heap) Count() int {    
    return len((*heap).elements) - 1
}

type Pair struct{
    profit int;
    capital int;
}

func findMaximizedCapital(k int, w int, profits []int, capital []int) int {
    pairs := make([]Pair, len(profits))
    for i := 0; i < len(profits); i++ {
        pairs[i] = Pair{
            profit: profits[i],
            capital: capital[i],
        }
    }

    fmt.Println(pairs)

    slices.SortFunc(pairs, func(a, b Pair) int { 
        return a.capital - b.capital
    });
    maxHeap := Constructor();
    idx, n := 0, len(profits);
    for i := 0; i < k; i++ {
        for idx < n && pairs[idx].capital <= w {
            maxHeap.Offer(pairs[idx].profit)
            idx++;
        }

        if (maxHeap.Count() == 0) {
            break;
        }
        w += maxHeap.Poll();
    }
    return w;
}
