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

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                List<int> eratos = Eratos(num);
                int[] primes = new int[eratos.Count];

                int index = 0;
                while (true)
                {
                    if (num == 1) break;
                    if (num % eratos[index] == 0) { num /= eratos[index]; primes[index]++; }
                    else { index++; }
                }

                for (int p = 0; p < eratos.Count; p++)
                {
                    if (primes[p] != 0) sw.WriteLine($"{eratos[p]} {primes[p]}");
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static List<int> Eratos(int N)
        {
            List<int> lst = new List<int>();
            bool[] check = new bool[N + 1];

            for (int i = 2; i <= N; i++)
            {
                if (check[i] == false)
                {
                    lst.Add(i);
                    for (int j = i * 2; j <= N; j += i) check[j] = true;
                }
            }
            return lst;
        }
    }
}
