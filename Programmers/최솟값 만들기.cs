using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] A, int[] B) {
                   List<int> AList = A.ToList();
            List<int> BList = B.ToList();

            AList.Sort();
            BList.Sort();
            BList.Reverse();

            int answer = 0;
            for (int i = 0; i < AList.Count; i++)
            {
                answer += AList[i] * BList[i];
            }
        return answer;
    }
}