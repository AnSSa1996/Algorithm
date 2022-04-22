using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0];
            int answer = inputs[1];

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int cnt = 0;

            int start = 0; int end = 0;

            while (end < N)
            {
                int sum = 0;
                for (int i = start; i <= end; i++) sum += nums[i];

                if (sum == answer) cnt++;
                if (sum < answer) end++;
                else start++;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}