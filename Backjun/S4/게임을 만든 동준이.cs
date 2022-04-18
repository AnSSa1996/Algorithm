using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());

            List<int> lst = new List<int>();
            for (int i = 0; i < N; i++) lst.Add(int.Parse(sr.ReadLine()));

            lst.Reverse();

            int currentN = lst[0];
            int total = 0;
            for (int i = 1; i < N; i++)
            {
                int temp = lst[i];
                if (currentN <= temp)
                {
                    total += temp - currentN + 1;
                    currentN -= 1;
                }
                else currentN = temp;
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
