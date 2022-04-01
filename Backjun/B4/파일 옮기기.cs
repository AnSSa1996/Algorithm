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


            List<int> inputsFirst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            List<int> inputSecond = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            int x = inputsFirst[0] + inputSecond[1];
            int y = inputsFirst[1] + inputSecond[0];

            int result = Math.Min(x, y);
            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
