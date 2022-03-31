using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgrammersLv1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            List<int> hamburgers = new List<int>();
            List<int> beverages = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                hamburgers.Add(int.Parse(sr.ReadLine()));
            }

            for (int i = 0; i < 2; i++)
            {
                beverages.Add(int.Parse(sr.ReadLine()));
            }

            sw.WriteLine($"{hamburgers.Min() + beverages.Min() - 50}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

}
