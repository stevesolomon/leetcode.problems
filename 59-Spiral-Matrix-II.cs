// https://leetcode.com/problems/spiral-matrix-ii/description/
// Code is a bit messy but that's okay :)

public class Solution {
    public int[,] GenerateMatrix(int n) {
        if (n == 0) {
            return new int[0,0];
        } else if (n == 1) {
            return new int[1,1] { { 1 } };
        }
        
        int[,] result = new int[n,n];
        
        int currNum = 1;
        
        int currX = 0;
        int currY = 0;
        int minX = 0;
        int minY = 1;
        int maxX = n - 1;
        int maxY = n - 1;
        int xDirection = 1;
        int yDirection = 0;
        int lastXDirection = 0;
        int lastYDirection = -1;
        
        while (currNum <= Math.Pow(n, 2)) {
            result[currY, currX] = currNum;
            
            // If x is moving in a positive direction, check if we're at the max.
            if (xDirection > 0) {
                if (currX == maxX) {
                    // We're done this portion. Set xDirection to 0, and Y direction
                    // to the opposite of what it was previously.
                    // Also update our maxX as we'll start moving across Y now, covering
                    // the last column.
                    lastXDirection = xDirection;
                    xDirection = 0;
                    yDirection = lastYDirection < 0 ? 1 : -1;
                    maxX--;
                }
            } else if (xDirection < 0) {
                if (currX == minX) {
                    lastXDirection = xDirection;
                    xDirection = 0;
                    yDirection = lastYDirection < 0 ? 1 : -1;
                    minX++;
                }
            } else if (yDirection > 0) {
                if (currY == maxY) {
                    lastYDirection = yDirection;
                    yDirection = 0;
                    xDirection = lastXDirection < 0 ? 1 : -1;
                    maxY--;
                }
            } else if (yDirection < 0) {
                if (currY == minY) {
                    lastYDirection = yDirection;
                    yDirection = 0;
                    xDirection = lastXDirection < 0 ? 1 : -1;
                    minY++;
                }
            }
            
            currX += xDirection;
            currY += yDirection;
            currNum++;
        }
        
        return result;
    }
}