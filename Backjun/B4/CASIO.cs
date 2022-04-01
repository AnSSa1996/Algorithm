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

            List<BigInteger> inputs = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse).ToList();

            BigInteger result = 0;
            if (inputs[0] == inputs[1])
                result = 1;

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
