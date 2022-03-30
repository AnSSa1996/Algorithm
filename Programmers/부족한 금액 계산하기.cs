using System;

class Solution
{
    public long solution(int price, int money, int count)
    {
        long total = 0;

            while(count > 0)
            {
                total += price * count;
                count--;
            }

            long answer = total - money;
            if (answer < 0)
            {
                answer = 0;
            }
        
        return answer;
    }
}