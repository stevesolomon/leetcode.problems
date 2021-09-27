// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/639/week-4-september-22nd-september-28th/3989/

public class Solution {
    public int NumUniqueEmails(string[] emails) {
        if (emails == null || emails.Length == 0) {
            return 0;
        }
        
        // For every email, we need to ignore '.'s and stop looking at everything after a '+'
        // until we reach an '@'.
        HashSet<string> uniqueEmails = new HashSet<string>();
        
        foreach (var email in emails) {
            StringBuilder sb = new StringBuilder();
            string[] split = email.Split('@');
            
            if (split.Length > 2) {
                continue;
            }
            
            string local = split[0];
            string domain = split[1];
            
            foreach (char c in local) {
                if (c == '+') {
                    break;
                } else if (c != '.') {
                    sb.Append(c);
                }
            }
            
            sb.Append("@");
            sb.Append(domain);
            
            uniqueEmails.Add(sb.ToString());
        }
        
        return uniqueEmails.Count;
    }
}