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

            string[] strs = sr.ReadLine().Split();

            string A = strs[0];
            string B = strs[1];

            int dif = B.Length - A.Length;

            int difCount = 51;
            for (int i = 0; i <= dif; i++)
            {
                int cnt = 0;
                for (int j = i; j < A.Length + i; j++)
                {
                    if (A[j - i] != B[j])
                    {
                        cnt++;
                    }
                }
                difCount = Math.Min(difCount, cnt);
            }

            sw.WriteLine(difCount);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
