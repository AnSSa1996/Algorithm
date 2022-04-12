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

            int result = 4;
            for (int i = 4; i <= N; i++) if (Check(i)) result = i;

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static bool Check(int num)
        {
            while (true)
            {
                if (num % 10 == 4 || num % 10 == 7) num /= 10;
                else return false;

                if (num == 0) break;
            }
            return true;
        }
    }
}