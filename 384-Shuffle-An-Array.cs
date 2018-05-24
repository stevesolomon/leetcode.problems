// https://leetcode.com/problems/shuffle-an-array/description/

public class Solution {  
    private int[] original;
    
    private int[] nums;
    
    private Random rand;
    
    public Solution(int[] nums) {
        this.original = (int[])nums.Clone();
        this.nums = nums;
        
        rand = new Random();
    }
    
    /** Resets the array to its original configuration and return it. */
    public int[] Reset() {
        return original;
    }
    
    /** Returns a random shuffling of the array. */
    public int[] Shuffle() {
        for (int i = 0; i < nums.Length; i++) {
            int swapIdx = rand.Next(0, nums.Length);
            
            int temp = nums[i];
            nums[i] = nums[swapIdx];
            nums[swapIdx] = temp;
        }
        
        return nums;
    }
}