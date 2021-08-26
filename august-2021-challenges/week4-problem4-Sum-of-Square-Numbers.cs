// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/616/week-4-august-22nd-august-28th/3918/

public class Solution {
    public bool JudgeSquareSum(int c) {
        // Simple case, sqrt(c) is an integer value
        if (Math.Sqrt(c) % 1 < 0.0000001d) {
            return true;
        }
        
        // Otherwise, we'll use two pointers covering the smallest
        // and largest candidate values and try to get a match.
        int smallest = 1;
        int largest = (int) Math.Sqrt(c);
        
        while (smallest <= largest) {
            int smallVal = smallest * smallest;
            int largeVal = largest * largest;
            
            int resultVal = smallVal + largeVal;
            
            if (resultVal == c) {
                return true;
            }
            
            if (resultVal < c) {
                // Increase our small val as we're still too small
                smallest++;
            } else {
                largest--;
            }
        }
        
        return false;
    }
}