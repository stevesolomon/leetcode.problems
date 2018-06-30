// https://leetcode.com/problems/kth-largest-element-in-an-array/description/

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        
        if (nums == null || nums.Length < k) {
            return -1;
        }
        
        int N = nums.Length;
        
        // First let's store our data into a minheap
        int[] minHeap = new int[N + 1];
        int heapIndex = 0;
        
        foreach (int num in nums) {
            InsertIntoHeap(minHeap, num, ++heapIndex);
        }
        
        int result = int.MinValue;
        
        // Now simply remove N - k elements from the minHeap and the
        // kth largest will be at the top.
        for (int i = 0; i <= N - k; i++) {
            result = RemoveFromHeap(minHeap, heapIndex--);
        }
        
        return result;
    }
    
    private void InsertIntoHeap(int[] minHeap, int num, int heapIndex) {
        minHeap[heapIndex] = num;
        
        // Propagate the new value up the heap as long as it's smaller than its parent.
        while (heapIndex > 1) {
            
            // We are larger than our parent, we're done.
            if (minHeap[heapIndex] >= minHeap[heapIndex / 2]) {
                break;
            }
            Swap(minHeap, heapIndex, heapIndex / 2);
            heapIndex /= 2;
        }
    }
    
    private int RemoveFromHeap(int[] minHeap, int heapSize) {
        
        // Remove the root, this is what we'll return later.
        int root = minHeap[1];
        
        // Move the very last element up to the root.
        minHeap[1] = minHeap[heapSize];
        
        // And then propagate it down, always swapping with its lesser child.
        int idx = 1;
        
        while (idx < heapSize * 2) {
            int leftIdx = idx * 2;
            int rightIdx = idx * 2 + 1;
            
            if (leftIdx > heapSize || rightIdx > heapSize) {
                break;
            }
            
            int minValue = minHeap[leftIdx];
            minValue = rightIdx > heapSize ? minValue : Math.Min(minValue, minHeap[rightIdx]);
            
            if (minValue != minHeap[leftIdx]) {
                Swap(minHeap, idx, rightIdx);
                idx = rightIdx;
            } else {
                Swap(minHeap, idx, leftIdx);
                idx = leftIdx;
            }
        }
        
        return root;
    }
    
    private void Swap(int[] minHeap, int idx1, int idx2) {
        int temp = minHeap[idx1];
        minHeap[idx1] = minHeap[idx2];
        minHeap[idx2] = temp;
    }
}