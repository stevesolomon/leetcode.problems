// https://leetcode.com/problems/merge-intervals/#/description
/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public IList<Interval> Merge(IList<Interval> intervals) {
        
        if (intervals == null || intervals.Count == 0 || intervals.Count == 1) {
            return intervals;
        }
        
        intervals = intervals.OrderBy(i => i.start).ToList();
        
        IList<Interval> solution = new List<Interval>();
        
        int startVal = intervals[0].start;
        int endVal = intervals[0].end;
        
        int totalIntervals = intervals.Count();
        
        for (int i = 1; i < totalIntervals; i++) {
            Interval currInt = intervals[i];
            
            // If the start of our current interval is between our start and end
            // val of the interval we're building up, we can add it to it.
            if (currInt.start >= startVal && currInt.start <= endVal) {
                if (currInt.end > endVal) {
                    endVal = currInt.end;
                }
            } else if (startVal > currInt.start && endVal <= currInt.end) {
                startVal = currInt.start;
                endVal = currInt.end;
            } else if (startVal >= currInt.start && currInt.end >= startVal && currInt.end <= endVal) {
                startVal = currInt.start;
            }else { // Otherwise, write our built interval out and start fresh.
                solution.Add(new Interval(startVal, endVal));
                
                startVal = currInt.start;
                endVal = currInt.end;
            }
        }
        
        // Write out the last interval we computed...
        solution.Add(new Interval(startVal, endVal));
        
        return solution;
    }
}