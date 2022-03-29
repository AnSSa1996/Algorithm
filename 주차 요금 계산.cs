using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] fees, string[] records) {
          Dictionary<string, List<int>> recordDict = new Dictionary<string, List<int>>();

            int baseTime = fees[0];
            int baseFee = fees[1];
            int overTime = fees[2];
            int overFee = fees[3];

            for (int i = 0; i < records.GetLength(0); i++)
            {
                string[] st = records[i].Split(' ');
                string timeString = st[0];
                string carNumberString = st[1];
                string inoutString = st[2];

                int currentMinute = MinuteConvert(timeString);

                if (!recordDict.ContainsKey(carNumberString))
                {
                    int time = 1439 - currentMinute;
                    recordDict.Add(carNumberString, new List<int>() { time });
                    continue;
                }

                if (inoutString == "OUT")
                {
                    int lastIndex = recordDict[carNumberString].Count - 1;
                    int time = recordDict[carNumberString].Last();
                    int calcuatleTime = currentMinute - 1439 + time;
                    recordDict[carNumberString][lastIndex] = calcuatleTime;
                }
                else
                {
                    int time = 1439 - currentMinute;
                    recordDict[carNumberString].Add(time);
                }
            }

            List<int> answerList = new List<int>();
            var recordOrdered = recordDict.OrderBy(x => x.Key);

            foreach (var items in recordOrdered)
            {
                int resultFee = 0;
                int TotalTime = items.Value.Sum();

                if (TotalTime <= baseTime)
                {
                    resultFee += baseFee;
                }
                else
                {
                    TotalTime -= baseTime;
                    resultFee += baseFee;

                    int quotient = (TotalTime + overTime - 1) / overTime;
                    resultFee += quotient * overFee;
                }

                answerList.Add(resultFee);
            }

            int[] answer = answerList.ToArray();
        return answer;
    }
    
     public static int MinuteConvert(string s)
        {
            string[] st = s.Split(':');

            int hour = int.Parse(st[0]);
            int minute = int.Parse(st[1]);

            return hour * 60 + minute;
        }
}