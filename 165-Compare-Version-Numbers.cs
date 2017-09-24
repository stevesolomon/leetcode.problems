// https://leetcode.com/problems/compare-version-numbers/description/

public class Solution {
    public int CompareVersion(string version1, string version2) {
        if (string.IsNullOrWhiteSpace(version1) && !string.IsNullOrWhiteSpace(version2)) {
            return -1;
        } else if (!string.IsNullOrWhiteSpace(version1) && string.IsNullOrWhiteSpace(version2)) {
            return 1;
        } else if (string.IsNullOrWhiteSpace(version1) && string.IsNullOrWhiteSpace(version2)) {
            return 0;
        }
        
        string[] parts1 = version1.Split('.');
        string[] parts2 = version2.Split('.');
        int i;
        
        for (i = 0; i < parts1.Length && i < parts2.Length; i++) {
            int part1 = int.Parse(parts1[i]);
            int part2 = int.Parse(parts2[i]);
            
            if (part1 > part2) {
                return 1;
            } else if (part2 > part1) {
                return -1;
            }
        }
        
        if (i < parts1.Length) {
            for (; i < parts1.Length; i++)
            {
                if (int.Parse(parts1[i]) != 0) {
                    return 1;
                }
            }
        } else if (i < parts2.Length) {
            for (; i < parts2.Length; i++)
            {
                if (int.Parse(parts2[i]) != 0) {
                    return -1;
                }
            }
        }
        
        return 0;
    }
}