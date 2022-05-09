using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int C = inputs[1];

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            var sortedLst = nums.GroupBy(x => x).OrderByDescending(g => g.Count()).ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var lst in sortedLst)
            {
                sb.Append($"{string.Join(" ", lst)} ");
            }

            sb.Remove(sb.Length - 1, 1);
            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
