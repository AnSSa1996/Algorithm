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
            List<string> names = new List<string>();

            for (int i = 0; i < N; i++) names.Add(sr.ReadLine());

            char[] c = names.GroupBy(x => x[0]).Where(d => d.Count() >= 5).Select(g => g.Key).ToArray();
            Array.Sort(c);
            if (c.Count() > 0) sw.WriteLine(new string(c));
            else sw.WriteLine("PREDAJA");

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
