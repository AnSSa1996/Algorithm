using System;
using System.Collections.Generic;

public class Solution {
    public long[] solution(int n, long left, long right) {
                   List<List<int>> numsList = new List<List<int>>();

           List<long> answerList = new List<long>();
            for (long i = left; i <= right; i++)
            {
                long a = i / n;
                long b = i % n;
                long maxNum = Math.Max(a, b);
                answerList.Add(maxNum + 1);
            }

            long[] answer = answerList.ToArray();
        return answer;
    }
}