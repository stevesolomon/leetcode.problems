// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/639/week-4-september-22nd-september-28th/3984/

public class Solution {
    public int MaxLength(IList<string> arr) {
        if (arr == null || arr.Count == 0) {
            return 0;
        } else if (arr.Count == 1) {
            return arr[0].Length;
        }
        
        return MaxLength(arr, 0, new int[26]);
    }
    
    public int MaxLength(IList<string> arr, int index, int[] freqs) {
        
        // Base case: we're out of array elements to consider
        if (index == arr.Count) {
            return 0;
        }
        
        // First try NOT taking this word and just moving on to the next
        int excludeLength = MaxLength(arr, index + 1, freqs);
        
        // Then try taking this word (if we can).
        int includeLength = int.MinValue;
        bool canBeAdded = true;
        
        // First determine the frequencies for the incoming word,
        // compared to the frequencies we've constructed for our solution thus far.
        // We need to keep a full count of frequencies as we'll reset this later
        foreach (char c in arr[index]) {
            if (freqs[c - 'a'] != 0) {
                canBeAdded = false;
            }
            
            freqs[c - 'a']++;
        }
        
        // If we can add the word, try the rest of the combinations with this word
        // added (stored in freqs) and include its length.
        if (canBeAdded) {
            includeLength = MaxLength(arr, index + 1, freqs) + arr[index].Length;
        }
        
        // Reset our changes to freqs
        foreach (char c in arr[index]) {
            freqs[c - 'a']--;
        }
        
        return Math.Max(excludeLength, includeLength);        
    }
}