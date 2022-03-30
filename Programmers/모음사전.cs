using System;

public class Solution {
    public int solution(string word) {
            int[] orderValue = { 781, 156, 31, 6, 1 };

            int Count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                int charInt = WhatIs(word[i]);
                if (charInt != 1)
                {
                    Count += (charInt - 1) * orderValue[i];
                }
                Count++;
            }
        return Count;
    }
    
    
        public static int WhatIs(char Character)
        {
            switch (Character)
            {
                case 'A':
                    return 1;
                case 'E':
                    return 2;
                case 'I':
                    return 3;
                case 'O':
                    return 4;
                default:
                    return 5;
            }
        }
}