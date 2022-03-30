using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] array, int[,] commands) {
            int repeatNum = commands.GetLength(0);
            List<int> answerList = new List<int>();
            for (int i = 0; i < repeatNum; i++)
            {
                int startIndex = commands[i, 0] - 1;
                int length = commands[i, 1] - startIndex;
                int[] newInt = new int[length];
                Array.Copy(array, startIndex, newInt, 0, length);
                Array.Sort(newInt);
                int num = newInt[commands[i, 2] - 1];
                answerList.Add(num);
            }
            int[] answer = answerList.ToArray();
        return answer;
    }
}