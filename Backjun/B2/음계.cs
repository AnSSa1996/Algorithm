using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] ascending = Enumerable.Range(1, 8).ToArray();
            int[] descending = ascending.Reverse().ToArray();

            if (inputs.SequenceEqual(ascending)) sw.WriteLine("ascending");
            else if (inputs.SequenceEqual(descending)) sw.WriteLine("descending");
            else sw.WriteLine("mixed");

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
