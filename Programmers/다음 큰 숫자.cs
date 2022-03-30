using System;
using System.Linq;

class Solution 
{
    public int solution(int n) 
   {
            string bitNstring = Convert.ToString(n, 2);
            int Count = bitNstring.Count(x => x == '1');

            int CountNext = 0;
            while (true)
            {
                n++;
                CountNext = Convert.ToString(n, 2).Count(x => x == '1');
                if (Count == CountNext)
                    break;
            }
        return n;
    }
}