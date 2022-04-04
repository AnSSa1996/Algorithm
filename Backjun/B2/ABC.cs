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
            StringBuilder sb = new StringBuilder();

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            string order = sr.ReadLine();

            Array.Sort(nums);

            foreach (char c in order)
            {
                int index = c - 'A';
                sb.Append($"{nums[index]} ");
            }

            sb.Remove(sb.Length - 1, 1);
            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
