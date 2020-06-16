// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/541/week-3-june-15th-june-21st/3362/

public class Solution {
    public string ValidIPAddress(string IP) {
        if (string.IsNullOrWhiteSpace(IP)) {
            return "Neither";
        } else if (IP.IndexOf(".") >= 0 && IP.IndexOf(":") >= 0) {
            return "Neither";
        }
        
        string[] ipv4Parts = IP.Split('.');
        string[] ipv6Parts = IP.Split(':');
        
        if (ipv4Parts.Length > 1) {
            return ValidateIpv4(ipv4Parts);
        } else {
            return ValidateIpv6(ipv6Parts);
        }        
    }
    
    private string ValidateIpv4(string[] parts) {
        if (parts.Length != 4) {
            return "Neither";
        }
        
        foreach (string part in parts) {
            // We must have a number between 0 - 255.
            // We could use TryParse here but let's just do it manually...
            if (string.IsNullOrWhiteSpace(part) || part.Length > 3) {
                return "Neither";
            }
            
            int val = 0;
            int charCount = 0;
            
            foreach (char c in part) {
                val *= 10;
                val += (c - '0');
                charCount++;
            }
            
            if (val > 255) {
                return "Neither";
            }
            
            // We must have had no more chars in this part than 
            // digits in our number.
            if (charCount == 3 && val < 100 || charCount == 2 && val < 10) {
                return "Neither";
            }
        }
        
        return "IPv4";
    }
    
    private string ValidateIpv6(string[] parts) {
        if (parts.Length != 8) {
            return "Neither";
        }
        
        foreach (string part in parts) {
            
            if (part.Length < 1 || part.Length > 4) {
                return "Neither";
            }
            
            // Must have hex characters only with a max of 4.
            int charCount = 0;
            
            foreach (char c in part) {
                if (!"0123456789abcdefABCDEF".Contains(c)) {
                    return "Neither";
                }
            }
        }
        
        
        return "IPv6";
    }
}