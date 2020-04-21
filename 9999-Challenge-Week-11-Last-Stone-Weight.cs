// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3297/

public class Solution {
    public int LastStoneWeight(int[] stones) {
        
        if (stones == null || stones.Length < 1) {
            return 0;
        } else if (stones.Length == 1) {
            return stones[0];
        }
        
        // We'll use a MaxHeap to store stones.
        // That way we don't have to sort the array every iteration.
        MaxHeap maxHeap = new MaxHeap(stones);
        
        while (maxHeap.Count > 1) {
            // Take the two highest rocks.
            int rockOne = maxHeap.Remove();
            int rockTwo = maxHeap.Remove();
            
            int diff = Math.Abs(rockOne - rockTwo);
            
            if (diff > 0) {
                maxHeap.Add(diff);
            }
        }
        
        if (maxHeap.Count == 1) {
            return maxHeap.Remove();
        }
        
        return 0;
    }
}

public class MaxHeap {
    int[] heap;
    int writeIdx = 1; // Ignore elem 0 to make the rest easier.
    
    public MaxHeap(int[] vals) {
        heap = new int[vals.Length + 1];
        
        foreach (int val in vals) {
            this.Add(val);
        }
    }
    
    public int Count { get { return writeIdx - 1; } }
    
    public void Add(int val) {
        // Add val to the end of the array and sift up
        heap[writeIdx] = val;
        writeIdx++;
        SiftUp();        
    }
    
    public int Remove() {
        int root = heap[1];
        
        // Now replace the root with the last value and sift down.
        heap[1] = heap[this.Count];        
        SiftDown();
        writeIdx--;
        
        return root;
    }
    
    private void SiftDown() {
        int currIdx = 1;
        
        while (currIdx <= this.Count / 2) {
            // Swap with the greater child if either are
            // greater than us.
            int leftVal = heap[currIdx * 2];
            int rightVal = int.MinValue;
            
            if (currIdx * 2 + 1 < this.Count) {
                rightVal = heap[currIdx * 2 + 1];
            }
            int parentVal = heap[currIdx];
            
            if (leftVal > parentVal || rightVal > parentVal) {
                int swapIdx = leftVal > rightVal ? currIdx * 2 : currIdx * 2 + 1;
                int swapVal = heap[swapIdx];
                
                heap[swapIdx] = heap[currIdx];
                heap[currIdx] = swapVal;
                currIdx = swapIdx;
            } else {
                break;
            }
        }
    }
    
    private void SiftUp() {
        int currIdx = this.Count;
        
        while (currIdx > 1) {
            // Swap with our parent if we are greater
            int childVal = heap[currIdx];
            int parentVal = heap[currIdx / 2];
            
            if (childVal > parentVal) {
                heap[currIdx / 2] = childVal;
                heap[currIdx] = parentVal;
                currIdx /= 2;
            } else {
                break;
            }            
        }
    }
}