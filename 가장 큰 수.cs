using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public string solution(int[] numbers)
    {
            StringBuilder sb = new StringBuilder();
            string answer;

            Array.Sort(numbers, (x, y) =>
            {
                string XY = x.ToString() + y.ToString();
                string YX = y.ToString() + x.ToString();
                return YX.CompareTo(XY);
            });
            if (numbers.Where(x => x == 0).Count() == numbers.Length) answer = "0";
            else
            {
                foreach(var n in numbers)
                {
                    sb.Append(n);
                }
                answer = sb.ToString();
            }
        return answer;
    }
}