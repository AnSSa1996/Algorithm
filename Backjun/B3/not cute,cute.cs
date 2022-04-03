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
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++) nums.Add(int.Parse(sr.ReadLine()));

            string result = "Junhee is not cute!";
            if (nums.Sum() > N / 2) result = "Junhee is cute!";

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
