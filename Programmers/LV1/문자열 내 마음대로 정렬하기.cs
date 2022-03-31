using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string[] solution(string[] strings, int n) {
            List<string> stringList = strings.ToList();
            stringList = stringList.OrderBy(x => x).OrderBy(x => x[n]).ToList();

            string[] answer = stringList.ToArray();
        return answer;
    }
}