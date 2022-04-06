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

            int N = (int.Parse(sr.ReadLine()));

            for (int i = 0; i < N; i++)
            {
                int num = (int.Parse(sr.ReadLine()));
                int calNum = num + int.Parse(new string(num.ToString().Reverse().ToArray()));

                if (calNum.ToString() == new string(calNum.ToString().Reverse().ToArray()))
                    sw.WriteLine("YES");
                else sw.WriteLine("NO");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}