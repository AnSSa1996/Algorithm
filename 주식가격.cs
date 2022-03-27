using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] prices) {
            int length = prices.Length;

            List<int> answerList = Enumerable.Repeat(0, length).ToList();

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (prices[i] <= prices[j])
                    {
                        answerList[i]++;
                    }
                    else
                    {
                        answerList[i]++;
                        break;
                    }
                }
            }

            int[] answer = answerList.ToArray();
        return answer;
    }
}