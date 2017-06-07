// https://leetcode.com/problems/binary-watch/#/description

public class Solution {
    
    private int[] bits = { 1, 2, 4, 8, 16, 32, 100, 200, 400, 800 };
    
    public IList<string> ReadBinaryWatch(int num) {
        IList<string> solutions = new List<string>();
        
        ReadBinaryWatch(num, 0, solutions, 0);
        
        return solutions;
    }
    
    private void ReadBinaryWatch(int numRemaining, int bit, IList<string> solutions, int currCount) {
        if (numRemaining == 0) {
            if (ValidSolution(currCount)) {
                solutions.Add(GetTime(currCount));
            }
            return;
        } else if (bit > 9) { // Invalid solution that did not light up enough bits.
            return;
        }
        
        // Consider first flipping on this bit.
        ReadBinaryWatch(numRemaining - 1, bit + 1, solutions, currCount + bits[bit]);
        
        // And then not flipping on this bit.
        ReadBinaryWatch(numRemaining, bit + 1, solutions, currCount);
    }
    
    private string GetTime(int currCount) {
        StringBuilder sb = new StringBuilder();
        
        int hour = currCount / 100;
        int minutes = currCount % 100;
        
        if (hour > 0) {
            sb.Append(hour.ToString());
        } else {
            sb.Append("0");
        }
        
        sb.Append(":");
        
        if (minutes < 10) {
            sb.Append("0");
        }
        
        sb.Append(minutes);
        
        return sb.ToString();
    }
    
    private bool ValidSolution(int currCount) {
        int hour = currCount / 100;
        int minutes = currCount % 100;
        
        if (hour > 11) { return false; }
        if (minutes > 59) { return false; }
        
        return true;
    }
}