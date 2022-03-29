using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Solution {
    public string solution(string s) {
                   List<string> stringList = s.Split(' ').ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var str in stringList)
            {
                if (str.Length < 1)
                {
                    sb.Append(" ");
                    continue;
                }
                StringBuilder tempSb = new StringBuilder();
                string tempString = str;
                tempSb.Append(Char.ToUpper(tempString[0]));
                tempString = tempString.ToLower();
                if (tempString.Length > 1)
                    tempSb.Append(tempString.Substring(1));
                sb.Append($"{tempSb.ToString()} ");
            }
            sb.Remove(sb.Length - 1, 1);
            string answer = sb.ToString();
        return answer;
    }
}