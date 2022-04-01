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

            string inputs = sr.ReadLine();
            int A = 0;
            int B = 0;
            if (inputs.Length == 2)
            {
                A = int.Parse(inputs[0].ToString());
                B = int.Parse(inputs[1].ToString());
            }
            else if(inputs[1] == '0' && inputs.Length == 3)
            {
                A = int.Parse(inputs.Substring(0, 2));
                B = int.Parse(inputs[2].ToString());
            }
            else if(inputs.Length == 3)
            {
                A = int.Parse(inputs[0].ToString());
                B = int.Parse(inputs.Substring(1, 2));
            }
            else
            {
                A = 10;
                B = 10;
            }

            sw.WriteLine(A + B);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}