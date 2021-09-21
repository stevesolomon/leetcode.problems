// https://leetcode.com/problems/lru-cache/

public class LRUCache {
    
    private LinkedList<Tuple<int, int>> cacheQueue;
    
    private Dictionary<int, LinkedListNode<Tuple<int, int>>> lookup;
    
    private int maxSize;

    public LRUCache(int capacity) {
        if (capacity <= 0) {
            throw new ArgumentException("Capacity must be greater than 0");
        }
        
        this.maxSize = capacity;
        
        this.cacheQueue = new LinkedList<Tuple<int, int>>();
        this.lookup = new Dictionary<int, LinkedListNode<Tuple<int, int>>>();
    }
    
    public int Get(int key) {
        if (!lookup.ContainsKey(key)) {
            return -1;
        }
        
        var node = lookup[key];
        
        // Re-insert the given node to the front of the cache queue
        cacheQueue.Remove(node);
        cacheQueue.AddFirst(node);
        
        return node.Value.Item2;
    }
    
    public void Put(int key, int value) {
        
        // Just update the existing value if the key exists.
        if (lookup.ContainsKey(key)) {
            lookup[key].Value = new Tuple<int, int>(key, value);
            
            // Run a 'Get' to push this back to the front
            this.Get(key);
            
            return;
        }
        
        // Otherwise we need to add a new value.
        // Ensure that we're not at our max capacity already.
        if (lookup.Count == maxSize) {
            // Evict the least recently used.
            var removed = cacheQueue.Last;
            cacheQueue.RemoveLast();
            lookup.Remove(removed.Value.Item1);
        }
        
        // Add our new value
        cacheQueue.AddFirst(new Tuple<int, int>(key, value));
        lookup.Add(key, cacheQueue.First);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */