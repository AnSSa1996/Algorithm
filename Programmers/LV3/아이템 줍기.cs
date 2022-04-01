using System;
using System.Collections.Generic;

public class Solution {
        public static bool[,] map = new bool[102, 102];
        public static int[] dx = { 0, 1, 0, -1 };
        public static int[] dy = { 1, 0, -1, 0 };
        public static int minDepth = int.MaxValue;
    
    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY) {
            
            int length = rectangle.GetLength(0);
            for (int i = 0; i < length; i++) // 전체 사각형 색칠
            {
                int startX = rectangle[i, 0] * 2;
                int startY = rectangle[i, 1] * 2;
                int endX = rectangle[i, 2] * 2;
                int endY = rectangle[i, 3] * 2;

                for (int y = startY; y <= endY; y++)
                {
                    for (int x = startX; x <= endX; x++)
                    {
                        map[y, x] = true;
                    }
                }
            }

            for (int i = 0; i < length; i++) // 테두리를 제외하고 사각형 안쪽 색칠
            {
                int startX = rectangle[i, 0] * 2 + 1;
                int startY = rectangle[i, 1] * 2 + 1;
                int endX = rectangle[i, 2] * 2;
                int endY = rectangle[i, 3] * 2;

                for (int y = startY; y < endY; y++)
                {
                    for (int x = startX; x < endX; x++)
                    {
                        map[y, x] = false;
                    }
                }
            }

            BFS(characterX * 2, characterY * 2, itemX * 2, itemY * 2);
            int answer = minDepth / 2;
        return answer;
    }
    
    public static void BFS(int characterX, int characterY, int itemX, int itemY)
        {
            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(characterY, characterX, 0));

            while (q.Count > 0)
            {
                Pos currentPos = q.Dequeue();
                int currentY = currentPos.PosY;
                int currentX = currentPos.PosX;
                int currentDepth = currentPos.Depth;

                if (currentY == itemY && currentX == itemX)
                {
                    minDepth = Math.Min(minDepth, currentDepth);
                    continue;
                }

                for (int i = 0; i < 4; i++)
                {
                    int nextY = currentY + dy[i];
                    int nextX = currentX + dx[i];

                    if (map[nextY, nextX] == false)
                        continue;
                    map[nextY, nextX] = false;
                    q.Enqueue(new Pos(nextY, nextX, currentDepth + 1));
                }
            }
        }
}

    public class Pos
    {
        public int PosX;
        public int PosY;
        public int Depth;
        public Pos(int posY, int posX, int depth)
        {
            PosX = posX; PosY = posY; Depth = depth;
        }
    }