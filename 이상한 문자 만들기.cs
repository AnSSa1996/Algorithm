using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public string solution(string s) {
            StringBuilder sb = new StringBuilder();
            List<string> stringList = s.Split(' ').ToList();

            foreach (string forString in stringList)
            {
                char c;
                for (int i = 0; i < forString.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        c = Char.ToUpper(forString[i]);
                    }
                    else
                    {
                        c = Char.ToLower(forString[i]);
                    }
                    sb.Append(c);
                }
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            string answer = sb.ToString();
        return answer;
    }
}