// https://leetcode.com/explore/featured/card/july-leetcoding-challenge/544/week-1-july-1st-july-7th/3379/

public class Solution {
    int[] copy;
    
    public int[] PrisonAfterNDays(int[] cells, int N) {
        if (cells == null || cells.Length != 8 || N < 1) {
            return cells;
        }
        
        copy = new int[cells.Length];
        
        HashSet<string> lookup = new HashSet<string>();
        List<int[]> orderedStates = new List<int[]>();
        int totalStates = 0;
        bool foundCycle = false;
        
        for (int i = 0; i < N; i++) {
            string lookupStr = GetLookup(cells);
            
            if (lookup.Contains(lookupStr)) {
                foundCycle = true;
                break;
            }
            
            // Otherwise continue building up our linear list
            // of state progression...
            lookup.Add(lookupStr);
            
            int[] copy = new int[cells.Length];
            Array.Copy(cells, copy, cells.Length);
            orderedStates.Add(copy);      
            
            // And generate the next state...            
            CalcCells(cells);
            
            totalStates++;
        }
        
        if (!foundCycle) {
            return cells;
        }
        
        int repeatStart = 0;
        
        for (int i = 0; i < orderedStates.Count; i++) {
            if (GetLookup(cells) == GetLookup(orderedStates[i])) {
                repeatStart = i;
                break;
            }
        }
        int repeatLength = orderedStates.Count - repeatStart;
        
        N -= orderedStates.Count;
        N %= repeatLength;
        
        return orderedStates[repeatStart + N];
    }
    
    private void CalcCells(int[] cells) {    
        for (int i = 1; i < cells.Length - 1; i++) {
            copy[i] = cells[i - 1] == 0 && cells[i + 1] == 0 ? 1 :
                      cells[i - 1] == 1 && cells[i + 1] == 1 ? 1 : 0;
        }
        
        copy[0] = 0;
        copy[cells.Length - 1] = 0;
        
        Array.Copy(copy, cells, cells.Length);
    }
    
    private string GetLookup(int[] cells) {
        return string.Join("", cells);
    }
}