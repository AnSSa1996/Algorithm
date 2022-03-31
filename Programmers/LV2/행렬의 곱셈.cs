using System;

public class Solution {
    public int[,] solution(int[,] arr1, int[,] arr2) {
            int columns = arr1.GetLength(0);
            int rows = arr2.GetLength(1);

            int[,] answer = new int[columns, rows];


            for (int y = 0; y < columns; y++)
            {
                int resultValue = 0;
                for (int x = 0; x < rows; x++)
                {
                    int index = 0;
                    while (index < arr1.GetLength(1))
                    {
                        answer[y, x] += arr1[y, index] * arr2[index, x];
                        index++;
                    }
                }
            }
        return answer;
    }
}