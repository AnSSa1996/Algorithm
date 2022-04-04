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

            List<int> submitStudents = new List<int>();
            List<int> totalSutdents = Enumerable.Range(1, 30).ToList();
            for (int i = 0; i < 28; i++)
            {
                submitStudents.Add(int.Parse(sr.ReadLine()));
            }
            var except = totalSutdents.Except(submitStudents).OrderBy(x => x);

            foreach (var i in except)
            {
                sw.WriteLine(i);
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
