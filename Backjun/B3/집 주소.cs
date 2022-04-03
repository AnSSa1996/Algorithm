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

            while (true)
            {
                int N = int.Parse(sr.ReadLine());
                if (N == 0) break;
                int total = 2;
                string nString = N.ToString();
                total += nString.Length - 1;
                for (int i = 0; i < nString.Length; i++)
                {
                    if (nString[i] == '0') total += 4;
                    else if (nString[i] == '1') total += 2;
                    else total += 3;
                }
                sw.WriteLine(total);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
