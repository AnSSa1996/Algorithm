using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            List<int> A = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            List<int> B = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            List<int> C = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            int A_WorkingSecond = (A[3] * 3600 + A[4] * 60 + A[5]) -
                (A[0] * 3600 + A[1] * 60 + A[2]);
            int B_WorkingSecond = (B[3] * 3600 + B[4] * 60 + B[5]) -
                (B[0] * 3600 + B[1] * 60 + B[2]);
            int C_WorkingSecond = (C[3] * 3600 + C[4] * 60 + C[5]) -
                (C[0] * 3600 + C[1] * 60 + C[2]);

            int Ahour = A_WorkingSecond / 3600;
            A_WorkingSecond %= 3600;
            int AMin = A_WorkingSecond / 60;
            A_WorkingSecond %= 60;
            int ASecond = A_WorkingSecond;

            int Bhour = B_WorkingSecond / 3600;
            B_WorkingSecond %= 3600;
            int BMin = B_WorkingSecond / 60;
            B_WorkingSecond %= 60;
            int BSecond = B_WorkingSecond;

            int Chour = C_WorkingSecond / 3600;
            C_WorkingSecond %= 3600;
            int CMin = C_WorkingSecond / 60;
            C_WorkingSecond %= 60;
            int CSecond = C_WorkingSecond;

            sw.WriteLine($"{Ahour} {AMin} {ASecond}");
            sw.WriteLine($"{Bhour} {BMin} {BSecond}");
            sw.WriteLine($"{Chour} {CMin} {CSecond}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
