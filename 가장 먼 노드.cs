using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    
    public static bool[] visited;
    public static int[] distanceArray;
    public static List<List<int>> edgesList = new List<List<int>>();
    
    public int solution(int n, int[,] edge) {
        
            visited = new bool[n];
            distanceArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                edgesList.Add(new List<int>());
            }

            for (int i = 0; i < edge.GetLength(0); i++)
            {
                edgesList[edge[i, 0] - 1].Add(edge[i, 1] - 1);
                edgesList[edge[i, 1] - 1].Add(edge[i, 0] - 1);
            }
            SanhunBFS();
            List<int> calculatedDistance = distanceArray.ToList();

            int answer = calculatedDistance.Where(x => x == calculatedDistance.Max()).Count();
        
        return answer;
    }
    
    public static void SanhunBFS()
        {
            Queue<NodeQ> q = new Queue<NodeQ>();
            q.Enqueue(new NodeQ(0, 0));
            visited[0] = true;
            while (q.Count > 0)
            {
                NodeQ node = q.Dequeue();
                int currentDepth = node.Depth;
                int pos = node.CurrentPos;

                foreach(int nextNode in edgesList[pos])
                {
                    if (visited[nextNode])
                        continue;
                    visited[nextNode] = true;
                    distanceArray[nextNode] = currentDepth + 1;
                    q.Enqueue(new NodeQ(currentDepth + 1, nextNode));
                }
            }
        }
}

public class NodeQ
    {
        public int Depth;
        public int CurrentPos;

        public NodeQ(int depth, int currentPos)
        {
            Depth = depth; CurrentPos = currentPos;
        }
    }