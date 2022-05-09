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

            string str = sr.ReadLine();
            int N = str.Length;

            List<string> lst = new List<string>();

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= (N - i); j++)
                {
                    string sub = str.Substring(j, i);
                    lst.Add(sub);
                }
            }

            sw.WriteLine(lst.Distinct().ToList().Count());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
