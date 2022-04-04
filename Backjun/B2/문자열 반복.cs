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

            for (int i = 0; i < N; i++)
            {
                string[] inputs = sr.ReadLine().Split();
                int r = int.Parse(inputs[0]);
                string str = inputs[1];

                StringBuilder sb = new StringBuilder();
                foreach (var c in str)
                {
                    sb.Append(string.Concat(Enumerable.Repeat(c, r)));
                }
                sw.WriteLine(sb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
