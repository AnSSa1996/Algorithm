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

            List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            for (int i = 1; i <= 1000000; i++)
            {
                int cnt = 0;
                foreach (int num in lst) if (i % num == 0) cnt++;
                if (cnt >= 3)
                {
                    sw.WriteLine(i);
                    break;
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}