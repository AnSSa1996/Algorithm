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

            int maxNums = -1;
            int people = 0;
            for (int i = 0; i < 10; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int off = inputs[0];
                int on = inputs[1];
                people += on - off;
                maxNums = Math.Max(maxNums, people);
            }

            sw.WriteLine(maxNums);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
