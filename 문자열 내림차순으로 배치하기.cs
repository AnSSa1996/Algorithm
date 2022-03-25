using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public string solution(string s) {
            StringBuilder sb = new StringBuilder();
            List<char> charList = s.ToList();

            charList = charList.OrderByDescending(x => x).ToList();

            foreach(char c in charList)
            {
                sb.Append(c);
            }

            string answer = sb.ToString();
        return answer;
    }
}