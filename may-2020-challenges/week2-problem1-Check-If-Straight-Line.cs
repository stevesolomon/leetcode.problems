// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3323/

public class Solution {
    public bool CheckStraightLine(int[][] coordinates) {
        if (coordinates.Length <= 2) {
            return true;
        }
        
        // Calculate the slope for every pair of points. They must all
        // be equal.
        int xDiff = coordinates[0][0] - coordinates[1][0];
        int yDiff = coordinates[0][1] - coordinates[1][1];
        
        double targetSlope = 0.0;
        bool infSlope = false;
        
        // Double check that all points are not sharing the same x-coord.
        if (xDiff == 0) {
            infSlope = true;
        } else {
            targetSlope = (double) yDiff / (double) xDiff;
        }
        
        for (int i = 1; i < coordinates.Length - 1; i++) {
            xDiff = coordinates[i][0] - coordinates[i + 1][0];
            yDiff = coordinates[i][1] - coordinates[i + 1][1];
            
            if (xDiff == 0) {
                if (!infSlope) {
                    return false;
                }
            } else {
                double currSlope = (double) yDiff / (double) xDiff;
                
                if (Math.Abs(targetSlope - currSlope) > 0.0000001) {
                    return false;
                }
            }
        }
        
        return true;
    }
}