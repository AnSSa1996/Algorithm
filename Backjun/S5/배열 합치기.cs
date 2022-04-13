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

            List<int> lst = new List<int>();
            int[] first = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] second = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            lst.AddRange(first.ToList());
            lst.AddRange(second.ToList());

            lst.Sort();

            sw.WriteLine(string.Join(" ", lst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
