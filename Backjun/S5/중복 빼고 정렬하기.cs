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

            sr.ReadLine();
            List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            var sortedLst = lst.Distinct().OrderBy(x => x);

            sw.WriteLine(string.Join(" ", sortedLst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
