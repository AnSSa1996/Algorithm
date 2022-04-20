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
            List<int> firstLst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            List<int> secondLst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            var lst = firstLst.Except(secondLst).OrderBy(x => x);


            sw.WriteLine(lst.Count());
            if (lst.Count() > 0) sw.WriteLine(string.Join(" ", lst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
