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
            int S = int.Parse(sr.ReadLine());

            string s = sr.ReadLine();

            int count = 0;
            int total = 0;

            for (int i = 1; i < S - 1; i++)
            {
                if (s[i - 1] == 'I' && s[i] == 'O' && s[i + 1] == 'I')
                {
                    count++;
                    if (count == N) { count--; total++; }
                    i++;
                }
                else { count = 0; }
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}