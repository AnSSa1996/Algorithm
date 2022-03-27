using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string[] solution(int[,] line) {
        
            long lineLength = line.GetLength(0);

            long minX = long.MaxValue;
            long minY = long.MaxValue;

            long maxX = -long.MaxValue;
            long maxY = -long.MaxValue;

            List<long[]> starList = new List<long[]>();

            for (long i = 0; i < lineLength; i++)
            {
                long A = line[i, 0];
                long B = line[i, 1];
                long E = line[i, 2];

                for (long j = i + 1; j < lineLength; j++)
                {
                    long C = line[j, 0];
                    long D = line[j, 1];
                    long F = line[j, 2];

                    long xDown = A * D - B * C;
                    long xUp = B * F - E * D;
                    long yDown = A * D - B * C;
                    long yUp = E * C - A * F;
                    if (A * D - B * C == 0)
                        continue;

                    if (xUp % xDown != 0 || yUp % yDown != 0)
                        continue;

                    long x = xUp / xDown;
                    long y = yUp / yDown;
                    starList.Add(new long[] { y, x });

                    minX = Math.Min(minX, x);
                    minY = Math.Min(minY, y);
                    maxX = Math.Max(maxX, x);
                    maxY = Math.Max(maxY, y);
                }
            }

            long listY = maxY - minY + 1;
            long listX = maxX - minX + 1;
            // 0의 좌표까지 포함

            List<List<char>> answerList = new List<List<char>>();

            for (long i = 0; i < listY; i++)
            {
                answerList.Add(Enumerable.Repeat('.', (int)listX).ToList());
            }

            foreach (var star in starList)
            {
                long starY = maxY - star[0];
                long starX = star[1] - minX;

                answerList[(int)starY][(int)starX] = '*';
            }

            List<string> answerString = new List<string>();

            foreach (var answerChar in answerList)
            {
                answerString.Add(new string(answerChar.ToArray()));
            }

            string[] answer = answerString.ToArray();
        return answer;
    }
}