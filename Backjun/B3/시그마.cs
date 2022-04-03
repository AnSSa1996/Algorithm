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

            BigInteger[] inputs = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse);

            if(inputs[0] > inputs[1])
            {
                var temp = inputs[0];
                inputs[0] = inputs[1];
                inputs[1] = temp;
            }

            BigInteger Sum = (inputs[0] + inputs[1]) * (inputs[1] - inputs[0] + 1) / 2;

            sw.WriteLine(Sum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
