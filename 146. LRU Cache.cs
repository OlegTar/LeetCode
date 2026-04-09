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
public class LRUCache {
    public class Node {
        public int Key {get; set;}
        public Node Prev {get;set;}
        public Node Next {get;set;}

        public Node() {}

        public Node(int key)
        {
            Key = key;
        }
    }
    private int amount = 0;
    private int capacity = 0;
    private Dictionary<int, Node> lastUsedKeysMap = new();
    private Node Head = new Node();
    private Node Tail = new Node();
    private Dictionary<int, int> cache = new();

    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.Head.Next = this.Tail;
        this.Tail.Prev = this.Head;
    }
    
    public int Get(int key) {        
        if (!cache.TryGetValue(key, out var value))
        {
            return -1;
        }
        MoveToTail(key);
        return value;
    }
    
    public void Put(int key, int value) {        
        if (!cache.ContainsKey(key)) {
            AddKey(key);
            amount++;
            if (amount > capacity)
            {
                amount = capacity;
                var leastUsedKey = Head.Next.Key;
                RemoveKey(leastUsedKey);
                cache.Remove(leastUsedKey);
            }            
        }
        MoveToTail(key);
        cache[key] = value;
    }

    private void MoveToTail(int key) {
        var nodeToMove = lastUsedKeysMap[key];
        if (Tail.Prev == nodeToMove) 
        {
            return;
        }
        var prev = nodeToMove.Prev;
        var next = nodeToMove.Next;
        prev.Next = next;
        next.Prev = prev;

        var last = Tail.Prev;
        last.Next = nodeToMove;
        nodeToMove.Prev = last;
        nodeToMove.Next = Tail;
        Tail.Prev = nodeToMove;
    }

    private void AddKey(int key)
    {
        Node newNode = new Node(key);
        
        var last = Tail.Prev;
        last.Next = newNode;
        newNode.Prev = last;
        newNode.Next = Tail;
        Tail.Prev = newNode;

        lastUsedKeysMap[key] = newNode;
    }

    private void RemoveKey(int key)
    {
        var nodeToDelete = lastUsedKeysMap[key];
        var prev = nodeToDelete.Prev;
        var next = nodeToDelete.Next;
        prev.Next = next;
        next.Prev = prev;
        lastUsedKeysMap.Remove(key);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
