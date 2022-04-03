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
                sr.ReadLine();
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                sw.WriteLine(nums.Sum());
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
