using System.Collections.Generic;
using System.Linq;


public class Solution {
    public int solution(int[] arr) {
                    List<int> numsList = arr.ToList();

            int LCM = numsList[0];

            for (int i = 1; i < numsList.Count; i++)
            {
                int Gcdint = GCD(LCM, numsList[i]);
                LCM = LCM * numsList[i] / Gcdint;
            }
        return LCM;
    }
    
     public static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GCD(b, a % b);
            }
        }
}