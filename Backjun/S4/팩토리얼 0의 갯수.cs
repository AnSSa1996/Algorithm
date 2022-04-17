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
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StreamReader sr = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(sr.ReadLine());

            int cnt = 0;
            for (int num = 1; num <= N; num++)
            {
                int temp = num;
                while (temp % 5 == 0)
                {
                    temp /= 5;
                    cnt++;
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
