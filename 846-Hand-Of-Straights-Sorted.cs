// https://leetcode.com/problems/hand-of-straights/
// Solves this problem using an initial sort.

public class Solution {
    public bool IsNStraightHand(int[] hand, int W) {
        if (hand == null || W == 0 || hand.Length % W != 0) {
            return false;
        }

        Array.Sort(hand);

        // Now step through and greedily take consecutive elements
        // that we haven't picked before.
        bool[] picked = new bool[hand.Length];

        for (int currHand = 0; currHand < hand.Length / W; currHand++) {
            int startIdx = 0;

            while (picked[startIdx]) { startIdx++; }

            int currNum = hand[startIdx];
            int currLen = 1;
            picked[startIdx] = true;            

            for (int i = startIdx + 1; i < hand.Length; i++) {
                
                if (currLen == W) {
                    break;
                }
                
                if (!picked[i] && hand[i] == currNum + 1) {
                    // Take this number too.
                    currNum = hand[i];
                    currLen++;
                    picked[i] = true;
                }                
            }

            if (currLen != W) {
                return false;
            }
        }

        return true;
    }
}