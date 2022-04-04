using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int time = int.Parse(sr.ReadLine());
                int lateTime = 0;
                while (true)
                {
                    if ((lateTime + 1) * (lateTime + 1) + (lateTime + 1) <= time) lateTime++;
                    else break;
                }
                sw.WriteLine(lateTime);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
