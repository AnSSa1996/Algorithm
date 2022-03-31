using System;

public class Solution {
     public static int[] answer = { 0, 0 };
    
    public int[] solution(int[,] arr) {
        int nums = arr.GetLength(0);
        SanghunSolution(0, 0, nums, arr);
        return answer;
    }
    
     public static void SanghunSolution(int StartY, int StartX, int n, int[,] arr)
        {
            if (n == 1)
            {
                answer[arr[StartY, StartX]] += 1;
                return;
            }

            int endY = StartY + n;
            int endX = StartX + n;

            int compareNum = arr[StartY, StartX];

            for (int y = StartY; y < endY; y++)
            {
                for (int x = StartX; x < endX; x++)
                {
                    if (compareNum != arr[y, x])
                        goto recursion;
                }
            }
            answer[arr[StartY, StartX]] += 1;
            return;

        recursion:
            SanghunSolution(StartY, StartX, n / 2, arr);
            SanghunSolution(StartY, StartX + n / 2, n / 2, arr);
            SanghunSolution(StartY + n / 2, StartX, n / 2, arr);
            SanghunSolution(StartY + n / 2, StartX + n / 2, n / 2, arr);
        }
}