using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[,] sizes) {
        
            List<int> x = new List<int>();
            List<int> y = new List<int>();
            for (int i = 0; i < sizes.GetLength(0); i++)
            {
                if (sizes[i, 0] > sizes[i, 1])
                {
                    x.Add(sizes[i, 0]);
                    y.Add(sizes[i, 1]);
                }
                else
                {
                    x.Add(sizes[i, 1]);
                    y.Add(sizes[i, 0]);
                }
            }

            int maxX = x.Max();
            int maxY = y.Max();

            int answer = maxX * maxY;
        return answer;
    }
}