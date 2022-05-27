using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
                string str = sr.ReadLine();
                if (str.Contains("=")) { sw.WriteLine("skipped"); continue; }
                else
                {
                    int[] nums = Array.ConvertAll(str.Split('+'), int.Parse);
                    sw.WriteLine(nums.Sum());
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
