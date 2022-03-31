using System;

class Solution
{
    public int solution(int n, int a, int b)
    {
            int count = 0;
            while (true)
            {
                a = (a / 2) + (a % 2);
                b = (b / 2) + (b % 2);
                count += 1;
                    if (a == b)
                    break;
            }
        int answer = count;

        return answer;
    }
}