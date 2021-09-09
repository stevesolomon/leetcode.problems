// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3969/

public class Solution {
    private const int MINE = 0;
    private const int CLEAR = 1;
    
    public int OrderOfLargestPlusSign(int n, int[][] mines) {
        
        // leftPrefix stores how many uninterrupted 1's we have found if we walk right to left
        // upPrefix stores the same, from up to down.
        // etc.
        int[,] leftPrefix = new int[n,n];
        int[,] rightPrefix = new int[n,n];
        int[,] upPrefix = new int[n,n];
        int[,] downPrefix = new int[n,n];
        
        // Build up our lookup matrix of MINE and CLEAR spaces.
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                leftPrefix[row,col] = CLEAR;
                rightPrefix[row,col] = CLEAR;
                upPrefix[row,col] = CLEAR;
                downPrefix[row,col] = CLEAR;
            }
        }
        
        foreach (int[] mine in mines) {
            leftPrefix[mine[0],mine[1]] = MINE;
            rightPrefix[mine[0],mine[1]] = MINE;
            upPrefix[mine[0],mine[1]] = MINE;
            downPrefix[mine[0],mine[1]] = MINE;
        }
        
        int bestFound = 0;
        
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                int reverseRow = n - row - 1 ;
                int reverseCol = n - col - 1 ;
                
                if (row > 0 && downPrefix[row,col] != MINE) {
                    downPrefix[row,col] += downPrefix[row - 1,col];
                }
                
                if (col > 0 && leftPrefix[row,col] != MINE) {
                    leftPrefix[row,col] += leftPrefix[row,col - 1];
                } 
                
                if (reverseRow < n - 1 && upPrefix[reverseRow,reverseCol] != MINE) {
                    upPrefix[reverseRow,reverseCol] += upPrefix[reverseRow + 1,reverseCol];
                }
                
                if (reverseCol < n - 1 && rightPrefix[reverseRow,reverseCol] != MINE) {
                    rightPrefix[reverseRow,reverseCol] += rightPrefix[reverseRow,reverseCol + 1];
                }
                
                //bestFound = Math.Max(bestFound, Math.Min(downPrefix[row,col], Math.Min(leftPrefix[row,col], Math.Min(upPrefix[x,y], rightPrefix[x,y]))));
            }
        }
        
        for(int i = 0 ; i < n ; i++) {
            for(int j = 0 ; j < n ; j++) {
                bestFound = Math.Max(bestFound, Math.Min(downPrefix[i,j], Math.Min(leftPrefix[i,j], Math.Min( upPrefix[i,j], rightPrefix[i,j]))));
            }
        }
        
        return bestFound;            
    }
}