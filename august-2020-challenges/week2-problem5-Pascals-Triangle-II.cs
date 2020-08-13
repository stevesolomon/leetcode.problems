// https://leetcode.com/explore/featured/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3421/

public class Solution {
    public IList<int> GetRow(int rowIndex) {
        if (rowIndex < 0) {
            return new List<int>();
        } else if (rowIndex == 0) {
            return new List<int> { 1 };
        }
        
        int[] vals = new int[rowIndex + 1];
        vals[0] = 1;
        vals[1] = 1;        
        
        for (int row = 2; row <= rowIndex; row++) {
            
            vals[row - 1] = 1;
            int left = vals[0];
            int right = vals[1];
            
            for (int i = 1; i < row; i++) {
                vals[i] = left + right;
                left = right;
                right = vals[i + 1];
            }
        }
        
        vals[rowIndex] = 1;
        
        return vals.ToList();
    }
}