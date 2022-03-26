using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(long n) {
            string s = n.ToString();
            char[] c = s.ToCharArray().Reverse().ToArray();

            List<int> answerList = new List<int>();

            foreach(var character in c)
            {
                answerList.Add(int.Parse(character.ToString()));
            }

            int[] answer = answerList.ToArray();
        return answer;
    }
}