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
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int total = inputs.GroupBy(x => x).Where(g => g.Count() > 1).Sum(w => w.Count() - 1);
            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
