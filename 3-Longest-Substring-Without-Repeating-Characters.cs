// https://leetcode.com/problems/longest-substring-without-repeating-characters/

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrEmpty(s)) {
            return 0;
        }
        
        // Use a dictionary to record at what index we last saw a character.
        // When we find a character already in our dictionary, our current longest
        // substring with no repeating characters can be at most currIdx - lastCharIdx long.
        Dictionary<char, int> charIndices = new Dictionary<char, int>();
        
        int longest = int.MinValue;
        int currLength = 0;
        
        for (int i = 0; i < s.Length; i++) {
            char curr = s[i];
            currLength++;
            
            // We've seen this character before *in our current substring*
            if (charIndices.ContainsKey(curr)) {
                
                // Our current substring goes from i-currLength...i
                // If we last saw this char outside of this, it's
                // still a "unique char" for the purposes of this current substring.
                if (charIndices[curr] > i - currLength) {
                    currLength = i - charIndices[curr];
                }
                
                // Update when we last saw this char
                charIndices[curr] = i;                
            } else {
                charIndices.Add(curr, i);                
            }
            
            longest = Math.Max(longest, currLength);
        }
        
        return longest;
    }
}