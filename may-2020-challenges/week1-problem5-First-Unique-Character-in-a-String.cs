// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3320/

public class Solution {
    public int FirstUniqChar(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return -1;
        }
        
        // We'll use a dictionary that stores the first index of each letter observed.
        // And then a HashSet that stores letters that have been seen more than once.
        // We can remove elements from the Dictionary as we add them to the HashSet,
        // and never add to the Dictionary if it's already in the HashSet.
        // At the end, scan the Dictionary to find the lowest value.
        Dictionary<char, int> firstLetterIdx = new Dictionary<char, int>();
        HashSet<char> lettersSeenOften = new HashSet<char>();
        
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            
            // We've never seen this letter
            if (!lettersSeenOften.Contains(c) && !firstLetterIdx.ContainsKey(c)) {
                firstLetterIdx.Add(c, i);
            } else if (firstLetterIdx.ContainsKey(c)) {
                // We've now seen a second instance of this letter...
                firstLetterIdx.Remove(c);
                lettersSeenOften.Add(c);
            } 
        }
        
        int minVal = int.MaxValue;
        foreach (int val in firstLetterIdx.Values) {
            minVal = Math.Min(minVal, val);
        }
        
        return minVal == int.MaxValue ? -1 : minVal;
    }
}