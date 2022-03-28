using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string s) {
            int totalCount = 0;
            int zeroCount = 0;

            List<char> charList = s.ToList();
            while (charList.Count > 1)
            {
                totalCount += 1;

                for (int i = 0; i < charList.Count; i++)
                {
                    if (charList[i] == '0')
                    {
                        zeroCount++;
                        charList.RemoveAt(i);
                        i--;
                    }
                }

                int currentLength = charList.Count;
                charList = Convert.ToString(currentLength, 2).ToList();
            }

            int[] answer = new int[] { totalCount, zeroCount };
        return answer;
    }
}