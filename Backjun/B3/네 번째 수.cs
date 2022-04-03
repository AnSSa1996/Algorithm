using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        public static List<int> sosu = new List<int>();
        public static bool[] sosuCheck;
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Array.Sort(inputs);

            int firstTerm = inputs[0];
            int dif = Math.Min(inputs[1] - inputs[0], inputs[2] - inputs[1]);
            int sum = 4 * firstTerm + 6 * dif;
            int result = sum - inputs.Sum();
            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
