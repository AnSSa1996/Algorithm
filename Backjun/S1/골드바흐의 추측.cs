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

            bool[] sosu = new bool[10001];
            Eratos(sosu);

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                int mid = num / 2;

                for (int j = 0; j < mid; j++)
                {
                    if (sosu[mid - j] == false && sosu[mid + j] == false)
                    {
                        sw.WriteLine($"{mid - j} {mid + j}");
                        break;
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        static void Eratos(bool[] sosu)
        {
            sosu[0] = false; sosu[1] = false;
            for (int i = 2; i <= 10000; i++)
            {
                if (sosu[i] == true) continue;
                for (int j = i * 2; j <= 10000; j += i)
                    sosu[j] = true;
            }
        }
    }
}
