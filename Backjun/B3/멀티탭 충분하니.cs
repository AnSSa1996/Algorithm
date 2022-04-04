using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int students = inputs[0];
            int N = inputs[1];
            int[] multiTab = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int totalCount = 0;
            for (int i = 0; i < N; i++)
            {
                totalCount += (multiTab[i] + 1) / 2;
            }

            if (students <= totalCount) sw.WriteLine("YES");
            else sw.WriteLine("NO");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
