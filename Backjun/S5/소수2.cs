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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int A = inputs[0];
            int B = inputs[1];
            int div = inputs[2];

            int result = Division(A, B, div);

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int Division(int A, int B, int div)
        {
            int quo = 0;
            while (div > 0)
            {
                if (A < B)
                {
                    A *= 10;
                    div--;
                }
                quo = A / B;
                A %= B;
            }

            return quo;
        }
    }
}
