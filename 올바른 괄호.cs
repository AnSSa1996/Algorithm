using System;

public class Solution {
    public bool solution(string s) {
                    int Count = 0;

            foreach(char c in s)
            {
                if (c == '(')
                    Count++;
                else
                    Count--;
                if (Count < 0)
                    break;
            }

            bool answer = false;
            if (Count == 0)
            {
                answer = true;
            }
        return answer;
    }
}