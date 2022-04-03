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
                int carCost = int.Parse(sr.ReadLine());
                int optionN = int.Parse(sr.ReadLine());
                for (int j = 0; j < optionN; j++)
                {
                    int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    carCost += nums[0] * nums[1];
                }
                sw.WriteLine(carCost);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
