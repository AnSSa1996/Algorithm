using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] d, int budget) {
            List<int> numList = d.ToList();
            numList.Sort();

            int maxNum = 0;

            for (int i = 0; i < numList.Count; i++)
            {
                budget -= numList[i];
                if (budget < 0)
                    break;
                maxNum++;
            }
        return maxNum;
    }
}