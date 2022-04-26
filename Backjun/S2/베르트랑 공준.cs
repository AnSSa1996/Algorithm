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

            bool[] sosu = new bool[300001];
            sosu[0] = true; sosu[1] = true;

            Eratos(sosu);

            while (true)
            {
                int n = int.Parse(sr.ReadLine());
                if (n == 0) break;

                int cnt = 0;
                for (int i = n + 1; i <= 2 * n; i++)
                {
                    if (sosu[i] == false) cnt++;
                }

                sw.WriteLine(cnt);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void Eratos(bool[] sosu)
        {
            for (int i = 2; i * i <= 300000; i++)
            {
                if (sosu[i] == false)
                {
                    for (int j = (i * 2); j <= 300000; j += i)
                    {
                        sosu[j] = true;
                    }
                }
            }
        }
    }
}