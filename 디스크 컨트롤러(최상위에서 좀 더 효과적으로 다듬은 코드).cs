using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[,] jobs) {
            int answer = 0;
            List<Job> lstJobs = new List<Job>();
            for (int i = 0; i < jobs.GetLength(0); i++)
            {
                lstJobs.Add(new Job(jobs[i, 0], jobs[i, 1]));
            }

            lstJobs = lstJobs.OrderBy(x => x.Start).ToList();

            for (int i = 0; ; i++)
            {
                if (lstJobs.Count() == 0) break;
                var nextJob = lstJobs.Where(x => x.Start <= i).OrderBy(x => x.Len).ToList();
                if (nextJob.Count() == 0)
                {
                    i = lstJobs[0].Start - 1;
                    continue;
                }
                // 실행시간 합산
                answer += nextJob[0].Start < i ? i - nextJob[0].Start + nextJob[0].Len : nextJob[0].Len;
                i = i + nextJob[0].Len - 1;
                lstJobs.Remove(nextJob[0] as Job);
            }

            return answer / jobs.GetLength(0);
    }

    public class Job
    {
        public int Start { set; get; }
        public int Len { set; get; }

        public Job(int start, int len)
        {
            this.Start = start;
            this.Len = len;
        }
    }    
}