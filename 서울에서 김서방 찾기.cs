using System.Collections.Generic;
using System.Linq;


public class Solution {
    public string solution(string[] seoul) {
            List<string> seoulList = seoul.ToList();

            int index = seoulList.FindIndex(x => x.Contains("Kim"));
            string answer = $"김서방은 {index}에 있다";
        return answer;
    }
}