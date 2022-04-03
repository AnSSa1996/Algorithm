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
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int a = nums[0];
                int b = nums[1];

                int result = 0;

                if (a == 0) result += 0;
                else if (a <= 1) result += 5000000;
                else if (a <= 3) result += 3000000;
                else if (a <= 6) result += 2000000;
                else if (a <= 10) result += 500000;
                else if (a <= 15) result += 300000;
                else if (a <= 21) result += 100000;

                if (b == 0) result += 0;
                else if (b <= 1) result += 5120000;
                else if (b <= 3) result += 2560000;
                else if (b <= 7) result += 1280000;
                else if (b <= 15) result += 640000;
                else if (b <= 31) result += 320000;

                sw.WriteLine(result);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
