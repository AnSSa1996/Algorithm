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

            long N = long.Parse(sr.ReadLine());

            long first = long.Parse(sr.ReadLine());
            long second = long.Parse(sr.ReadLine());

            bool isCheck = true;
            long dif = second - first;
            long currentNum = second;
            long nextNum = 0;
            for (long i = 2; i < N; i++)
            {
                nextNum = long.Parse(sr.ReadLine());
                if (nextNum - currentNum == dif)
                {
                    currentNum = nextNum;
                    continue;
                }
                else
                {
                    isCheck = false;
                }
            }

            if (isCheck) sw.WriteLine(nextNum + dif);
            else sw.WriteLine(nextNum * (second / first));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}