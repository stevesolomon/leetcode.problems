// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3352/

public class Solution {
    public int[][] ReconstructQueue(int[][] people) {
        if (people == null || people.Length < 2) {
            return people;
        }
        
        // Sort our list of people in order of height first (desc)
        // and then by number of people in front (asc).
        // This allows us to work our way from the tallest person
        // with the least people in front of them (their positioning is more flexible) 
        // to the shortest person with the most people in front of them (less flexible positioning).
        IEnumerable<int[]> sorted = people.ToList().OrderByDescending(p => p[0]).ThenBy(p => p[1]);
        List<int[]> result = new List<int[]>();
        
        foreach (int[] person in sorted) {
            // Person is the current tallest person with the least people in front of them remaining.
            // Just shove them into the position they're asking for, and shuffle everyone
            // at index i..len behind them.
            // Since we're adding shorter people later, we're guaranteed that the requested slots
            // are always valid to forcibly put the shorter people in.
            // ie: If a short person A claims they are in slot X, then there must be at least X
            //     people taller than them ahead of them. We have already added these X people
            //     into the result (as we work taller -> shorter).
            //     If an even shorter person B comes later, claiming they're in slot X, we do not
            //     violate the constraints if we put them ahead of person A.
            result.Insert(person[1], person);
        }
        
        return result.ToArray();
    }
}