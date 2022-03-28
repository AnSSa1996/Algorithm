using System;
using System.Collections.Generic;

public class Solution {
    public static int[] dy = { 0, 1, 0, -1 };
    public static int[] dx = { 1, 0, -1, 0 };
    
    public int solution(string dirs) {
            bool[,] checkBool = new bool[121, 121];
            int currentY = 5;
            int currentX = 5;
            int Count = 0;

            for (int i = 0; i < dirs.Length; i++)
            {
                int dir = SanghunCheck(dirs[i]);
                int nextY = currentY + dy[dir];
                int nextX = currentX + dx[dir];

                if (nextY < 0 || nextY > 10 || nextX < 0 || nextX > 10)
                {
                    continue;
                }

                int currentint = currentY * 11 + currentX;
                int nextint = nextY * 11 + nextX;

                currentY = nextY;
                currentX = nextX;
                if (checkBool[currentint, nextint])
                {
                    continue;
                }

                checkBool[currentint, nextint] = true;
                checkBool[nextint, currentint] = true;
                Count++;
            }
        return Count;
    }
    
    
        public static int SanghunCheck(char c)
        {
            switch (c)
            {
                case 'R':
                    return 0;
                case 'U':
                    return 1;
                case 'L':
                    return 2;
                default:
                    return 3;
            }
        }
}