using System;
using System.Collections.Generic;



class Solution
{
    public int[] solution(int n, string[] words)
    {
            List<string> answerList = new List<string>();
            if (words.GetLength(0) > 0)
            {
                answerList.Add(words[0]);
            }

            int whoPerson = 0;
            int turns = 0;
            for (int i = 1; i < words.GetLength(0); i++)
            {
                string preString = words[i - 1];
                string currentString = words[i];

                if (answerList.Contains(currentString) || preString[preString.Length - 1] != currentString[0])
                {
                    whoPerson = i % n + 1;
                    turns = (i / n) + 1;
                    break;
                }
                else
                {
                    answerList.Add(currentString);
                }
            }

            int[] answer = new int[] { whoPerson, turns };
        return answer;
    }
}