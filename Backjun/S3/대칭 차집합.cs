using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = inputs[0]; int b = inputs[1];

            List<int> aList = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            List<int> bList = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            var union = aList.Union(bList);
            var intersect = aList.Intersect(bList);
            var answer = union.Except(intersect);

            sw.WriteLine(answer.Count());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
