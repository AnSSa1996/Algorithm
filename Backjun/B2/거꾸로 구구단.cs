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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int num = inputs[0];
            int N = inputs[1];

            List<int> numLst = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                int newN = int.Parse(new string((num * i).ToString().Reverse().ToArray()));
                numLst.Add(newN);
            }

            sw.WriteLine(numLst.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}