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
            List<int> nums = new List<int>();

            for (int i = 0; i < 7; i++) nums.Add(int.Parse(sr.ReadLine()));

            var oddList = nums.Where(x => x % 2 == 1);

            if (oddList.Count() > 0)
            {
                sw.WriteLine(oddList.Sum());    
                sw.WriteLine(oddList.Min());
            }
            else
            {
                sw.WriteLine(-1);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
