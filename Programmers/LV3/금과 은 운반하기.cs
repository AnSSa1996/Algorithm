using System;

public class Solution {
    public long solution(int a, int b, int[] g, int[] s, int[] w, int[] t) {
         // 이분 탐색 초깃값 세팅
            long minTime = (long)int.MaxValue * 1000000;
            long start = 0;
            long end = minTime;


            // 이분탐색 시작
            while (start <= end)
            {
                long mid = (start + end) / 2;
                long Gold = 0; // 현재 옮길 수 있는 총 골드
                long Silver = 0; // 현재 옮길 수 있는 총 실버
                long total = 0; // 두 골드,실버를 옮겼을 때, 총 합 (나눠서 운반할 경우)

                for (int i = 0; i < g.Length; i++)
                {
                    long currentG = g[i];
                    long currentS = s[i];
                    long currentW = w[i];
                    long currnetT = t[i];

                    long moveCount = 0;

                    moveCount = mid / (currnetT * 2); //가능한 왕복 횟수;

                    if (mid % (currnetT * 2) >= currnetT) // 편도로 한 번 더 갈 수 있다면 moveCount++
                    {
                        moveCount++;
                    }


                    long maxLoad = moveCount * currentW;

                    if (currentG < maxLoad) Gold += currentG;
                    else Gold += moveCount * currentW;

                    if (currentS < maxLoad) Silver += currentS;
                    else Silver += moveCount * currentW;

                    if (currentG + currentS < maxLoad) total += currentG + currentS;
                    else total += moveCount * currentW;
                }

                if (Gold >= a && Silver >= b && total >= a + b)
                {
                    end = mid - 1;
                    minTime = Math.Min(minTime, mid);
                }
                else
                {
                    start = mid + 1;
                }
            }
        return minTime;
    }
}