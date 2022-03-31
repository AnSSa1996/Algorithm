using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] arr, int divisor) {
            List<int> divList = new List<int>();
            foreach (int num in arr)
            {
                if (num % divisor == 0)
                {
                    divList.Add(num);
                }
            }

            divList.Sort();

            if(divList.Count == 0)
            {
                divList.Add(-1);
            }
            int[] answer = divList.ToArray();
        return answer;
    }
}