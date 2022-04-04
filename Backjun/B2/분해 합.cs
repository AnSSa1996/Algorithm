using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                int num = i + i.ToString().ToArray().Sum(x => x - '0');
                if (num == N)
                {
                    sw.WriteLine(i);
                    break;
                }
                else if (i == N)
                {
                    sw.WriteLine(0);
                    break;
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
