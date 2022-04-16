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
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int N = int.Parse(sr.ReadLine());
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            for (int i = 0; i < N; i++)
            {
                if (nums.Contains(inputs[i])) sw.WriteLine(1);
                else sw.WriteLine(0);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
