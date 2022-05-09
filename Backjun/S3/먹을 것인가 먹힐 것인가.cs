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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int aCount = inputs[0]; int bCount = inputs[1];

                int[] A = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int[] B = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                Array.Sort(A); A = A.Reverse().ToArray();
                Array.Sort(B); B = B.Reverse().ToArray();

                int A_Start = 0; int B_Start = 0;

                int cnt = 0;
                while (B_Start < bCount && A_Start < aCount)
                {
                    if (A[A_Start] > B[B_Start])
                    {
                        cnt += bCount - B_Start;
                        A_Start++;
                    }
                    else { B_Start++; }
                }

                sw.WriteLine(cnt);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
