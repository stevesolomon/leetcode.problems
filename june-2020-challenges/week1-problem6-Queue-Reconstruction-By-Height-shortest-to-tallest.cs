// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3352/
// Alternative solution to the problem where we go from shortest to tallest with our insertions.

public class Solution {
    public int[][] ReconstructQueue(int[][] people) {
        if (people == null || people.Length < 2) {
            return people;
        }
        
        // Sort our list of people in order of height first (asc)
        // and then by number of people in front (desc).
        // This allows us to work our way from the shortest person
        // with the most people in front of them (if X people in front
        // they must be in elem X in the final array) to the tallest person
        // with the least people in front of them.
        IEnumerable<int[]> sorted = people.ToList().OrderBy(p => p[0]).ThenByDescending(p => p[1]);
        int[][] result = new int[people.Length][];
        
        foreach (int[] person in sorted) {
            int i = 0;
            
            // We need at least person[1] *empty* slots in front of us.
            // Why? Because we're going shortest -> tallest, and from big-k to small-k
            //      So any given person with height H and K k is the shortest person we've seen
            //      thus far, so we will have to fit at least k taller people in front of them,
            //      therefore there needs to be k open slots ahead of them in order to fit
            //      these people in as we get to them.
            int openSlots = 0;
            while (i < people.Length && openSlots < person[1]) {
                if (result[i] == null) {
                    openSlots++;
                }
                
                i++;
            }

            // We also must be at least person[1] down the line...
            if (i < person[1]) {
                i = person[1];
            }
            
            // Finally, find the next available open slot.
            while (i < people.Length && result[i] != null) {
                i++;
            }
            
            result[i] = person;
        }
        
        return result;
    }
}