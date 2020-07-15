// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/545/week-2-july-8th-july-14th/3390/

public class Solution {
    public double AngleClock(int hour, int minutes) {
        
        double hourAngle = hour == 12 ? 0 : ((double) hour / 12.0) * 360.0;
        double minuteAngle = ((double) minutes / 60.0) * 360.0;
        
        hourAngle += 0.5 * minutes;
        double result = Math.Abs(hourAngle - minuteAngle);
        
        return Math.Min(result, 360 - result);
    }
    
}