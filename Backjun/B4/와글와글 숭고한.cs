using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


            List<int> inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            string result = null;
            if (inputs.Sum() >= 100) result = "OK";
            else
            {
                int index = inputs.IndexOf(inputs.Min());
                if (index == 0) result = "Soongsil";
                else if (index == 1) result = "Korea";
                else result = "Hanyang";
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
