using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    
        public static int minCount = int.MaxValue;
        public static string targetString;
        public static List<string> wordList;
    
    public int solution(string begin, string target, string[] words) {
        
            targetString = target;
            wordList = words.ToList();
            bool[] visited = new bool[words.Length];

            DFS(begin, visited, 0);
        
        if (minCount == int.MaxValue) return 0;
        return minCount;
    }
    
     public static void DFS(string currentWord, bool[] visited, int depth)
        {
            if (depth >= minCount)
                return;
            if (currentWord == targetString)
            {
                minCount = depth;
                return;
            }


            for (int i = 0; i < wordList.Count; i++)
            {
                if (CheckWord(currentWord, wordList[i]) && visited[i] == false)
                {
                    visited[i] = true;
                    DFS(wordList[i], visited, depth + 1);
                    visited[i] = false;
                }
            }
            return;
        }

    public static bool CheckWord(string first, string second)
        {
            int difCount = 0;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i]) difCount++;
                if (difCount > 1) return false;
            }
            if (difCount == 0) return false;
            return true;
        }
}