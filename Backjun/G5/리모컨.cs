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
            int M = int.Parse(sr.ReadLine());
            List<char> wrongNums = new List<char>();
            if (M > 0) { wrongNums = Array.ConvertAll(sr.ReadLine().Split(), char.Parse).ToList(); }

            int result = Math.Abs(100 - N);
            for (int count = 0; count <= 1000001; count++)
            {
                bool check = true;
                foreach (var c in count.ToString())
                {
                    if (wrongNums.Contains(c))
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    result = Math.Min(Math.Abs(N - count) + count.ToString().Length, result);
                }
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}