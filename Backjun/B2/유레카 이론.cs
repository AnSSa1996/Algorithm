using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {

        public static List<int> T_Dp = new List<int>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            madeDp();

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                bool isCan = false;
                int num = int.Parse(sr.ReadLine());
                for (int a = 0; a < T_Dp.Count(); a++)
                {
                    for (int b = 0; b < T_Dp.Count(); b++)
                    {
                        for (int c = 0; c < T_Dp.Count(); c++)
                        {
                            int sum = T_Dp[a] + T_Dp[b] + T_Dp[c];
                            if (T_Dp[a] >= num) goto end;
                            if (sum == num)
                            {
                                isCan = true;
                                goto end;
                            }
                        }
                    }
                }
            end:
                if (isCan) sw.WriteLine(1);
                else sw.WriteLine(0);
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        public static void madeDp()
        {
            for (int i = 1; (i * i + i) / 2 <= 1000; i++)
            {
                T_Dp.Add((i * i + i) / 2);
            }
        }
    }
}