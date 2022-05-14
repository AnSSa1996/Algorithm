using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] op = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            List<long> results = new List<long>();
            DFS(nums[0], 1);

            void DFS(int result, int index)
            {
                if (index == N) { results.Add(result); return; }

                for (int i = 0; i < 4; i++)
                {
                    if (op[i] < 1) continue;
                    op[i]--;
                    DFS(Cal(result, index, i), index + 1);
                    op[i]++;
                }
            }

            int Cal(int result, int index, int i)
            {
                switch (i)
                {
                    case 0:
                        result += nums[index];
                        break;
                    case 1:
                        result -= nums[index];
                        break;
                    case 2:
                        result *= nums[index];
                        break;
                    case 3:
                        result /= nums[index];
                        break;
                }
                return result;
            }

            sw.WriteLine(results.Max());
            sw.WriteLine(results.Min());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}