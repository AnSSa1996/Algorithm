using System;
using System.Collections.Generic;

public class Solution {
        public static int[] dx = { 1, 0, -1, 0 }; // 오른쪽, 아래쪽, 왼쪽, 위쪽
        public static int[] dy = { 0, -1, 0, 1 }; // 오른쪽, 아래쪽, 왼쪽, 위쪽
        public static bool[,,] visited;
        public static string[] gridStatic;
    
    public int[] solution(string[] grid) {
            gridStatic = grid;

            int columns = grid.GetLength(0);
            int rows = grid[0].Length;
            visited = new bool[columns, rows, 4];

            List<Tuple<int, int>> firstStart = new List<Tuple<int, int>>();

            List<int> results = new List<int>();

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    firstStart.Add(new Tuple<int, int>(i, j));
                }
            }

            foreach (var start in firstStart)
            {
                int startY = start.Item1;
                int startX = start.Item2;

                for (int startDir = 0; startDir < 4; startDir++)
                {

                    if (visited[startY, startX, startDir])
                        continue;

                    int Count = 1;
                    Queue<Pos> q = new Queue<Pos>();
                    q.Enqueue(new Pos(startY, startX, startDir));

                    while (q.Count > 0)
                    {
                        Pos p = q.Dequeue();
                        int currentY = p.Y;
                        int currentX = p.X;
                        int currentDir = p.Dir;
                        visited[currentY, currentX, currentDir] = true;

                        int nextY = currentY + dy[currentDir];

                        if (nextY < 0)
                            nextY = columns - 1;

                        if (nextY > columns - 1)
                            nextY = 0;

                        int nextX = currentX + dx[currentDir];

                        if (nextX < 0)
                            nextX = rows - 1;

                        if (nextX > rows - 1)
                            nextX = 0;

                        int nextDir = SanghunSolution(nextY, nextX, currentDir);

                        if (visited[nextY, nextX, nextDir] == true)
                        {
                            // 현재 startY, startX, startDir과 같다면 성공
                            if (nextY == startY && nextX == startX && nextDir == startDir)
                            {
                                results.Add(Count);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }

                        Count += 1;
                        q.Enqueue(new Pos(nextY, nextX, nextDir));
                    }
                }
            }

            results.Sort();

            int[] answer = results.ToArray();
        return answer;
    }
    
      public static int SanghunSolution(int y, int x, int dir)
        {
            char c = gridStatic[y][x];

            switch (c)
            {
                case 'S':
                    break;
                case 'L':
                    dir -= 1;
                    if (dir == -1)
                        dir = 3;
                    break;
                case 'R':
                    dir += 1;
                    if (dir == 4)
                        dir = 0;
                    break;
            }

            return dir;
        }
}


public class Pos
        {
            public int Y;
            public int X;
            public int Dir;

            public Pos(int y, int x, int dir)
            {
                Y = y; X = x; Dir = dir;
            }
        }