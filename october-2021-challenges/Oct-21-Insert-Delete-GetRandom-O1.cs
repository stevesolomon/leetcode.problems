// https://leetcode.com/problems/insert-delete-getrandom-o1/

public class RandomizedSet {
    
    Dictionary<int, int> valueLookup;
    List<int> values;    
    Random random;

    public RandomizedSet() {
        valueLookup = new Dictionary<int, int>();
        values = new List<int>();
        random = new Random();
    }
    
    public bool Insert(int val) {
        if (valueLookup.ContainsKey(val)) {
            return false;
        }
        
        values.Add(val);        
        valueLookup.Add(val, values.Count - 1);
        
        return true;
    }
    
    public bool Remove(int val) {
        if (!valueLookup.ContainsKey(val)) {
            return false;
        }
        
        // Removing from the end of a list is O(1). So find the index of the value
        // to be removed, and swap it with the value at the end of the list.
        // Make sure to update the swapped value's index in the lookup!
        if (valueLookup[val] != values.Count - 1) {
            int temp = values[values.Count - 1];
            values[values.Count - 1] = values[valueLookup[val]];
            values[valueLookup[val]] = temp;
            
            valueLookup[temp] = valueLookup[val];
        }
        
        values.RemoveAt(values.Count - 1);
        valueLookup.Remove(val);
        
        return true;
    }
    
    public int GetRandom() {
        int idx = random.Next(0, valueLookup.Count);
        
        return values[idx];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */