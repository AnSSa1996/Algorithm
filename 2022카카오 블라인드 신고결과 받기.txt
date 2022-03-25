using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] id_list, string[] report, int k) {

            Dictionary<string, List<string>> personReoprtList = new Dictionary<string, List<string>>();
            Dictionary<string, int> personRemoveList = new Dictionary<string, int>();

            foreach (string name in id_list)
            {
                personRemoveList.Add(name, 0);
                personReoprtList.Add(name, new List<string>());
            }

            foreach (string reportName in report)
            {
                string[] names = reportName.Split(' ');
                string firstName = names[0];
                string lastName = names[1];
                if (personReoprtList[firstName].Contains(lastName) == false)
                {
                    personReoprtList[firstName].Add(lastName);
                    personRemoveList[lastName] += 1;
                }
            }

            List<int> answerList = new List<int>();

            foreach (string name in id_list)
            {
                int ans = 0;
                foreach (string dictName in personReoprtList[name])
                {
                    if (personRemoveList[dictName] >= k)
                    {
                        ans += 1;
                    }
                }
                answerList.Add(ans);
            }

            int[] answer = answerList.ToArray();
            
        return answer;
    }
}