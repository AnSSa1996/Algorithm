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

            for (int i = 1; i <= N; i++)
            {
                string[] str = sr.ReadLine().Split('-');
                string name = str[0];

                int nameNum = (name[0] - 'A') * 26 * 26 + (name[1] - 'A') * 26 + (name[2] - 'A');
                int num = int.Parse(str[1]);

                if (Math.Abs(nameNum - num) <= 100) sw.WriteLine("nice");
                else sw.WriteLine("not nice");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}