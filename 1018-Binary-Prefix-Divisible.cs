// https://leetcode.com/problems/binary-prefix-divisible-by-5/

public class Solution {
    public IList<bool> PrefixesDivBy5(int[] A) {
        
        List<bool> results = new List<bool>();
        
        if (A == null || A.Length == 0) {
            return results;
        }
        
        int currRemainder = 0;
        
        for (int i = 0; i < A.Length; i++) {
            
            // We can build up a state table that shows us how we transition
            // between remainder "states", where state changes are defined
            // by the next bit that we read.
            // Rem0 -- 0 --> Rem0
            // Rem0 -- 1 --> Rem1
            // Rem1 -- 0 --> Rem2
            // Rem1 -- 1 --> Rem3
            // Rem2 -- 0 --> Rem4
            // Rem2 -- 1 --> Rem0
            // Rem3 -- 0 --> Rem1
            // Rem3 -- 1 --> Rem2
            // Rem4 -- 0 --> Rem3
            // Rem4 -- 1 --> Rem4
            switch (currRemainder) {
                case 0:
                    switch (A[i]) {
                        case 0:
                            currRemainder = 0;
                            break;
                        case 1:
                            currRemainder = 1;
                            break;
                    }
                    break;
                case 1:
                    switch (A[i]) {
                        case 0:
                            currRemainder = 2;
                            break;
                        case 1:
                            currRemainder = 3;
                            break;
                    }
                    break;
                case 2:
                    switch (A[i]) {
                        case 0:
                            currRemainder = 4;
                            break;
                        case 1:
                            currRemainder = 0;
                            break;
                    }
                    break;
                case 3:
                    switch (A[i]) {
                        case 0:
                            currRemainder = 1;
                            break;
                        case 1:
                            currRemainder = 2;
                            break;
                    }
                    break;
                case 4:
                default:
                    switch (A[i]) {
                        case 0:
                            currRemainder = 3;
                            break;
                        case 1:
                            currRemainder = 4;
                            break;
                    }
                    break;
            }
            
            results.Add(currRemainder == 0 ? true : false);
        }
        
        
        return results;
        
    }
}