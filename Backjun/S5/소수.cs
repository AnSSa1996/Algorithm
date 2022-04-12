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

            int start = int.Parse(sr.ReadLine());
            int end = int.Parse(sr.ReadLine());

            List<int> sosu = new List<int>();

            for (int num = start; num <= end; num++) if (check(num)) sosu.Add(num);

            if (sosu.Count > 0)
            {
                sw.WriteLine($"{sosu.Sum()}");
                sw.WriteLine($"{sosu.Min()}");
            }
            else
            {
                sw.WriteLine(-1);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static bool check(int num)
        {
            if (num == 0 || num == 1) return false;
            for (int i = 2; i * i <= num; i++) if (num % i == 0) return false;
            return true;
        }
    }
}
