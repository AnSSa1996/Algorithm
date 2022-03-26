using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
            Queue<int> calculatedPS = new Queue<int>();
            List<int> resultsList = new List<int>();

            for (int i = 0; i < progresses.Length; i++)
            {
                int currentProgress = progresses[i];
                int currentSpeeds = speeds[i];
                int completedDays = 0;
                while (currentProgress < 100)
                {
                    currentProgress += currentSpeeds;
                    completedDays += 1;
                }
                calculatedPS.Enqueue(completedDays);
            }


            int maxNum = calculatedPS.Dequeue();
            int possibleCount = 1;

            while (calculatedPS.Count>0)
            {
                int nextPossibleDays = calculatedPS.Dequeue();
                if(maxNum >= nextPossibleDays)
                {
                    possibleCount += 1;
                }
                else
                {
                    maxNum = nextPossibleDays;
                    resultsList.Add(possibleCount);
                    possibleCount = 1;
                }
            }
            resultsList.Add(possibleCount);

            int[] answer = resultsList.ToArray();
        return answer;
    }
}