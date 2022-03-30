using System.Collections.Generic;
using System.Linq;


public class Solution {
    public int[] solution(int[] arr) {
            List<int> intList = arr.ToList();
            intList.Remove(intList.Min());

            if (intList.Count == 0)
            {
                intList.Add(-1);
            }
            int[] answer = intList.ToArray();
        return answer;
    }
}