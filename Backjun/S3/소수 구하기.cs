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
            int left = inputs[0];
            int right = inputs[1];

            bool[] sosu = new bool[right + 3];
            sosu[0] = true; sosu[1] = true;

            Eratos(sosu, right);

            for (int i = left; i <= right; i++) if (sosu[i] == false) sw.WriteLine(i);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void Eratos(bool[] sosu, int N)
        {
            for (int i = 2; i * i <= N; i++)
            {
                if (sosu[i] == false)
                {
                    for (int j = i * 2; j <= N; j += i) sosu[j] = true;
                }
            }
        }
    }
}