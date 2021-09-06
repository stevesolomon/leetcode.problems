// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/636/week-1-september-1st-september-7th/3965/

public class Solution {
    public char SlowestKey(int[] releaseTimes, string keysPressed) {
        if (releaseTimes == null || releaseTimes.Length == 0) {
            return '0';
        }
        
        int highestTime = releaseTimes[0];
        char highestChar = keysPressed[0];
        
        for(int i = 1; i < releaseTimes.Length; i++) {
            int currTime = releaseTimes[i] - releaseTimes[i - 1];
            if (currTime > highestTime) {
                highestTime = currTime;
                highestChar = keysPressed[i];
            } else if (currTime == highestTime && keysPressed[i].CompareTo(highestChar) > 0) {
                highestChar = keysPressed[i];
            }
        }
        
        return highestChar;
    }
}