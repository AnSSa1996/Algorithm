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

            List<char> charList = sr.ReadLine().ToUpper().ToList();

            var sortedLst = charList.GroupBy(x => x).OrderByDescending(g => g.Count());

            if (sortedLst.Count() > 1)
            {
                int firsCount = sortedLst.First().Count();
                int secondCount = sortedLst.Skip(1).First().Count();
                if (firsCount == secondCount) sw.WriteLine("?");
                else sw.WriteLine($"{sortedLst.First().Key}");
            }
            else
            {
                sw.WriteLine(sortedLst.First().Key);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}