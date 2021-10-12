// https://leetcode.com/problems/guess-number-higher-or-lower/submissions/

/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is lower than the guess number
 *			      1 if num is higher than the guess number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        if (n == 1) {
            return 1;
        }
        
        int high = n;
        int low = 1;
        int currGuess = 1;
        
        while (true) {
            currGuess = ((high - low) / 2) + low;
            int result = guess(currGuess);
            
            if (result == 0) {
                break;
            }
            
            if (result < 0) {
                high = currGuess - 1;
            } else {
                low = currGuess + 1;
            }
        }
        
        return currGuess;
    }
}