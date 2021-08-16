// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3892/

public class NumArray {
    
    // Will store the prefix sum of nums
    private int[] prefixSum;

    public NumArray(int[] nums) {
        if (nums == null) {
            throw new ArgumentNullException(nameof(nums));
        }
        
        this.CalcPrefixSum(nums);
    }
    
    public int SumRange(int left, int right) {
        if (left < 0 || right >= this.prefixSum.Length || left > right) {
            throw new ArgumentException();
        }
        
        int leftVal = left == 0 ? 0 : prefixSum[left - 1];
        int rightVal = prefixSum[right];
        
        return rightVal - leftVal;
    }
    
    private void CalcPrefixSum(int[] nums) {
        this.prefixSum = new int[nums.Length];
        
        int currVal = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            currVal += nums[i];
            
            prefixSum[i] = currVal;
        }
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */