using System;

public class Solution {
    
        public static bool[] visited;
        public static int length = 0;
        public static int maxNum = 0;
    
    
    public int solution(int k, int[,] dungeons) {
        
            length = dungeons.GetLength(0);
            visited = new bool[length];
            DFS(0, dungeons, k, 0);
        
        return maxNum;
    }
    
     public static void DFS(int Prodo, int[,] dungeons, int k, int depth)
        {
            for (int i = 0; i < length; i++)
            {
                if (visited[i] == true)
                    continue;
                if (Prodo + dungeons[i, 0] > k)
                {
                    continue;
                }

                Prodo = Prodo + dungeons[i, 1];
                depth = depth + 1;
                visited[i] = true;
                maxNum = Math.Max(maxNum, depth);

                DFS(Prodo, dungeons, k, depth);

                Prodo = Prodo - dungeons[i, 1];
                depth = depth - 1;
                visited[i] = false;
            }
        }
}