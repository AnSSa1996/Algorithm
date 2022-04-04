using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            var N = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 1; i <= N; i++)
            {
                if (check(i)) count++;
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static bool check(int n)
        {
            int sum = 0;
            int num = n;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return num % sum == 0;
        }
    }
}
