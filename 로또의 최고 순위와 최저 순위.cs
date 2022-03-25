using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] lottos, int[] win_nums) {
            List<int> lottosList = lottos.ToList<int>();
            List<int> winNumsList = win_nums.ToList<int>();

            int zero = 0;
            for (int i = 0; i < lottosList.Count; i++)
            {
                if (lottosList[i] == 0)
                {
                    zero++;
                    lottosList.RemoveAt(i);
                    i--;
                }
            }

            int sameNum = 0;
            foreach (int num in lottosList)
            {
                if (winNumsList.Contains(num))
                    sameNum++;
            }
            int answer_X = ((7 - sameNum - zero) > 6) ? 6 : (7 - sameNum - zero);
            int answer_Y = ((7 - sameNum) > 6) ? 6 : (7 - sameNum);

            int[] answer = { answer_X, answer_Y };
        
        return answer;
    }
}