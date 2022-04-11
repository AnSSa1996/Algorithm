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

            sr.ReadLine();
            string str = sr.ReadLine();

            int S_count = str.Count(x => x == 'S');
            int L_count = str.Count(x => x == 'L') / 2;

            int total_Cup = S_count + L_count + 1;
            int total_P = S_count + L_count * 2;

            int result = Math.Min(total_P, total_Cup);
            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}