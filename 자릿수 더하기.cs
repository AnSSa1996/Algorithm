using System;

public class Solution {
    public int solution(int n) {
        string s = n.ToString(); 
        int answer = 0;

            foreach(char c in s)
            {
                answer += int.Parse(c.ToString());
            }
        return answer;
    }
}