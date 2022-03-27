using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[,] clothes) {
            Dictionary<string, List<string>> clothesDict = new Dictionary<string, List<string>>();
            int clothesCount = clothes.GetLength(0);

            for (int i = 0; i < clothesCount; i++)
            {
                if (!(clothesDict.ContainsKey(clothes[i, 1])))
                {
                    clothesDict.Add(clothes[i, 1], new List<string> { clothes[i, 0] });
                }
                else
                {
                    clothesDict[clothes[i, 1]].Add(clothes[i, 0]);
                }
            }

            int count = 1;

            foreach(var items in clothesDict)
            {
                int length = items.Value.Count;
                count = count * (length + 1);
            }

            int answer = count - 1;
        return answer;
    }
}