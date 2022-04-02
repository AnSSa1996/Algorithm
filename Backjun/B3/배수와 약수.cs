using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            while (true)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (inputs.Sum() == 0)
                    break;
                string result = "neither";
                int left = inputs[0];
                int right = inputs[1];

                if (left % right == 0)
                    result = "multiple";
                else if (right % left == 0)
                    result = "factor";
                sw.WriteLine(result);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
