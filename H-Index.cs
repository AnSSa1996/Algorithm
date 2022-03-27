using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] citations) {
            List<int> citationsList = citations.ToList();
            citationsList.Sort();
            citationsList.Reverse();
            int Hidex = 0;
            for (int i = 0; i < citationsList.Count; i++)
            {
                if ((i + 1) <= citationsList[i])
                    Hidex++;
            }
        return Hidex;
    }
}