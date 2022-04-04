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

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int repeat = int.Parse(sr.ReadLine());
                int p1 = 0;
                int p2 = 0;

                for (int j = 0; j < repeat; j++)
                {
                    string[] str = sr.ReadLine().Split();
                    var s1 = str[0];
                    var s2 = str[1];

                    if (s1 == s2) continue;
                    else if ((s1 == "P" && s2 == "R") || (s1 == "R" && s2 == "S") || (s1 == "S" && s2 == "P")) p1++;
                    else p2++;
                }
                if (p1 > p2) sw.WriteLine("Player 1");
                else if (p1 < p2) sw.WriteLine("Player 2");
                else sw.WriteLine("TIE");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
