using System;
using System.Collections.Generic;
using System.Linq;



public class Solution {
    public string solution(string s) {
                   List<long> answerLong = Array.ConvertAll(s.Split(' '), long.Parse).ToList();

            long min = answerLong.Min();
            long max = answerLong.Max();

            string answer = $"{min} {max}";
        return answer;
    }
}