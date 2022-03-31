using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string[] operations) {
            
            List<int> orderList = new List<int>();

            for (int i = 0; i < operations.GetLength(0); i++)
            {
                string[] str = operations[i].Split(' ');
                string firstString = str[0];
                int nums = int.Parse(str[1]);

                if (firstString == "I")
                {
                    orderList.Add(nums);
                }
                else if (firstString == "D" && nums == 1 && orderList.Count>0)
                {
                    orderList = orderList.OrderByDescending(x => x).ToList();
                    orderList.RemoveAt(0);
                }
                else if (firstString == "D" && nums == -1 && orderList.Count > 0)
                {
                    orderList = orderList.OrderBy(x => x).ToList();
                    orderList.RemoveAt(0);
                }
            }

            int[] answer = new int[] { 0, 0 };
            if (orderList.Count > 0)
            {
                answer[0] = orderList.Max();
                answer[1] = orderList.Min();
            }
        return answer;
    }
}