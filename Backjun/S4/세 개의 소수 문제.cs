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

            List<int> sosu = new List<int>();
            Eratos(1010, sosu);

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());

                bool check = false;
                List<int> answer = new List<int>();
                for (int a = 0; sosu[a] < num; a++)
                {
                    for (int b = a; sosu[b] < num; b++)
                    {
                        for (int c = b; sosu[c] < num; c++)
                        {
                            if (num == (sosu[a] + sosu[b] + sosu[c]))
                            {
                                check = true;
                                answer.Add(sosu[a]); answer.Add(sosu[b]); answer.Add(sosu[c]);
                                goto end;
                            }
                        }
                    }
                }
            end:
                if (check) sw.WriteLine($"{string.Join(" ", answer)}");
                else sw.WriteLine(0);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void Eratos(int N, List<int> sosu)
        {
            bool[] check = new bool[N + 1];

            for (int i = 2; i <= N; i++)
            {
                if (check[i] == false)
                {
                    sosu.Add(i);
                    for (int j = i; j <= N; j += i) check[j] = true;
                }
            }
        }
    }
}
