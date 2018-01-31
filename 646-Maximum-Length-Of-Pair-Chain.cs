// https://leetcode.com/problems/maximum-length-of-pair-chain/description/

public class Solution {
    public int FindLongestChain(int[,] pairs) {
        
        if (pairs == null || pairs.Length == 0) {
            return 0;
        } else if (pairs.Length == 1) {
            return 1;
        }
        
        // Stuff our pairs into a List for easy sorting.
        List<int[]> pairList = new List<int[]>();
        
        for (int i = 0; i < pairs.GetLength(0); i++) {
            pairList.Add(new int[2] { pairs[i,0], pairs[i,1] } );
        }
        
        // Sort the list by the second number ("end time" in the scheduling problem).
        pairList.Sort(Compare);
        
        int searchIdx = 1;
        int chainLen = 1;
        
        int[] candidate = pairList[0];
        
        // Now we can easily/simply build up our longest chain by greedily picking the 
        // next possible viable option at every step. (That is, the option such that
        // the "start time" is greater than the "end time" of the last element we picked).
        while (searchIdx < pairList.Count) {
            if (pairList[searchIdx][0] > candidate[1]) {
                candidate = pairList[searchIdx];
                chainLen++;
            }
            
            searchIdx++;
        }
        
        return chainLen;
    }
    
    private static int Compare(int[] p1, int[] p2) {
        if (p2[1] < p1[1]) {
            return 1;
        } else if (p1[1] < p2[1]) {
            return -1;
        } else {
            if (p2[0] < p1[0]) {
                return 1;
            } else if (p1[0] < p2[0]) {
                return -1;
            }
        }
        
        return 0;
    }
}