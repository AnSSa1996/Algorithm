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

            sr.ReadLine();
            List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            int N = int.Parse(sr.ReadLine());

            int count = lst.Where(x => x == N).Count();

            sw.WriteLine(count);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}