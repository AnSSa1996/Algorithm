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

            bool[] sosu = new bool[1100001];
            Eratos(sosu);

            int N = int.Parse(sr.ReadLine());
            int result = -1;
            for (int i = N; i <= 1100001; i++)
            {
                if (i.ToString() == new string(i.ToString().Reverse().ToArray()))
                {
                    if (sosu[i] == false)
                    {
                        result = i; break;
                    }
                }
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void Eratos(bool[] sosu)
        {
            sosu[0] = true;
            sosu[1] = true;

            for (int i = 2; i <= 1100000; i++)
            {
                if (sosu[i] == false)
                {
                    for (int j = i * 2; j <= 1100000; j += i)
                    {
                        sosu[j] = true;
                    }
                }
            }
        }
    }
}