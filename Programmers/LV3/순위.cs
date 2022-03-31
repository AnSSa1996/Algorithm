using System;

public class Solution {
    public int solution(int n, int[,] results) {
            
            bool[,] resultsBool = new bool[n + 1, n + 1];

            for (int i = 0; i < results.GetLength(0); i++)
            {
                resultsBool[results[i, 0], results[i, 1]] = true;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 1; k <= n; k++)
                    {
                        if (resultsBool[j,i] && resultsBool[i,k])
                        {
                            resultsBool[j,k] = true;
                        }
                    }
                }
            }

            int answer = 0;
            for (int i = 1; i <= n; i++)
            {
                int count = 0;
                for (int j = 1; j <= n; j++)
                {
                    if (resultsBool[i,j] || resultsBool[j,i])
                        count++;
                }
                if (count == n - 1)
                    answer++;
            }
        return answer;
    }
}