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
            string str = sr.ReadLine();
            int bonus = 0;
            int total = 0;

            for (int i = 1; i <= N; i++)
            {
                if (str[i - 1] == 'O')
                {
                    total += i + bonus;
                    bonus++;
                }
                else bonus = 0;
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}