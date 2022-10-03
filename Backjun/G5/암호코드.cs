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

            string str = sr.ReadLine();
            int end = str.Length;
            int[] dp = new int[end + 2];
            bool check = true;
            dp[0] = 1;

            for (int index = 0; index < end; index++)
            {
                var last = false;
                int first = str[index] - '0';
                if (first == 0)
                {
                    check = false;
                    break;
                }
                if (index == end - 1)
                {
                    dp[index + 1] += dp[index] % 1000000;
                    continue;
                }
                int second = str[index + 1] - '0';
                if (second == 0)
                {
                    if (first == 1 || first == 2)
                    {
                        dp[index + 2] += dp[index] % 1000000;
                        index++;
                        continue;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
                if (first * 10 + second <= 26) dp[index + 2] += dp[index] % 1000000;
                dp[index + 1] += dp[index] % 1000000;
            }

            if (check) sw.WriteLine(dp[end] % 1000000);
            else sw.WriteLine(0);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}