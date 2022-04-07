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
            List<char> A = sr.ReadLine().ToList();
            List<char> B = sr.ReadLine().ToList();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < A.Count(); j++)
                {
                    if (A[j] == '1') A[j] = '0';
                    else A[j] = '1';
                }
            }

            if (Enumerable.SequenceEqual(A, B)) sw.WriteLine("Deletion succeeded");
            else sw.WriteLine("Deletion failed");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}