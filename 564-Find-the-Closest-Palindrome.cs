// https://leetcode.com/problems/find-the-closest-palindrome/

public class Solution {
    public string NearestPalindromic(string n) {        
        if (n == null || n.Length == 0) {
            return n;
        }
        
        int length = n.Length;
        long numericVal = long.Parse(n);
        
        // Special cases:
        // Less than 10? Subtract 1 and we're done.
        if (numericVal < 10) {
            return (numericVal - 1).ToString();
        } else if (numericVal % 10 == 0) {
            // If we have all zeroes after the first digit...
            // We just need to decrement 1 (ie: 10 -> 9, 1000 -> 999, etc.)
            bool allZero = true;
            for (int i = 1; i < n.Length; i++) {
                if (n[i] != '0') {
                    allZero = false;
                    break;
                }
            }
            
            if (allZero) {
                return (numericVal - 1).ToString();
            }
        } else if (numericVal % 10 == 1) {
            // If we start and end with a 1, and have zeroes in between we can just subtract 2
            // ie: 11 -> 9, 1001 --> 999, etc.
            bool allZero = true;
            for (int i = 1; i < n.Length - 1; i++) {
                if (n[i] != '0') {
                    allZero = false;
                    break;
                }
            }
            
            if (allZero && n[n.Length - 1] == '1') {
                return (numericVal - 2).ToString();
            }
        } else {
            // Check if we have all 9's, if so add 2 (ie: 99 -> 101, 9999 -> 10001)
            bool allNines = true;
            for (int i = 0; i < n.Length; i++) {
                if (n[i] != '9') {
                    allNines = false;
                    break;
                }
            }
            
            if (allNines) {
                return (numericVal + 2).ToString();
            }
        }
        
        // We have two possible cases here:
        //  (1) n is a palindrome
        //  (2) n is not a palindrome.
        // -  For the first case, we need to find the next nearest palindrome, which merely involves
        //    incrementing or decrementing the middle portion of the string (1 char for odd lengths, 2 for even).
        //  - For the second case, we start the same as the first case, but also consider a third option of leaving the
        //    middle portion alone entirely. We then need to mirror the back half of the string to form the palindrome.
        //    In effect, this is modifying the least-significant digits, which will give us the closest palindrome.
        bool isPalindrome = IsPalindrome(n);
        bool isEvenLength = length % 2 == 0;
        string pivotStr = isEvenLength ? n.Substring(0, length / 2) : n.Substring(0, length / 2 + 1);
        
        List<string> options = new List<string>();
        
        if (isPalindrome) {            
            // Try incrementing the pivot...
            string inc = BuildPalindromeFromPivot(pivotStr, 1, isEvenLength);        
            options.Add(inc);
            
            // And then decrementing...
            string dec = BuildPalindromeFromPivot(pivotStr, -1, isEvenLength);       
            options.Add(dec);
        } else {            
            // Three options this time. Increment pivot, decrement pivot, keep pivot the same.
            // And then we have to rebuilt the palindrome on the opposite side.            
            for (int optionCtr = -1; optionCtr < 2; optionCtr++) {           
                string newString = BuildPalindromeFromPivot(pivotStr, optionCtr, isEvenLength);                
                options.Add(newString);
            }
        }
        
        // Now loop over our options and find the closest one.
        string bestCandidate = string.Empty;
        long bestCandidateVal = long.MaxValue;
        long minimalDiff = long.MaxValue;
        long originalValue = long.Parse(n);
        
        foreach (var candidate in options) {
            long val = long.Parse(candidate);
            
            long diff = Math.Abs(originalValue - val);
            
            if (diff < minimalDiff) {
                minimalDiff = diff;
                bestCandidateVal = val;
                bestCandidate = candidate;
            } else if (diff == minimalDiff && val < bestCandidateVal) {
                bestCandidate = candidate;
                bestCandidateVal = val;
            }
        }
        
        return bestCandidate;        
    }
    
    private bool IsPalindrome(string n) {
        int start = 0, end = n.Length - 1;
        
        while (start < end) {
            if (n[start] != n[end]) {
                return false;
            }
            
            start++;
            end--;
        }
        
        return true;
    }
    
    private string BuildPalindromeFromPivot(string pivotStr, int incrementVal, bool evenLengthString) {
        long pivotVal = long.Parse(pivotStr);        
        pivotVal += incrementVal;
        
        StringBuilder sb = new StringBuilder(pivotVal.ToString());
        
        // Now write in the second half of the string to form the palindrome...
        int readIdx = pivotStr.Length - 2;
        
        // If our original string was of even length we want to include the end of the pivot string..
        if (evenLengthString) {
            readIdx++;
        }
        
        for (int i = readIdx; i >= 0; i--) {
            sb.Append(sb[i]);
        }
        
        return sb.ToString();
    }
}