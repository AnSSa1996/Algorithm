using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            List<int> nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            var sortedNums = nums.OrderBy(x => x);

            foreach (var num in sortedNums)
            {
                sb.Append($"{num} ");
            }

            sb.Remove(sb.Length - 1, 1);
            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
