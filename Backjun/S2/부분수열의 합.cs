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
            int N = inputs[0] - 1; int answer = inputs[1];
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int cnt = 0;

            DFS(0, 0);

            sw.WriteLine(cnt);
            void DFS(int index, int sum)
            {
                if (index > N) return;
                sum += nums[index];
                if (sum == answer) cnt++;
                DFS(index + 1, sum);
                DFS(index + 1, sum - nums[index]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}