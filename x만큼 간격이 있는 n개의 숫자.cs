using System.Collections.Generic;


public class Solution {
    public long[] solution(int x, int n) {
            long x_long = x;
            long n_long = n;
            List<long> answerList = new List<long>();

            for (long i = 1; i <= n_long; i++)
            {
                answerList.Add(x_long * i);
            }

            long[] answer = answerList.ToArray();
        return answer;
    }
}