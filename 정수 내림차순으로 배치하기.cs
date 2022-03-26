using System;
using System.Linq;

public class Solution {
    public long solution(long n) {
            string s = n.ToString();
            char[] c = s.ToCharArray();
            Array.Sort(c);
            c = c.Reverse().ToArray();
            s = new string(c);

            long answer = long.Parse(s);
        return answer;
    }
}