/*Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

Implement the LRUCache class:

LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
int get(int key) Return the value of the key if the key exists, otherwise return -1.
void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
The functions get and put must each run in O(1) average time complexity.

 

Example 1:

Input
["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
Output
[null, null, null, 1, null, -1, null, -1, 3, 4]

Explanation
LRUCache lRUCache = new LRUCache(2);
lRUCache.put(1, 1); // cache is {1=1}
lRUCache.put(2, 2); // cache is {1=1, 2=2}
lRUCache.get(1);    // return 1
lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
lRUCache.get(2);    // returns -1 (not found)
lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
lRUCache.get(1);    // return -1 (not found)
lRUCache.get(3);    // return 3
lRUCache.get(4);    // return 4
 

Constraints:

1 <= capacity <= 3000
0 <= key <= 104
0 <= value <= 105
At most 2 * 105 calls will be made to get and put.*/
type Node struct {
    key int;
    prev *Node;
    next *Node;
}

type LRUCache struct {
    capacity int;
    amount int;
    cache map[int]int;
    nodesMap map[int]*Node;
    head *Node;
    tail *Node;
}


func Constructor(capacity int) LRUCache {
    cache := LRUCache{
        capacity: capacity,
        amount: 0,
        nodesMap: map[int]*Node{},
        cache: map[int]int{},
        head: &Node{},
        tail: &Node{},
    }

    cache.head.next = cache.tail;
    cache.tail.prev = cache.head;
    
    return cache;
}


func (this *LRUCache) Get(key int) int {
    //if val, ok := (*this).cache[key]; ok {
    if val, ok := this.cache[key]; ok {
        this.MoveToTail(key);
        return val;
    }
    return -1;
}


func (this *LRUCache) Put(key int, value int)  {
    if _, ok := this.cache[key]; !ok {
        this.AddKey(key);
        this.amount++;
        if (this.amount > this.capacity) {
            this.amount = this.capacity;
            leastRecentlyUsedKey := this.head.next.key;
            this.RemoveLRU();
            delete(this.cache, leastRecentlyUsedKey);
        }
    }
    this.MoveToTail(key);
    this.cache[key] = value;
}


func (this *LRUCache) AddKey(key int) {
    newNode := &Node {
        key: key,
    }
    last := this.tail.prev;
    last.next = newNode;
    newNode.prev = last;
    newNode.next = this.tail;
    this.tail.prev = newNode;

    this.nodesMap[key] = newNode;
}

func (this *LRUCache) RemoveLRU() {
    node := this.head.next;
    next := node.next;
    this.head.next = next;
    next.prev = this.head;
}

func (this *LRUCache) MoveToTail(key int) {
    node := this.nodesMap[key];
    if (this.tail.prev == node) {
        return;
    }

    prev := node.prev;
    next := node.next;
    prev.next = next;
    next.prev = prev;

    last := this.tail.prev;
    last.next = node;
    node.prev = last;
    node.next = this.tail;
    this.tail.prev = node;
}






/**
 * Your LRUCache object will be instantiated and called as such:
 * obj := Constructor(capacity);
 * param_1 := obj.Get(key);
 * obj.Put(key,value);
 */
