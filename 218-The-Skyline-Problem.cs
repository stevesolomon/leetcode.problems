// https://leetcode.com/problems/the-skyline-problem/

public class Solution {
    
    private enum RecordType {
        Start,
        End,
    }
    
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        IList<IList<int>> results = new List<IList<int>>();
        
        // We need to know when each building starts and ends.
        // We'll build up a new list of building starts and building ends.
        List<(int, int, RecordType)> buildingLookup = new List<(int, int, RecordType)>();
        
        foreach (int[] building in buildings) {
            // Add both the start and end records for this building.
            buildingLookup.Add((building[0], building[2], RecordType.Start));
            buildingLookup.Add((building[1], building[2], RecordType.End));
        }
        
        // Sort our records carefully
        buildingLookup.Sort((a, b) => {
            
            // x-coordinates are the same...
            if (a.Item1 == b.Item1) {
                
                // Are they both STARTing a building? Get the one with the highest height up
                // front to ensure that we write its height record first
                if (a.Item3 == b.Item3 && a.Item3 == RecordType.Start) {
                    return b.Item2.CompareTo(a.Item2);
                }
                
                // Are they both ENDing a building? Get the one with the lowest height up front
                // to ensure that we write its height record first.
                if (a.Item3 == b.Item3 && a.Item3 == RecordType.End) {
                    return a.Item2.CompareTo(b.Item2);
                }
                
                // Is one STARTing and the other ENDing?
                if (a.Item3 == RecordType.Start && b.Item3 == RecordType.End) {
                    return -1;
                }
            }
            
            return a.Item1.CompareTo(b.Item1);
        });
        
        // Now, iterate through all the building records in turn. Every time we START
        // a building, add an entry to the Max Heap. If the Max Heap's highest value changes,
        // this new building represents a height change, and we need to add a record to our results.
        // Every time we END a building, remove the corresponding height from our Max Heap. If the highest
        // value has changed, the end of this building represents a height change, and we need to add a record to our results.
        // We can use a SortedDictionary to maintain heights along with the counts of each height we've observed.
        SortedDictionary<int, int> buildingHeights = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        
        // Add an initial height entry of 0, as that's what we start at.
        buildingHeights.Add(0, 1);
        int currMaxHeight = 0;
        
        foreach (var buildingEntry in buildingLookup) {
            RecordType recordType = buildingEntry.Item3;
            int height = buildingEntry.Item2;
            
            if (recordType == RecordType.Start) {
                // We might not have observed this height yet in any buildings still active.
                if (!buildingHeights.ContainsKey(height)) {
                    buildingHeights.Add(height, 0);
                }
                
                buildingHeights[height]++;
            } else {
                // Decrement, or remove, the matching height.
                buildingHeights[height]--;
                
                if (buildingHeights[height] == 0) {
                    buildingHeights.Remove(height);
                }
            }
            
            // Add a result entry following our rules above.
            int newMaxHeight = buildingHeights.First().Key;
            
            if (currMaxHeight != newMaxHeight) {
                results.Add(new List<int> { buildingEntry.Item1, newMaxHeight });
                currMaxHeight = newMaxHeight;
            }
        }        
        
        return results;
    }
}