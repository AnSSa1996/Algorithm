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

            int count = 0;

            int bottles = inputs[0] + inputs[1];
            int div = inputs[2];

            while (true)
            {
                count += bottles / div;
                bottles = bottles / div + bottles % div;
                if (bottles < div) break;
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
