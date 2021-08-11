// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/614/week-2-august-8th-august-14th/3877/

public class Solution {
    public bool CanReorderDoubled(int[] arr) {
        if (arr == null || arr.Length == 0) {
            return true;
        }
        
        // Sort the array and then take a greedy approach from
        // the highest number to the lowest.
        // First scan all numbers and place in a dictionary.
        // Then traversing the sorted array in reverse order,
        // check for a matching number half the current one in the dict.
        // and reduce its count (also reduce the count of our current number).
        // If we reach a number in the array where the Dict. value is 0,
        // just skip it and move on, we've already paired all of its instances up.
        
        Dictionary<int, int> counts = new Dictionary<int, int>();
        
        foreach (int val in arr) {
            if (!counts.ContainsKey(val)) {
                counts.Add(val, 0);
            }
            
            counts[val]++;
        }
        
        Array.Sort(arr);
        
        for (int i = arr.Length - 1; i >= 0; i--) {
            if (counts[arr[i]] == 0) {
                continue;
            }
            
            // If we've hit a positive odd number that wasn't already at 0
            // we can't find a pair as half of it is not an integer.
            if (arr[i] > 0 && arr[i] % 2 != 0) {
                return false;
            }
            
            // We're traversing frm greatest to smallest, which means once
            // we hit the negative values we're looking for "larger" negative values.
            // ie: the pair for a -2 is a -4, not a -1.
            int pairedNum = arr[i] < 0 ? arr[i] * 2 : arr[i] / 2;
            
            if (!counts.ContainsKey(pairedNum) || counts[pairedNum] <= 0) {
                return false;
            }
            
            counts[arr[i]]--;
            counts[pairedNum]--;
        }
        
        // Now ensure we've zeroed out the entire dictionary
        foreach (var kvp in counts) {
            if (kvp.Value > 0) {
                return false;
            }
        }
        
        return true;
    }
}