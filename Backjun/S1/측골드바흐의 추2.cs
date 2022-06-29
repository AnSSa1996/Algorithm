using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJun
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            bool[] check = new bool[2000001];

            check[0] = true; check[1] = true;
            for (int i = 2; i < 2000000; i++)
            {
                if (check[i] == false)
                {
                    for (int j = i * 2; j < 2000000; j += i) { check[j] = true; }
                }
            }

            while (true)
            {
                int num = int.Parse(sr.ReadLine());
                if (num == 0) break;

                int x = num / 2;
                int y = num / 2;

                if (x % 2 == 0) { x -= 1; y += 1; }

                int answerX = 0;
                int answerY = 0;
                while (x > 0)
                {
                    if (check[x] == false && check[y] == false)
                    {
                        answerX = x;
                        answerY = y;
                    }
                    x -= 2;
                    y += 2;
                }
                sw.WriteLine($"{num} = {answerX} + {answerY}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
