// https://leetcode.com/problems/hand-of-straights/
// This solution uses a dictionary. Unfortunately we still need an O(n) traversal of the keys at times.

public class Solution {
    public bool IsNStraightHand(int[] hand, int W) {
        if (hand == null || W == 0 || hand.Length % W != 0) {
            return false;
        }

        Dictionary<int, int> numCounts = new Dictionary<int, int>();
        int lowestNum = int.MaxValue;
        
        foreach (int num in hand) {
            if (!numCounts.ContainsKey(num)) {
                numCounts.Add(num, 0);
            }
            
            numCounts[num]++;
            
            lowestNum = Math.Min(num, lowestNum);
        }
        
        for (int currHand = 0; currHand < hand.Length / W; currHand++) {
            
            // For a new hand we start by picking the lowest number we have available.
            int currNum = lowestNum;
            numCounts[lowestNum]--;
            
            // When we pick a number we may have to update our lowestNum pointer.
            // We have to do this if the dictionary entry for the lowestNum no longer
            // has any entries once we pick it. So we'll set a flag that tells us
            // we need to update this.
            bool resetLowestNum = false;
            if (numCounts[lowestNum] == 0) {
                numCounts.Remove(lowestNum);
                resetLowestNum = true;
            }
            
            // Now we need to pick the remaining W - 1 numbers.
            for (int i = 1; i < W; i++) {
                
                // See if we can actually get the number that we need.
                if (!numCounts.ContainsKey(currNum + 1) || numCounts[currNum + 1] == 0) {
                    return false;
                }
                
                // We could, so now what we want to do is update currNum...
                currNum++;
                numCounts[currNum]--;
                
                // And if we are in a state where we need to reset the lowest num we can use, try to do so.
                if (resetLowestNum && numCounts[currNum] > 0) {
                    lowestNum = currNum;
                    resetLowestNum = false;
                } 
                
                if (numCounts[currNum] == 0) {
                    numCounts.Remove(currNum);
                    
                    if (!resetLowestNum) {
                        resetLowestNum = true;
                    }
                }
            }
            
            // If we couldn't successfully reset lowestNum we unfortunately have to do an O(n) scan of the Dictionary.
            if (resetLowestNum) {
                lowestNum = GetLowestAvailableNum(numCounts);
            }
            
        }        
        
        return true;
    }
    
    private int GetLowestAvailableNum(Dictionary<int, int> numCounts) {
        int lowest = int.MaxValue;
        
        foreach (int key in numCounts.Keys) {
            if (numCounts[key] > 0) {
                lowest = Math.Min(key, lowest);
            }
        }
        
        return lowest;
    }
}