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

            int N = int.Parse(sr.ReadLine());
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            List<int> orderList = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                int order = inputs[i - 1];
                orderList.Insert(orderList.Count() - order, i);
            }

            sw.WriteLine(string.Join(" ", orderList));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}