using System;
using System.Collections.Generic;

public class Solution {
    public long[] solution(long[] numbers) {
            List<long> result = new List<long>();

            foreach (long n in numbers)
            {
                if (n % 2 == 0)
                {
                    result.Add(n + 1);
                    continue;
                }
                else
                {
                    long bit = 1;
                    while (true)
                    {
                        if ((n & bit) == 0)
                        {
                            result.Add(n + bit / 2);
                            break;
                        }
                        bit = bit * 2;
                    }
                }
            }

            long[] answer = result.ToArray();
        return answer;
    }
}