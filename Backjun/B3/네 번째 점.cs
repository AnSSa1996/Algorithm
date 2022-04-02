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

            List<int> X = new List<int>();
            List<int> Y = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                X.Add(inputs[0]);
                Y.Add(inputs[1]);
            }

            var PosX = X.GroupBy(x => x).Where(g => g.Count() == 1).Select(y => y.Key).First();
            var PosY = Y.GroupBy(x => x).Where(g => g.Count() == 1).Select(y => y.Key).First();

            sw.WriteLine($"{PosX} {PosY}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
