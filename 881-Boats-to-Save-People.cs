// https://leetcode.com/problems/boats-to-save-people/

public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        if (people == null || people.Length == 0 || limit <= 0) {
            return 0;
        }
        
        // Sort the list of weights first...
        Array.Sort(people);
        
        // Now keep pointers at both ends of the sorted array.
        // We'll try to match up people like this.
        int lowIdx = 0, highIdx = people.Length - 1;
        int numBoats = 0;
                
        // Now continue to match people up (if possible) and move our pointers closer together.
        while (highIdx > lowIdx) {
            
            // We can take both people
            if (people[lowIdx] + people[highIdx] <= limit) {
                highIdx--;
                lowIdx++;
            } else { // We can only take the higher-weighted person...
                highIdx--;
            }
            
            numBoats++;
        }
        
        if (highIdx == lowIdx) {
            // One last person to take...
            numBoats++;
        }
        
        return numBoats;
    }
}