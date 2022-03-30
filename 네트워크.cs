using System;
using System.Collections.Generic;

public class Solution {
    
        public static List<List<int>> nodeList = new List<List<int>>();
        public static bool[] visited;
    
    public int solution(int n, int[,] computers) {
            
            visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                nodeList.Add(new List<int>());
            }

            for (int i = 0; i < n; i++)
            {
                List<int> tempList = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        continue;
                    if (computers[i, j] != 0)
                        tempList.Add(j);
                }
                nodeList[i] = tempList;
            }

            int answer = BFS(n);
        return answer;
    }
    public static int BFS(int n)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (visited[i] == true)
                    continue;
                visited[i] = true;
                count++;
                Queue<int> tempQ = new Queue<int>();
                tempQ.Enqueue(i);

                while (tempQ.Count > 0)
                {
                    int currentNode = tempQ.Dequeue();
                    visited[currentNode] = true;
                    List<int> nextNode = nodeList[currentNode];
                    foreach (int nextN in nextNode)
                    {
                        if (visited[nextN] == true)
                            continue;
                        tempQ.Enqueue(nextN);
                    }
                }
            }
            return count;
        }
}


        