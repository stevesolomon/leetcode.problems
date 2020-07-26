// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/547/week-4-july-22nd-july-28th/3402/

public class Solution {
    public int AddDigits(int num) {
        return 1 + ((num - 1) % 9);
    }
}