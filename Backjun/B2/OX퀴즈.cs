using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
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
                string str = sr.ReadLine();
                int sum = 0;
                int temp = 0;
                foreach (var c in str)
                {
                    if (c == 'O')
                    {
                        temp += 1;
                        sum += temp;
                    }
                    else
                    {
                        temp = 0;
                    }
                }
                sw.WriteLine(sum);
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
