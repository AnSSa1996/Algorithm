using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int n, int[,] wires) {
       
            List<List<int>> edges = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                edges.Add(new List<int>());
            }

            for (int i = 0; i < wires.GetLength(0); i++)
            {
                edges[wires[i, 0] - 1].Add(wires[i, 1] - 1);
                edges[wires[i, 1] - 1].Add(wires[i, 0] - 1);
            }

            int minNum = int.MaxValue;

            for (int i = 0; i < wires.GetLength(0); i++)
            {
                edges[wires[i, 0] - 1].Remove(wires[i, 1] - 1);
                edges[wires[i, 1] - 1].Remove(wires[i, 0] - 1);

                // 간선 제거
                bool[] visited = new bool[n];

                int Count = 1;

                Queue<int> q = new Queue<int>();

                for (int qI = 0; qI < n; qI++)
                {
                    if (edges[qI].Count == 0)
                        continue;
                    q.Enqueue(qI);
                    visited[qI] = true;
                    break;
                }

                // BFS 구현.

                while (q.Count > 0)
                {
                    int currentNode = q.Dequeue();

                    foreach (var nextNode in edges[currentNode])
                    {
                        if (visited[nextNode])
                            continue;

                        Count += 1;
                        visited[nextNode] = true;
                        q.Enqueue(nextNode);
                    }
                }

                int leftNum = n - Count;
                int rightNum = Count;
                minNum = Math.Min(minNum, Math.Abs(leftNum - rightNum));

                edges[wires[i, 0] - 1].Add(wires[i, 1] - 1);
                edges[wires[i, 1] - 1].Add(wires[i, 0] - 1);
            }
            int result = minNum;
        return result;
    }
}