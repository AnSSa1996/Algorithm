using System.Collections.Generic;
using System.Linq;


public class Solution {
    public double solution(int[] arr) {
            List<int> listInt = arr.ToList();
            double answer = listInt.Average();
        return answer;
    }
}