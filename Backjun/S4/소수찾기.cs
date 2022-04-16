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

            bool[] sosu = new bool[1001];
            sosu[1] = true;
            Eratos(sosu);
            int N = int.Parse(sr.ReadLine());
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int cnt = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                if (sosu[inputs[i]] == false) cnt++;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void Eratos(bool[] sosu)
        {
            for (int i = 2; i * i <= 1000; i++)
            {
                if (sosu[i] == false)
                {
                    for (int j = i * 2; j <= 1000; j += i) sosu[j] = true;
                }
            }
        }
    }
}
