using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            List<int> sosu = new List<int>();

            Eratos(sosu, N);
            sw.WriteLine(sosu[N - 1]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void Eratos(List<int> sosu, int N)
        {
            int cnt = 0;
            bool[] check = new bool[10000001];
            for (int i = 2; i <= 10000000; i++)
            {
                if (check[i] == false)
                {
                    cnt++;
                    sosu.Add(i);
                    if (N == cnt) return;
                    for (int j = 2 * i; j <= 10000000; j += i) check[j] = true;
                }
            }
        }
    }
}
