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

            int[] nums = Enumerable.Range(1, 20).ToArray();


            for (int i = 0; i < 10; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int index = inputs[0] - 1;
                int length = inputs[1] - inputs[0] + 1;

                Array.Reverse(nums, index, length);
            }

            sw.WriteLine(string.Join(" ", nums));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
