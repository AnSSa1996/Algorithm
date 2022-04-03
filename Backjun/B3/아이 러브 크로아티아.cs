using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int currentN = int.Parse(sr.ReadLine());
            int N = int.Parse(sr.ReadLine());
            int totalTime = 210;
            for (int i = 0; i < N; i++)
            {
                var str = sr.ReadLine().Split();
                int time = int.Parse(str[0]);
                string ans = str[1];
                totalTime -= time;
                if (totalTime <= 0)
                {
                    sw.WriteLine(currentN);
                    break;
                }
                if (ans == "T") currentN = (currentN + 1) % 9 == 0 ? 1 : currentN + 1;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
