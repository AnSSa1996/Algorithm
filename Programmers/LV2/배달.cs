using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{        
    public static bool[] visited;
    public static List<int> distance;
    public int solution(int N, int[,] road, int K)
    {
        
            List<List<int>> roadList = new List<List<int>>();
            List<int> copyList = Enumerable.Repeat(-1, N).ToList();

            visited = new bool[N];
            distance = Enumerable.Repeat(int.MaxValue, N).ToList();

            for (int i = 0; i < N; i++)
            {
                roadList.Add(copyList.ToList());
            }

            int nums = road.GetLength(0);

            for (int i = 0; i < nums; i++)
            {
                if (roadList[road[i, 0] - 1][road[i, 1] - 1] > 0)
                {
                    int min = Math.Min(roadList[road[i, 0] - 1][road[i, 1] - 1], road[i, 2]);
                    roadList[road[i, 0] - 1][road[i, 1] - 1] = min;
                    roadList[road[i, 1] - 1][road[i, 0] - 1] = min;
                    continue;
                }
                roadList[road[i, 0] - 1][road[i, 1] - 1] = road[i, 2];
                roadList[road[i, 1] - 1][road[i, 0] - 1] = road[i, 2];
            }

            Dijikstra(0, N, K, roadList);

            int count = distance.Where(x => x<=K).Count();

        return count;
    }
    
            public static void Dijikstra(int start, int N, int K, List<List<int>> roadList)
        {
            distance[start] = 0;

            while (true)
            {
                int closet = int.MaxValue;
                int now = -1;
                for (int i = 0; i < N; i++)
                {
                    if (visited[i])
                        continue;
                    if (distance[i] == int.MaxValue || distance[i] >= closet)
                        continue;

                    closet = distance[i];
                    now = i;
                }

                if (now == -1)
                    break;

                visited[now] = true;

                for (int next = 0; next < N; next++)
                {
                    if (roadList[now][next] == -1)
                        continue;
                    if (visited[next])
                        continue;

                    int nextDist = distance[now] + roadList[now][next];

                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                    }
                }
            }
        }
}