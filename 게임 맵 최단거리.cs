using System;
using System.Collections.Generic;

class Solution {
    
        public static int[] dx = { 1, 0, -1, 0 };
        public static int[] dy = { 0, -1, 0, 1 };

    public int solution(int[,] maps) {
       
            int columns = maps.GetLength(0);
            int rows = maps.GetLength(1);

            int minNum = int.MaxValue;

            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(0, 0, 1));

            while (q.Count > 0)
            {
                Pos currentPos = q.Dequeue();
                int currentY = currentPos.Y;
                int currentX = currentPos.X;
                int currentDepth = currentPos.Depth;

                if ((currentY == (columns - 1)) && (currentX == (rows - 1)))
                {
                    minNum = currentDepth;
                    break;
                }

                for (int i = 0; i < 4; i++)
                {
                    int nextY = currentY + dy[i];
                    int nextX = currentX + dx[i];

                    if (nextY >= 0 && nextY < columns && nextX >= 0 && nextX < rows)
                    {
                        if (maps[nextY, nextX] == 1)
                        {
                            maps[nextY, nextX] = 0;
                            q.Enqueue(new Pos(nextY, nextX, currentDepth + 1));
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            int answer;
            if (minNum == int.MaxValue)
                answer = -1;
            else
                answer = minNum;
        return answer;
    }
}

 class Pos
    {
        public int Y;
        public int X;
        public int Depth;
        public Pos(int y, int x, int depth)
        {
            Y = y; X = x; Depth = depth;
        }
    }