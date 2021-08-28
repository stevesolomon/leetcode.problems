// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/616/week-4-august-22nd-august-28th/3950/

public class Solution {
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
        if (startTime == null) {
            throw new ArgumentNullException(nameof(startTime));
        }
        
        if (endTime == null) {
            throw new ArgumentNullException(nameof(endTime));
        }
        
        if (profit == null) {
            throw new ArgumentNullException(nameof(endTime));
        }
        
        if (startTime.Length != endTime.Length || endTime.Length != profit.Length) {
            throw new ArgumentException("All input arrays must be of the same length");
        }
        
        // First, let's make things easy to work with and get our tasks in sorted order.
        // As they're coming in in three separate arrays at the moment let's bundle them 
        // in a single object for each task.
        List<Task> tasks = new List<Task>();
        for (int i = 0; i < startTime.Length; i++) {
            tasks.Add(new Task(startTime[i], endTime[i], profit[i]));
        }
        
        tasks.Sort((x, y) => { 
            int startCmp = x.StartTime.CompareTo(y.StartTime);
            
            if (startCmp != 0) {
                return startCmp;
            }
            
            return x.EndTime.CompareTo(y.EndTime);
        });
        
        // Now, we'll use a lookup table where index i represents the maximum
        // profit when consider jobs 0...i.
        // For each job j, we can either take it, or leave it. We'll need to consider both
        // cases. If we take it, the next lookup table entry we want to consider is
        // the nearest available job *after* the job j has completed. If we ignore it,
        // the next lookup table entry is simply j + 1.
        int[] lookup = new int[tasks.Count + 1];        
        for (int i = 0; i < lookup.Length; i++) {
            lookup[i] = int.MinValue;
        }
        
        return this.BestProfit(tasks, lookup, 0);
    }
    
    private int BestProfit(List<Task> tasks, int[] lookup, int idx) {
        // Outside of the bounds? No more profit to be had.
        if (idx >= tasks.Count) {
            return 0;
        }
        
        // If we've already calculated this particular lookup value
        // just return it. We've already calculated an optimal value previously.
        if (lookup[idx] != int.MinValue) {
            return lookup[idx];
        }
        
        // First we'll assume we don't take the task (simple case), so
        // start calculating the best profit for the next idx.
        int excludedProfit = this.BestProfit(tasks, lookup, idx + 1);
        
        // Then we'll assume we do include the task. In that case, we need
        // to calculate this tasks profit + the best profit from the next available
        // idx (assuming this task runs in full).
        int nextIdx = GetNextTaskIndex(tasks, idx);
        int includedProfit = nextIdx == -1 ? 0 : this.BestProfit(tasks, lookup, nextIdx);
        includedProfit += tasks[idx].Profit;
        
        lookup[idx] = Math.Max(excludedProfit, includedProfit);
        
        return lookup[idx];        
    }
    
    private int GetNextTaskIndex(List<Task> tasks, int idx) {
        
        // A linear search is too slow for some of the problem sets.
        // Since we have everything sorted, and we know the target value,
        // we'll just do a binary search.        
        int earliestStartTime = tasks[idx].EndTime;
        int low = idx + 1;
        int high = tasks.Count - 1;
        
        int candidate = -1;
        
        while (low <= high) {
            int mid = low + (high - low) / 2;
            
            if (tasks[mid].StartTime >= earliestStartTime) {
                // A candidate value that matches the criteria.
                // We may be able to do better though, so keep searching.
                // The further to the 'low' value we get the better (recall: our
                // tasks are sorted first by startTime, and then endTime).
                candidate = mid;
                high = mid - 1;
            } else {
                low = mid + 1;
            }
        }
        
        return candidate;
    }
    
    private class Task
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int Profit { get; set; }
        
        public Task (int startTime, int endTime, int profit) {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Profit = profit;
        }
    }
}