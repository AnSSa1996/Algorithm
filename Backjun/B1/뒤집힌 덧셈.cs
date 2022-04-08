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

            string[] inputs = sr.ReadLine().Split();

            int left = int.Parse(new string(inputs[0].Reverse().ToArray()));
            int right = int.Parse(new string(inputs[1].Reverse().ToArray()));

            int result = int.Parse(new string((left + right).ToString().Reverse().ToArray()));

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}