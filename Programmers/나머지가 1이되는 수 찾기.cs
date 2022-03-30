using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    
    public static bool[] EratosBool = Enumerable.Repeat(true, 1000001).ToArray<bool>();
    public static List<int> sosu = new List<int>();
    
    public int solution(int n) {
        Eratos(n);

        int answer = 0;
        foreach (int num in sosu)
            {
                if (n % num == 1)
                {
                    answer = num;
                    break;
                }
            }
        return answer;
    }
    
     public static void Eratos(int n)
        {
            EratosBool[0] = false;
            EratosBool[1] = false;

            for (int i = 2; i * i < n; i++)
            {
                if (EratosBool[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        EratosBool[j] = false;
                    }
                }
            }

            for (int i = 2; i < n; i++)
            {
                if (EratosBool[i])
                    sosu.Add(i);
            }
        }
}