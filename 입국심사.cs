using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public long solution(int n, int[] times) {
            List<int> sortedTime = times.ToList();
            sortedTime.Sort();

            long left = 1;
            long right = (long)sortedTime.Last() * n;

            long answer = 0;

            while (left <= right)
            {
                long mid = (left + right) / 2;
                long count = 0;

                foreach (var time in sortedTime)
                {
                    count += mid / time;
                    if (count >= n)
                        break;
                }

                if (count >= n)
                {
                    answer = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return answer;
    }
}