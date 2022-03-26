using System;

public class Solution {
    public long solution(long n) {
            int sqrt = (int)Math.Sqrt(n);
            int answer = -1;
            if (n == (sqrt * sqrt))
            {
                answer = (sqrt + 1) * (sqrt + 1);
            }
        return answer;
    }
}