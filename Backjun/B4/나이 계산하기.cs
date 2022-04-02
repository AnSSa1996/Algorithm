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

            int[] fisrtInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] secondInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int man = 0;
            int han = secondInputs[0] - fisrtInputs[0] + 1;
            int year = secondInputs[0] - fisrtInputs[0];

            if (secondInputs[0] == fisrtInputs[0]) man = 0;
            else
            {
                if (fisrtInputs[1] < secondInputs[1])
                    man = secondInputs[0] - fisrtInputs[0];
                else if (fisrtInputs[1] == secondInputs[1])
                {
                    if (fisrtInputs[2] > secondInputs[2])
                    {
                        man = secondInputs[0] - fisrtInputs[0] - 1;
                    }
                    else
                    {
                        man = secondInputs[0] - fisrtInputs[0];
                    }
                }
                else
                {
                    man = secondInputs[0] - fisrtInputs[0] - 1;
                }
            }
            sw.WriteLine(man);
            sw.WriteLine(han);
            sw.WriteLine(year);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
