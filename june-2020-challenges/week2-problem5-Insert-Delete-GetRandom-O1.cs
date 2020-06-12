// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3358/

public class RandomizedSet {
    
    private List<int> fullSet;
    
    private Dictionary<int, int> lookup;
    
    private Random rand;

    /** Initialize your data structure here. */
    public RandomizedSet() {
        fullSet = new List<int>();
        lookup = new Dictionary<int, int>();
        rand = new Random();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if (lookup.ContainsKey(val)) {
            return false;
        }
        
        fullSet.Add(val);
        lookup.Add(val, fullSet.Count - 1);
        
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if (!lookup.ContainsKey(val)) {
            return false;
        }
        
        // Removing from the end of a list is O(1), so make sure the item
        // we want to remove is at the back...
        int idx = lookup[val];
        
        if (idx != fullSet.Count - 1) {
            // Swap the element to remove with the end of the list.
            int temp = fullSet[fullSet.Count - 1];
            fullSet[fullSet.Count - 1] = fullSet[idx];
            fullSet[idx] = temp;
            
            // Don't forget to update the index in our lookup.
            lookup[temp] = idx;
        }        
        
        fullSet.RemoveAt(fullSet.Count - 1);
        lookup.Remove(val);        
        
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        return fullSet[rand.Next(fullSet.Count)];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */