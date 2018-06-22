// https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/description/

public class RandomizedCollection {
    
    // Key = numerical value that was stored.
    // Value = List of CollectionItems with this value (that maintain their indices
    //         into the collection internally, to maintain O(1) for removal).
    Dictionary<int, List<CollectionItem>> lookup;
    
    // Stores all active values contained within the collection.
    List<CollectionItem> collection;
    
    Random rand;

    /** Initialize your data structure here. */
    public RandomizedCollection() {
        lookup = new Dictionary<int, List<CollectionItem>>();
        collection = new List<CollectionItem>();
        
        rand = new Random();
    }
    
    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val) {        
        int idx = collection.Count;
        CollectionItem item = new CollectionItem(val, idx);
        
        collection.Add(item);
        
        // Now that we've added it to the collection, add to our lookup.
        bool alreadyPresent = false;
        
        if (!lookup.ContainsKey(val)) {
            lookup.Add(val, new List<CollectionItem>());
            alreadyPresent = true;
        }
        
        lookup[val].Add(item);
        
        return alreadyPresent;
    }
    
    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val) {
        
        if (!lookup.ContainsKey(val)) {
            return false;
        }
        
        // Get the last CollectionItem in the lookup list for this value.
        CollectionItem item = lookup[val][lookup[val].Count - 1];
        
        // Now replace this item with the one in the last position in the collection
        // so that we can safely remove the last element in O(1).
        CollectionItem lastItem = collection[collection.Count - 1];
        lastItem.index = item.index;
        collection[item.index] = lastItem;
        collection.RemoveAt(collection.Count - 1);
        
        // Now simply remove the last index in our dictionary lookup
        lookup[val].RemoveAt(lookup[val].Count - 1);
        
        // And remove the key if we have no more elements there
        if (lookup[val].Count == 0) {
            lookup.Remove(val);
        }        
        
        return true;
    }
    
    /** Get a random element from the collection. */
    public int GetRandom() {
        int idx = rand.Next(0, collection.Count - 1);
        
        return collection[idx].val;
    }
}

public class CollectionItem {
    public int val;
    
    public int index;
    
    public CollectionItem(int val, int index) {
        this.val = val;
        this.index = index;
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */