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

            int N = inputs[0];
            int order = inputs[1] - 1;

            int[] numArray = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Array.Sort(numArray);

            sw.WriteLine(numArray[order]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
